-- Switch to master to ensure we can create the database
use master

-- Drop database if it exists
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'BookClub')
BEGIN
    ALTER DATABASE BookClub SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE BookClub;
END

-- Create the database
CREATE DATABASE BookClub;
GO

-- Use the newly created database
USE BookClub;
GO

-- Create the Accounts table
IF NOT EXISTS (
	SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Accounts'
	)
BEGIN
	CREATE TABLE Accounts (
		AccountId INT PRIMARY KEY IDENTITY(1,1),
		FirstName NVARCHAR(50) NOT NULL,
		LastName NVARCHAR(50) NOT NULL,
		DateOfBirth DATE NOT NULL,
		Email NVARCHAR(100) NOT NULL UNIQUE,
		Username NVARCHAR(50) NOT NULL UNIQUE,
		PasswordHash NVARCHAR(255) NOT NULL,
		DateCreated DATETIME DEFAULT GETDATE()
	);
END
GO

-- Create the Books table
IF NOT EXISTS (
	SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Books'
	)
BEGIN
	CREATE TABLE Books (
		BookId INT PRIMARY KEY IDENTITY(1,1),
		Title NVARCHAR(255) NOT NULL,
		Author NVARCHAR(255) NOT NULL,
		BookDescription NVARCHAR(MAX),
		ISBN NVARCHAR(20) UNIQUE,
		DatePublished DATE
	);
END
GO

-- Create the Reviews table
IF NOT EXISTS (
	SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Reviews'
	)
BEGIN
	CREATE TABLE Reviews (
		ReviewId INT PRIMARY KEY IDENTITY(1,1),
		AccountId INT NOT NULL,
		BookId INT NOT NULL,
		Rating INT CHECK (Rating >= 1 AND Rating <= 5),
		Comment NVARCHAR(MAX),
		DateCreated DATETIME DEFAULT GETDATE(),
		FOREIGN KEY (AccountId) REFERENCES Accounts(AccountId) ON DELETE CASCADE,
		FOREIGN KEY (BookId) REFERENCES Books(BookId) ON DELETE CASCADE
	);
END
GO

-- Holding off on discussions for now

-- Create the Discussions table
--IF NOT EXISTS (
--	SELECT * FROM INFORMATION_SCHEMA.TABLES
--	WHERE TABLE_SCHEMA = 'Discussions'
--	)
--BEGIN
--	CREATE TABLE Discussions (
--	);
--END
--GO

/*
 * Mock data generation for Accounts, Books, and Reviews
 */

-- Mock data for Accounts
INSERT INTO Accounts (FirstName, LastName, DateOfBirth, Email, Username, PasswordHash) VALUES
    ('Emma', 'Watkins', '1990-07-12', 'emma.watkins@mail.com', 'emmaw90', '5f4dcc3b5aa765d61d8327deb882cf99'),
    ('Liam', 'Nguyen', '1985-03-25', 'liam.nguyen@mail.com', 'liamng', 'e99a18c428cb38d5f260853678922e03'),
    ('Sophia', 'Lopez', '1993-11-08', 'sophia.lopez@mail.com', 'sophial', '6c569aabbf7775ef8fc570e228c16b98'),
    ('Noah', 'Bennett', '2000-01-15', 'noah.bennett@mail.com', 'noahb', '8d969eef6ecad3c29a3a629280e686cf'),
    ('Ava', 'Patel', '1997-05-30', 'ava.patel@mail.com', 'avap', 'b2e98ad6f6eb8508dd6a14cfa704bad7');
GO

-- Mock data for Books
INSERT INTO Books (Title, Author, BookDescription, ISBN, DatePublished) VALUES
    ('The Silent Library', 'Ava Miles', 'A suspenseful thriller set in an eerie town.', '9780451491234', '2015-06-15'),
    ('Gardens of Glass', 'Liam Frost', 'A poetic journey through forgotten landscapes.', '9780143110433', '2019-03-22'),
    ('Moonlight Archive', 'Elena Brook', 'A tale of lost civilizations and secret histories.', '9780670022450', '2021-11-10'),
    ('Echoes of Dust', 'Mason Quinn', 'A gritty sci-fi about survival on a dying planet.', '9780316095839', '2018-01-27'),
    ('Notes from the Attic', 'Harper Lee', 'Short stories and memories from a reclusive writer.', '9780061120084', '2007-09-05');
GO

-- Mock data for Reviews
-- Assuming AccountId values 1-5 and BookId values 1-5 from above
INSERT INTO Reviews (AccountId, BookId, Rating, Comment) VALUES
    (1, 1, 4, 'Really enjoyed the suspense and pacing.'),
    (2, 1, 5, 'An instant favorite. Couldn’t put it down!'),
    (3, 2, 3, 'Good writing, but not my genre.'),
    (4, 3, 4, 'Loved the historical depth.'),
    (5, 4, 2, 'Interesting premise, but slow in parts.'),
    (2, 5, 5, 'Beautifully written and moving.'),
    (1, 3, 4, 'Kept me engaged from start to finish.'),
    (3, 4, 5, 'Incredible worldbuilding and emotion.'),
    (4, 2, 3, 'Could use a stronger plot, but decent.'),
    (5, 5, 4, 'Great for a weekend read!');
GO
