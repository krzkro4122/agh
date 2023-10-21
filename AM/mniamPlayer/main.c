#undef UNICODE
#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <winsock2.h>
#include <ws2tcpip.h>
#include <stdlib.h>
#include <stdio.h>
#include <math.h>

#include "amcom.h"
#include "amcom_packets.h"

#define DEFAULT_TCP_PORT 	"2001"

// Self reference 
AMCOM_PlayerState selfReference;

// Array of Food structs for storage
AMCOM_FoodState foodStates[AMCOM_MAX_FOOD_UPDATES];	
// Array of Food structs for storage
AMCOM_FoodState availableFoodStates[AMCOM_MAX_FOOD_UPDATES];	
// Array of Player structs for storage
AMCOM_PlayerState playerStates[AMCOM_MAX_PLAYER_UPDATES];

/**
 * Compute distance between 2 points
 */
float calculateDistance(float sourceX, float sourceY, float destinationX, float destinationY){
	// |AB| = sqrt( (xB - xA)^2 + (yB - yA)^2 )
	return pow( pow(destinationX - sourceX, 2) + pow(destinationY - sourceY, 2) , 0.5);
}

/**
 * Compute angle at which to continue movement in radians
 */
float computeAngle(float sourceX, float sourceY, float destinationX, float destinationY){

	float delta_x = destinationX - sourceX;
	float delta_y = destinationY - sourceY;
		
	return atan2(delta_y, delta_x);
}

/**
 * This function will be called each time a valid AMCOM packet is received
 */
