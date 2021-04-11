DROP TABLE IF EXISTS User, Goods, Vendor;

CREATE TABLE User
(
	name		VARCHAR(20),
	surname		VARCHAR(20),
	PESEL		VARCHAR(20),
	born		VARCHAR(20),
	user_id		INT			NOT NULL
);

CREATE TABLE Goods
(
	product		VARCHAR(20),
	goods_id	INT 		NOT NULL
);

CREATE TABLE Vendor
(
	name		VARCHAR(20),
	area		VARCHAR(20),
	vendor_id	INT			NOT NULL
);

INSERT INTO User VALUES ("Jan", "Kowalski", "75020201234", "02.02.1975", 1000);
INSERT INTO User VALUES ("Jan",	"Kowalski", "76030201034", "02.03.1976", 1001);
INSERT INTO User VALUES ("Andrzej", "Nowak", "75020203434", "02.02.1975", 1002);
INSERT INTO User VALUES ("Anna", "Kowalska", "79103001234", "30.10.1979", 1003);

INSERT INTO Goods VALUES ("refrigerator", 2000);
INSERT INTO Goods VALUES ("washing machine", 2001);
INSERT INTO Goods VALUES ("hair dryer", 2002);
INSERT INTO Goods VALUES ("TV", 2003);
INSERT INTO Goods VALUES ("blue-ray player", 2004);
INSERT INTO Goods VALUES ("satellite tuner", 2005);

INSERT INTO Vendor VALUES ("Your Gorgeous Bathroom", "bathroom", 3000); /* first argument "name" longer than varchar(20) */
INSERT INTO Vendor VALUES ("World of Satellites", "TV SAT", 3001);
INSERT INTO Vendor VALUES ("Super Coffee", "coffee makers", 3002);
INSERT INTO Vendor VALUES ("A.B.C.D.", "hifi", 3003);
INSERT INTO Vendor VALUES ("Dry Hair", "hair dryers", 3004);