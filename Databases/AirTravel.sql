DROP TABLE IF EXISTS user_accounts, tickets_price, tickets_misc, tickets, clients;

CREATE TABLE clients
(
	Client_ID		INT 			NOT NULL 	AUTO_INCREMENT,
	Full_name		VARCHAR(48) 	NOT NULL,
	Login			VARCHAR(16) 	NOT NULL,
	PRIMARY KEY 	(Client_ID)
);

CREATE TABLE user_accounts
(
	Client_ID		INT				NOT NULL,
	Login			VARCHAR(16) 	NOT NULL,
	Password		VARCHAR(16) 	NOT NULL,
	FOREIGN KEY 	(Client_ID) 	REFERENCES 	clients(Client_ID)
);

CREATE TABLE tickets
(
	Client_ID		INT				NOT NULL,
	Ticket_Date		DATE 			NOT NULL,
	Source			VARCHAR(32) 	NOT NULL,
	Destination 	VARCHAR(32) 	NOT NULL,
	Ticket_ID		INT 			NOT NULL	AUTO_INCREMENT,
	PRIMARY KEY 	(Ticket_ID),
	FOREIGN KEY 	(Client_ID) 	REFERENCES 	clients(Client_ID)
);

CREATE TABLE tickets_price
(
	Ticket_ID		INT				NOT NULL,
	Price			FLOAT(5,2)		NOT NULL,
	FOREIGN KEY 	(Ticket_ID)		REFERENCES 	tickets(Ticket_ID)
);

CREATE TABLE tickets_misc
(
	Ticket_ID		INT				NOT NULL,
	Ticket_Class	VARCHAR(16)		NOT NULL,
	One_way			BOOLEAN 		NOT NULL,
	FOREIGN KEY 	(Ticket_ID)		REFERENCES 	tickets(Ticket_ID)
);



/* Data Population */



/* clients */ 
INSERT INTO clients (Full_name, Login) VALUES("Krzysztof Krol", "Layor123");
INSERT INTO clients (Full_name, Login) VALUES("Hubert Majewski", "Szefito");
INSERT INTO clients (Full_name, Login) VALUES("Chleboslaw Sqlacek", "soberat1");
INSERT INTO clients (Full_name, Login) VALUES("Mateusz Ciaranek", "Ementan");
INSERT INTO clients (Full_name, Login) VALUES("Krzysztof Nalepa", "CitekFitek");


/* tickets */
INSERT INTO tickets (Client_ID, Ticket_Date, Source, Destination) VALUES((select Client_ID from clients where Full_name="Hubert Majewski"), "2021-10-21", "Krakow", "Malediwy");
INSERT INTO tickets (Client_ID, Ticket_Date, Source, Destination) VALUES((select Client_ID from clients where Full_name="Hubert Majewski"), "2031-10-21", "Krakow", "Dubaj");
INSERT INTO tickets (Client_ID, Ticket_Date, Source, Destination) VALUES((select Client_ID from clients where Full_name="Krzysztof Krol"), "2013-3-21", "Krakow", "Rzym");	
INSERT INTO tickets (Client_ID, Ticket_Date, Source, Destination) VALUES((select Client_ID from clients where Full_name="Krzysztof Nalepa"), "2022-7-21", "Warszawa", "Chile");
INSERT INTO tickets (Client_ID, Ticket_Date, Source, Destination) VALUES((select Client_ID from clients where Full_name="Hubert Majewski"), "2022-10-21", "Krakow", "Malediwy");
					



