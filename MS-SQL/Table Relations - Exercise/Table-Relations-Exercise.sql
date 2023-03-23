USE [Customs]

CREATE TABLE [Persons](
	[PersonID] INT IDENTITY(1,1),
	[FirstName] VARCHAR(20) NOT NULL,
	[Salary] DECIMAL(7,2) NOT NULL,
	[PassportID] VARCHAR(20) NOT NULL
)

CREATE TABLE [Passports](
	[PassportID] INT IDENTITY(101,1),
	[PassportNumber] VARCHAR(20) NOT NULL
)

ALTER TABLE [Persons]
ADD CONSTRAINT [PK_Persons] PRIMARY KEY (PersonID)

ALTER TABLE [Passports]
ADD CONSTRAINT [PK_Passports] PRIMARY KEY ([PassportID])


INSERT INTO [Passports](PassportNumber)
	VALUES 
	('N34FG21B'),
	('K65LO4R7'),
	('ZE657QP2')

ALTER TABLE [Persons]
ALTER COLUMN PassportID INT NOT NULL

ALTER TABLE [Persons]
ADD CONSTRAINT [FK_PassportID] 
FOREIGN KEY ([PassportID]) REFERENCES Passports([PassportID]) 

INSERT INTO [Persons](FirstName, Salary, PassportID)
	VALUES
	('Roberto', 43300, 102),
	('Tom', 56100, 103),
	('Yana', 60200, 101)
	

ALTER DATABASE Customs SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
ALTER DATABASE Customs MODIFY NAME = [Table_Relations_DB];
GO  
ALTER DATABASE [Table_Relations_DB] SET MULTI_USER;
GO

USE Table_Relations_DB

CREATE TABLE [Models](
	[ModelID] INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(20) NOT NULL,
	[ManufacturerID] INT 
)

CREATE TABLE [Manufacturers](
	[ManufacturerID] INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(20) NOT NULL,
	[EstablishedOn] DATETIME2
)

INSERT INTO Manufacturers([Name], [EstablishedOn])
	VALUES
	('BMW', '07/03/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '01/05/1966')

ALTER TABLE Models
ADD CONSTRAINT [FK_ManufacturerID] 
FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers([ManufacturerID])

INSERT INTO Models([Name], ManufacturerID)
	VALUES
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
	('Nova', 3)

CREATE TABLE [Students](
	[StudentID] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE [Exams](
	[ExamID] INT IDENTITY(101,1) PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE [StudentsExams](
	[StudentID] INT,
	[ExamID] INT,
	PRIMARY KEY([StudentID], [ExamID])
)

INSERT INTO [Students]([Name])
	VALUES
	('Mila'),
	('Toni'),
	('Ron')

INSERT INTO [Exams]([Name])
	VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

ALTER TABLE [StudentsExams]
ADD CONSTRAINT [FK_StudentID] 
FOREIGN KEY (StudentID) REFERENCES Students([StudentID])

ALTER TABLE [StudentsExams]
ADD CONSTRAINT [FK_ExamID] 
FOREIGN KEY (ExamID) REFERENCES Exams([ExamID])

INSERT INTO StudentsExams(StudentID, ExamID)
	VALUES
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)


CREATE TABLE [Teachers](
	[TeacherID] INT IDENTITY(101, 1) PRIMARY KEY,
	[NAME] NVARCHAR(30),
	[ManagerID] INT FOREIGN KEY REFERENCES [Teachers]([TeacherID])
)

INSERT INTO [Teachers]([Name], [ManagerID])
	VALUES
	('John', NULL),
	('Maya', 106),
	('Silvia', 106),
	('Ted', 105),
	('Mark', 101),
	('Greta', 101)

CREATE DATABASE [OnlineStore]

USE [OnlineStore]

CREATE TABLE [Cities](
	[CityID] INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(30)
)

CREATE TABLE [Customers](
	[CustomerID] INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(30),
	[Birthday] DATETIME2,
	[CityID] INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE [Orders](
	[OrderID] INT IDENTITY(1, 1) PRIMARY KEY,
	[CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID])
)

CREATE TABLE [ItemTypes](
	[ItemTypeID] INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(30)
)

CREATE TABLE [Items](
	[ItemID] INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(30),
	[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID])
)

CREATE TABLE [OrderItems](
	[OrderID] INT,
	[ItemID] INT,
	PRIMARY KEY(OrderID, ItemID),
)

ALTER TABLE [OrderItems]
ADD CONSTRAINT [FK_OrderID]
FOREIGN KEY (OrderID) REFERENCES [Orders]([OrderID])

ALTER TABLE [OrderItems]
ADD CONSTRAINT [FK_ItemID]
FOREIGN KEY (ItemID) REFERENCES [Items]([ItemID])

USE [Geography]

