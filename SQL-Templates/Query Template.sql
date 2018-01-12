-- CREATE TABLE users (
--     id int NOT NULL AUTO_INCREMENT,
--     username VARCHAR(20) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     password VARCHAR(255) NOT NULL,
--     avatarurl VARCHAR(255),
--     firstname VARCHAR(255),
--     lastname VARCHAR(255),
--     PRIMARY KEY (id),
--     UNIQUE KEY email (email)
-- );

-- CREATE TABLE vaults (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(20) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId int,
--     INDEX userId (userId),
--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE keeps (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(20) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId int,
--     imageurl VARCHAR(255),
--     views int,
--     keeps int,
--     shares int,
--     INDEX userId (userId),
--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE vaultkeeps (
--     id int NOT NULL AUTO_INCREMENT,
--     vaultId int NOT NULL,
--     keepId int NOT NULL,
--     userId int NOT NULL,

--     PRIMARY KEY (id),
--     INDEX (vaultId, keepId),
--     INDEX (userId),

--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (vaultId)
--         REFERENCES vaults(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (keepId)
--         REFERENCES keeps(id)
--         ON DELETE CASCADE
-- )


-- USE THIS LINE FOR GET KEEPS BY VAULTID
-- SELECT * FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId 
-- WHERE (vaultId = 2)

--------------------------------------

-- ALTER TABLE keeps ADD creatorid int

-- ALTER TABLE keeps DROP COLUMN creatorid

--------------------------------------

-- INSERT INTO users (Username, Email, Password, AvatarUrl, FirstName, LastName)
-- VALUES ("cameron", "c@c.com", "test", "//placehold.it/200x200", "cameron", "cameron");
-- SELECT LAST_INSERT_ID();

-- INSERT INTO keeps (Name, Description, UserId, ImageUrl, Views, Keeps, Shares)
-- VALUES ("keep2", "Second keep test", 4, "//placehold.it/200x200", 0, 0, 0);
-- SELECT LAST_INSERT_ID();

-- INSERT INTO vaults (Name, Description, UserId)
-- VALUES ("vault1", "First vault test", 4);
-- SELECT LAST_INSERT_ID();

-- INSERT INTO vaultkeeps (VaultId, KeepId, UserId)
-- VALUES (1, 4, 4);
-- SELECT LAST_INSERT_ID();

-- USE THIS LINE FOR GET KEEPS BY VAULTID
-- SELECT * FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId 
-- WHERE (vaultId = 1)

-- DELETE FROM users WHERE id = 4
