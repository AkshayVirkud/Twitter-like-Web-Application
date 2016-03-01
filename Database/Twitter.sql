BEGIN TRANSACTION;
CREATE TABLE "Users" (
	`UserId`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`Username`	TEXT,
	`Password`	TEXT,
	`Security Question`	TEXT,
	`Security Answer`	TEXT
);
INSERT INTO `Users` VALUES ('1','akshay','password','What is your favorite color?','Blue');
INSERT INTO `Users` VALUES ('2','geetha','password','What is favorite color?','Purple');
CREATE TABLE TWEETS
(
TWEETID INTEGER PRIMARY KEY,
USERID INTEGER,
TWEET TEXT,
FOREIGN KEY(USERID) REFERENCES USERS(USERID)
);
INSERT INTO `TWEETS` VALUES ('1','2','Hi');
COMMIT;
