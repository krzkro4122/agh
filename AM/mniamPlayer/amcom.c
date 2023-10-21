#include <string.h>
#include <stdint.h>
#include <stdio.h>
#include "amcom.h"

/// Start of packet character
const uint8_t  AMCOM_SOP         = 0xA1;
const uint16_t AMCOM_INITIAL_CRC = 0xFFFF;

static uint16_t AMCOM_UpdateCRC(uint8_t byte, uint16_t crc)
{
	byte ^= (uint8_t)(crc & 0x00ff);
	byte ^= (uint8_t)(byte << 4);
	return ((((uint16_t)byte << 8) | (uint8_t)(crc >> 8)) ^ (uint8_t)(byte >> 4) ^ ((uint16_t)byte << 3));
}

void AMCOM_InitReceiver(AMCOM_Receiver* receiver, AMCOM_PacketHandler packetHandlerCallback, void* userContext) {
    
    if (receiver == NULL) return;    
    
	receiver->packetHandler = packetHandlerCallback;
	receiver->userContext = userContext;
}

size_t AMCOM_Serialize(uint8_t packetType, const void* payload, size_t payloadSize, uint8_t* destinationBuffer) {
	// Temporary packet header
	AMCOM_PacketHeader packetHeaderHandler;

	// Populate with given data
	packetHeaderHandler.sop = AMCOM_SOP;
	packetHeaderHandler.type = packetType;
	packetHeaderHandler.length = payloadSize;
	packetHeaderHandler.crc = AMCOM_INITIAL_CRC;
	
	// Temporary packet handler
	AMCOM_Packet packetHandler;	
	packetHandler.header = packetHeaderHandler;
	
	// CRC updates
	packetHeaderHandler.crc = AMCOM_UpdateCRC(packetHeaderHandler.type, packetHeaderHandler.crc);
	packetHeaderHandler.crc = AMCOM_UpdateCRC(packetHeaderHandler.length, packetHeaderHandler.crc);
	
    for (size_t counter = 0; counter < payloadSize; ++counter){    
        packetHeaderHandler.crc = AMCOM_UpdateCRC(((uint8_t*)payload)[counter], packetHeaderHandler.crc);
    }

	// Populate destination buffer with data
	memcpy(destinationBuffer, &packetHeaderHandler, sizeof(AMCOM_PacketHeader));
	memcpy(destinationBuffer + sizeof(AMCOM_PacketHeader), payload, payloadSize);
        
    // Bytes written to destination buffer
    return payloadSize + sizeof(AMCOM_PacketHeader);
}

void AMCOM_Deserialize(AMCOM_Receiver* receiver, const void* data, size_t dataSize) {
    static uint8_t lowerCRC = 0;
    static uint8_t higherCRC = 0;
    uint16_t calculatedCRC = AMCOM_INITIAL_CRC;
            
    for (size_t i = 0; i < dataSize; ++i)
    {
        // Byte received from buffer
        uint8_t currentByte = ((uint8_t*)data)[i];
                        
        switch (receiver->receivedPacketState)
        {
        case AMCOM_PACKET_STATE_EMPTY:
            // SOP
            if (currentByte == AMCOM_SOP){
                receiver->receivedPacket.header.sop = AMCOM_SOP;                
                receiver->receivedPacketState = AMCOM_PACKET_STATE_GOT_SOP;
            }
            break;
        case AMCOM_PACKET_STATE_GOT_SOP:
            // TYPE
            receiver->receivedPacket.header.type = currentByte;
            receiver->receivedPacketState = AMCOM_PACKET_STATE_GOT_TYPE;
            break;
        case AMCOM_PACKET_STATE_GOT_TYPE:
            // LENGTH
            if (currentByte >= 0 && currentByte <= AMCOM_MAX_PACKET_SIZE){
                receiver->receivedPacket.header.length = currentByte;
                receiver->receivedPacketState = AMCOM_PACKET_STATE_GOT_LENGTH;
            } else receiver->receivedPacketState = AMCOM_PACKET_STATE_EMPTY;
            break;
        case AMCOM_PACKET_STATE_GOT_LENGTH:
            // LOWER CRC
            lowerCRC = currentByte;
            receiver->receivedPacketState = AMCOM_PACKET_STATE_GOT_CRC_LO;
            break;
        case AMCOM_PACKET_STATE_GOT_CRC_LO:
            // HIGHER CRC
            higherCRC = currentByte;            
            // Store Crc in header
            receiver->receivedPacket.header.crc = ((higherCRC << 8) | lowerCRC );            
            // Chech if there is payload to handle
            if (receiver->receivedPacket.header.length == 0){
                receiver->receivedPacketState = AMCOM_PACKET_STATE_GOT_WHOLE_PACKET;                  
                goto payload_received;
            } else receiver->receivedPacketState = AMCOM_PACKET_STATE_GETTING_PAYLOAD;            
            break;
        case AMCOM_PACKET_STATE_GETTING_PAYLOAD:
            // Getting data from incoming payload        
            receiver->receivedPacket.payload[receiver->payloadCounter] = currentByte;
            receiver->payloadCounter++;            
            // Check if all incoming payload got handled
            if (receiver->payloadCounter == receiver->receivedPacket.header.length){
                receiver->receivedPacketState =  AMCOM_PACKET_STATE_GOT_WHOLE_PACKET;                
                goto payload_received;
            }
            break;
    // Here to handle incoming payload
    payload_received:
        case AMCOM_PACKET_STATE_GOT_WHOLE_PACKET:
            // CRC update after whole payload received
            calculatedCRC = AMCOM_UpdateCRC(receiver->receivedPacket.header.type, calculatedCRC);
            calculatedCRC = AMCOM_UpdateCRC(receiver->receivedPacket.header.length, calculatedCRC);
            
            for (size_t j = 0; j < receiver->payloadCounter; ++j)            
                calculatedCRC = AMCOM_UpdateCRC(receiver->receivedPacket.payload[j], calculatedCRC);
                                                
            // Compare calculated and received CRC
            if ( calculatedCRC == receiver->receivedPacket.header.crc ){
                // Upon a successful match use user callback
                receiver->packetHandler(&(receiver->receivedPacket), receiver->userContext);
            }                                                
            // Now once again empty
            receiver->receivedPacketState = AMCOM_PACKET_STATE_EMPTY;        
            receiver->payloadCounter = 0;            
            break;            
        }    
    }
}