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