void amcomPacketHandler(const AMCOM_Packet* packet, void* userContext) {
	uint8_t amcomBuf[AMCOM_MAX_PACKET_SIZE];	// buffer used to serialize outgoing packets
	size_t bytesToSend = 0;						// size of the outgoing packet	
	SOCKET sock = (SOCKET)userContext;			// socket used for communication with the game client
	uint8_t numberOfPlayers = 0;
	float mapWidth, mapHeight;

	// Way to access nested structures fields:
	// AMCOM_FoodUpdateRequestPayload* variable = ((AMCOM_FoodUpdateRequestPayload*) packet->payload);
	// variable->foodState->state;

	switch (packet->header.type) {
	// Player identification
	case AMCOM_IDENTIFY_REQUEST:
		printf("Got IDENTIFY.request. Responding with IDENTIFY.response\n");
		AMCOM_IdentifyResponsePayload identifyResponse;
		// Stating my name
		sprintf(identifyResponse.playerName, "Amogus");
		// 
		bytesToSend = AMCOM_Serialize(AMCOM_IDENTIFY_RESPONSE, &identifyResponse, sizeof(identifyResponse), amcomBuf);
		break;
	// Start game request
	case AMCOM_NEW_GAME_REQUEST:
		printf("Got NEW_GAME.request.\n");
		// Access to received packet's AMCOM_PlayerState struct fields
		AMCOM_NewGameRequestPayload* innerPacketNewGame = ((AMCOM_NewGameRequestPayload*) packet->payload);
		// Getting fields from packet
		selfReference.playerNo = innerPacketNewGame->playerNumber;
		numberOfPlayers = innerPacketNewGame->numberOfPlayers;
		mapWidth = innerPacketNewGame->mapWidth;
		mapHeight = innerPacketNewGame->mapHeight;
		// 
		bytesToSend = AMCOM_Serialize(AMCOM_NEW_GAME_RESPONSE, NULL, 0, amcomBuf);
	    break;
	// Player information update
	case AMCOM_PLAYER_UPDATE_REQUEST:
		printf("Got PLAYER_UPDATE.request.\n");
		// Access to received packet's AMCOM_PlayerState struct fields
		AMCOM_PlayerUpdateRequestPayload* innerPacketPlayerUpdate = ((AMCOM_PlayerUpdateRequestPayload*) packet->payload);						
		// Loop through all players and store information about them
		for(uint16_t i = 0; i < numberOfPlayers; i++){
			// Shortcut to current foods struct for ease of use
			AMCOM_PlayerState playerState = innerPacketPlayerUpdate->playerState[i];
			// Store player objects in an array
			playerStates[i].playerNo = playerState.playerNo;
			playerStates[i].hp = playerState.hp;
			playerStates[i].x = playerState.x;
			playerStates[i].y = playerState.y;
			// My own parameters			
			if (selfReference.playerNo == playerState.playerNo){
				selfReference.hp = playerState.hp;
				selfReference.x = playerState.x;
				selfReference.y = playerState.y;
			}
		}
	    break;
	// Food information update
	case AMCOM_FOOD_UPDATE_REQUEST:
		printf("Got FOOD_UPDATE.request.\n");
		// Access to received packet's AMCOM_FoodState struct fields
		AMCOM_FoodUpdateRequestPayload* innerPacketFoodUpdate = ((AMCOM_FoodUpdateRequestPayload*) packet->payload);						
		// Loops limit			
		uint16_t allFoods = packet->header.length / sizeof(AMCOM_FoodState);
		// Loop through all food objects until an available one is found and set is as the closest
		for (uint16_t i = 0; i < allFoods; i++){			
			// Shortcut to current foods struct for ease of use		
			AMCOM_FoodState foodState = innerPacketFoodUpdate->foodState[i];
			// Store food objects in an array
			foodStates[i].foodNo = foodState.foodNo;
			foodStates[i].state = foodState.state;
			foodStates[i].x = foodState.x;
			foodStates[i].y = foodState.y;			
		} /* for */									
		// Now retrieve and store only available foods
		for (uint16_t i = 0; i < allFoods; i++){			
			// Shortcut to current foods struct for ease of use		
			AMCOM_FoodState foodState = innerPacketFoodUpdate->foodState[i];
			// Store food objects in an array
			availableFoodStates[i].foodNo = foodState.foodNo;
			availableFoodStates[i].state = foodState.state;
			availableFoodStates[i].x = foodState.x;
			availableFoodStates[i].y = foodState.y;			
		} /* for */									
		break;
	// Move request
	case AMCOM_MOVE_REQUEST:
		printf("Got MOVE.request.\n");
		AMCOM_MoveResponsePayload moveResponse;
		AMCOM_MoveRequestPayload* innerPacketMove = ((AMCOM_MoveRequestPayload*) packet->payload);						
		// Variables storing current closest food object parameters
		uint16_t closestFoodNo;
		float closestFoodDistance;
		float closestFoodX;
		float closestFoodY;
		// I am here
		selfReference.x = innerPacketMove->x;
		selfReference.y = innerPacketMove->y;		
		// Loop through food objects
		for (uint16_t i = 0; i < sizeof(availableFoodStates) / sizeof(AMCOM_FoodState); i++){		
			// Check only available pieces of food 
			if ( availableFoodStates[i].state == 1 ){					
				// Current food's distance
				float tempDistance = calculateDistance(selfReference.x, selfReference.y, availableFoodStates[i].x, availableFoodStates[i].y);
				// If closestFoodDistance not yet initialised (hence == 0) or current food is closer then previous closest food object
				if( closestFoodDistance == 0 || closestFoodDistance > tempDistance ){			
					// Current food was detected to be the closest one, so store it's parameters									
					closestFoodNo = availableFoodStates[i].foodNo;
					closestFoodX = availableFoodStates[i].x;
					closestFoodY = availableFoodStates[i].y;
					closestFoodDistance = tempDistance;	
				} /* if */
			} /* if */
		// printf("FoodNo: %d\n", availableFoodStates[i].foodNo);
		printf("FoodState: %d\n", availableFoodStates[i].state);
		} /* for */		
		printf("\n");
		printf("\n");
		// Decide where to go		
		moveResponse.angle = computeAngle(selfReference.x, selfReference.y, closestFoodX, closestFoodY);		
		closestFoodDistance = 0;
		// 
		bytesToSend = AMCOM_Serialize(AMCOM_MOVE_RESPONSE, &moveResponse, sizeof(moveResponse), amcomBuf);
		break;
	} /* switch */

	if (bytesToSend > 0) {
		int bytesSent = send(sock, (const char*)amcomBuf, bytesToSend, 0 );
		if (bytesSent == SOCKET_ERROR) {
			printf("Socket send failed with error: %d\n", WSAGetLastError());
			closesocket(sock);
			return;
		} else printf("Sent %d bytes through socket.\n", bytesSent);		
	}
}

