DROP TABLE IF EXISTS books;


CREATE TABLE books
(
    title          CHAR(50)    NOT NULL,
    author         CHAR(30)    NOT NULL,
    publisher      CHAR(30),
    topic          CHAR(20),
    comment        CHAR(100),
    price          FLOAT
);

INSERT INTO books VALUES ("MySQL", "Paul DuBois", "New Riders", "MySQL", 
    "Excellent book, but doesn't cover Java API", 49.99);

INSERT INTO books VALUES ("Beginning XML", "David Hunter", "Wrox", "XML",
    "Well recommended, fairly comprehensive", 39.99);

INSERT INTO books VALUES ("Java How to Program", "Paul Deitel", "Prentice Hall", "Java",
    "Good textbook, extremely detailed", 68.19);

INSERT INTO books VALUES ("Thinking in Java", "Bruce Eckel", "Prentice Hall", "Java",
    "Well written, free on the web", 10.99); 

INSERT INTO books VALUES ("Java Programming Language", "Ken Arnold", "Addison Wesley", "Java",
    "Considered to be from the source", 37.95);

INSERT INTO books VALUES ("Learning Perl", "Randal Schwartz", "O'Reilly", "Perl",
    "Not a bad start", 29.95);

INSERT INTO books VALUES ("Programming Perl", "Larry Wall", "O'Reilly", "Perl",
    "Usually considered THE reference", 44.95);

INSERT INTO books VALUES ("Effective Perl Programming", "Joseph Hall", "Addison Wesley", "Perl",
    "Great tips, not for beginners", 34.95);

INSERT INTO books VALUES ("XML: A Manager's Guide", "Kevin Dick", "Addison Wesley", "XML",
    "Explains the basic XML principles", 79.91);

INSERT INTO books VALUES ("Exploring Java", "Josh Peck", "Addison Wesley", "Java",
    "This book covers topics like Beans and RMI", 27.96);

INSERT INTO books VALUES ("Java Language Reference", "Mark Grand", "Addison Wesley", "Java",
    "Java programming language in detail", 6.95);
    
INSERT INTO books VALUES ("Programming Scala", "Dean Wampler", "O'Reilly", "Scala",
    "Ideal for beginning and advanced developers", 42.72);

INSERT INTO books VALUES ("Perl Pocket Reference", "Johan Vromans", "O'Reilly", "Perl",
    "Complete overview of the Perl programming language", 11.97);
    
INSERT INTO books VALUES ("XQuery", "Michael Brundage", "Addison Wesley", "XML",
    "The XML Query Language", 59.99);
    
