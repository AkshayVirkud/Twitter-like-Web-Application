create database Twitter;

use Twitter;

CREATE TABLE USERS
(
USERID INT NOT NULL IDENTITY(1,1),
USERNAME VARCHAR(10),
USER_PASS VARCHAR(100),
SECURITY_QUES VARCHAR(30),
SECURITY_ANS VARCHAR(30),
PRIMARY KEY  CLUSTERED ([USERID] ASC)
);
GO

EXEC sp_RENAME 'USERS.USER_PASS' , 'PASSWORD', 'COLUMN'

CREATE TABLE TWEETS
(
TWEETID INT,
USERID INT,
TWEET VARCHAR(250),
PRIMARY KEY CLUSTERED ([TWEETID] ASC),
FOREIGN KEY ([USERID]) REFERENCES [USERS]([USERID])
);
GO

CREATE TABLE FRIENDS
(
USERID INT,
FRIENDID INT,
PRIMARY KEY CLUSTERED ([USERID] ASC, [FRIENDID] ASC),
FOREIGN KEY ([USERID]) REFERENCES [USERS]([USERID]),
FOREIGN KEY ([FRIENDID]) REFERENCES [USERS]([USERID])
);
GO

SELECT * FROM USERS;
SELECT * FROM TWEETS;
SELECT * FROM FRIENDS;

INSERT INTO USERS (USERNAME, USER_PASS, SECURITY_QUES, SECURITY_ANS) 
VALUES ('Nathan', 'password', 'What is the name of your car?', 'Fiona');

INSERT INTO USERS (USERNAME, USER_PASS, SECURITY_QUES, SECURITY_ANS) 
VALUES ('Akshay', 'password', 'What is your favorite color?', 'Blue');

INSERT INTO USERS (USERNAME, USER_PASS, SECURITY_QUES, SECURITY_ANS) 
VALUES ('Yeshwanthi', 'password', 'What is your pet name?', 'No pet');

INSERT INTO USERS (USERNAME, USER_PASS, SECURITY_QUES, SECURITY_ANS) 
VALUES ('Geetha', 'password', 'What is your new toy?', 'Samsung Galaxy tab');

INSERT INTO TWEETS
VALUES (1, 1, 'Awesomeeeeeeeeeeeee!!!');

INSERT INTO TWEETS
VALUES (2, 2, 'Geetha likes her Galaxy tab');

INSERT INTO TWEETS
VALUES (3, 3, 'My MAC is a pink computer');

INSERT INTO TWEETS
VALUES (4, 4, 'Nathan is telling what everyone should tweet');

INSERT INTO FRIENDS
VALUES (1, 2);

INSERT INTO FRIENDS
VALUES (1, 3);

INSERT INTO FRIENDS
VALUES (1, 4);

INSERT INTO FRIENDS
VALUES (2, 1);

INSERT INTO FRIENDS
VALUES (2, 4);

INSERT INTO FRIENDS
VALUES (2, 3);

INSERT INTO FRIENDS
VALUES (3, 1);

INSERT INTO FRIENDS
VALUES (3, 2);

INSERT INTO FRIENDS
VALUES (3, 4);

SELECT * FROM FRIENDS;