DWORD WINAPI playerThread( LPVOID lpParam )
{
	AMCOM_Receiver amcomReceiver;		// AMCOM receiver structure
	SOCKET sock = (SOCKET)(lpParam);	// socket used for communication with game client
	char buf[512];						// buffer for temporary data
	int receivedBytesCount;				// holds the number of bytes received via socket

	printf("Got new TCP connection.\n");

	// Initialize AMCOM receiver
	AMCOM_InitReceiver(&amcomReceiver, amcomPacketHandler, (void*)sock);

	// Receive data from socket until the peer shuts down the connection
	do {
		// Fetch the bytes from socket into buf
		receivedBytesCount = recv(sock, buf, sizeof(buf), 0);
		if (receivedBytesCount > 0) {
			printf("Received %d bytes in socket.\n", receivedBytesCount);
			// Try to deserialize the incoming data
			AMCOM_Deserialize(&amcomReceiver, buf, receivedBytesCount);
		} else if (receivedBytesCount < 0) {
			// Negative result indicates that there was socket communication error
			printf("Socket recv failed with error: %d\n", WSAGetLastError());
			closesocket(sock);
			break;
		}
	} while (receivedBytesCount > 0);

	printf("Closing connection.\n");

	// shutdown the connection since we're done
	receivedBytesCount = shutdown(sock, SD_SEND);
	// cleanup
	closesocket(sock);

	return 0;
}

int main(int argc, char **argv) {
	WSADATA wsaData;						// socket library data
	SOCKET listenSocket = 2001;	// socket on which we will listen for incoming connections
	SOCKET clientSocket = 2001;	// socket for actual communication with the game client
	struct addrinfo *addrResult = NULL;
	struct addrinfo hints;
	int result;

	// Say hello
	printf("mniAM player listening on port %s\nPress CTRL+x to quit\n", DEFAULT_TCP_PORT);

	// Initialize Winsock
	result = WSAStartup(MAKEWORD(2,2), &wsaData);
	if (result != 0) {
		printf("WSAStartup failed with error: %d\n", result);
		return -1;
	}

	// Prepare hints structure
	memset(&hints, 0, sizeof(hints));
	hints.ai_family = AF_INET;
	hints.ai_socktype = SOCK_STREAM;
	hints.ai_protocol = IPPROTO_TCP;
	hints.ai_flags = AI_PASSIVE;

	// Resolve the server address and port
	result = getaddrinfo(NULL, DEFAULT_TCP_PORT, &hints, &addrResult);
	if ( result != 0 ) {
		printf("Function 'getaddrinfo' failed with error: %d\n", result);
		WSACleanup();
		return -2;
	}

	// Create a socket for connecting to server
	listenSocket = socket(addrResult->ai_family, addrResult->ai_socktype, addrResult->ai_protocol);
	if (listenSocket == INVALID_SOCKET) {
		printf("Function 'socket' failed with error: %ld\n", WSAGetLastError());
		freeaddrinfo(addrResult);
		WSACleanup();
		return -3;
	}
	// Setup the TCP listening socket
	result = bind(listenSocket, addrResult->ai_addr, (int)addrResult->ai_addrlen);
	if (result == SOCKET_ERROR) {
		printf("Function 'bind' failed with error: %d\n", WSAGetLastError());
		freeaddrinfo(addrResult);
		closesocket(listenSocket);
		WSACleanup();
		return -4;
	}
	freeaddrinfo(addrResult);

	// Listen for connections
	result = listen(listenSocket, SOMAXCONN);
	if (result == SOCKET_ERROR) {
		printf("Function 'listen' failed with error: %d\n", WSAGetLastError());
		closesocket(listenSocket);
		WSACleanup();
		return -5;
	}

	while (1) {
		// Accept client socket
		clientSocket = accept(listenSocket, NULL, NULL);
		if (clientSocket == INVALID_SOCKET) {
			printf("Function 'accept' failed with error: %d\n", WSAGetLastError());
			closesocket(listenSocket);
			WSACleanup();
			return -6;
		} else {
			// Run a separate thread to handle the actual game communication
			CreateThread(NULL, 0, playerThread, (void*)clientSocket, 0, NULL);
		}
		Sleep(10);
	}

	// No longer need server socket
	closesocket(listenSocket);
	// Deinitialize socket library
	WSACleanup();
	// We're done
	return 0;
}
