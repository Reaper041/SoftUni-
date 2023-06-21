CREATE DATABASE [Minions]

USE Minions

GO

CREATE TABLE [Minions](
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT NOT NULL
)

GO

CREATE TABLE [Towns](
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50)
)

GO

ALTER TABLE [Minions] 
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id])

GO

INSERT INTO [Towns]([Id], [Name])
	VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')

GO

ALTER TABLE [Minions]
ALTER COLUMN [Age] INT

GO

INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
	VALUES
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2)

GO

TRUNCATE TABLE [Minions]

DROP TABLE [Minions]
DROP TABLE [Towns]


CREATE TABLE [People](
	[Id] INT IDENTITY(1,1) PRIMARY KEY ,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	[Gender] CHAR(1) CHECK ([Gender] = 'm' OR [Gender] = 'f') NOT NULL,
	[Birthdate] DATETIME2 NOT NULL,
	[Biography] NVARCHAR 
)

GO

INSERT INTO [People]([Name], [Height], [Weight], [Gender], [Birthdate])
	VALUES
	('Mitko', 1.75, 62.5, 'm', '2004-02-10'),
	('Stefka', 1.34, 67.5, 'f', '2004-02-10'),
	('Sasho', 1.62, 76.5, 'm', '2004-02-10'),
	('Zdravko', 1.83, 96.5, 'm', '2004-02-10'),
	('Emo', 1.63, 58.5, 'm', '2004-02-10')

GO

CREATE TABLE [Users](
	[Id] BIGINT IDENTITY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY 
	CHECK (DATALENGTH(ProfilePicture) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT 

	CONSTRAINT PK_PrimaryKey PRIMARY KEY(Id)
)

GO

INSERT INTO [Users]([Username], [Password], [IsDeleted])
	VALUES
	('test1', '12345678', 0),
	('test12', '1234567', 1),
	('test123', '123456', 1),
	('test1234', '12345', 1),
	('test12345', '12345', 0)

GO


ALTER TABLE [Users]
DROP PK_PrimaryKey
ALTER TABLE [Users]
ADD PRIMARY KEY ([Id], [Username])

GO

ALTER TABLE [Users]
ADD CONSTRAINT CK_AtLeast5Symbols CHECK(DATALENGTH(Password) >= 5)

GO

ALTER TABLE [Users]
ADD CONSTRAINT DF_DefaultValue DEFAULT GETDATE() FOR [LastLoginTime]

CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[DirectorName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR
)

GO

CREATE TABLE [Genres](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR
)

GO

CREATE TABLE [Categories](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR
)

GO

CREATE TABLE [Movies](
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Title] NVARCHAR(100) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]),
	[CopyrightYear] DATETIME2 NOT NULL,
	[Length] INT NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]),
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]),
	[Rating] DECIMAL(2, 1) NOT NULL,
	[Notes] NVARCHAR
)

GO

INSERT INTO [Directors]([DirectorName])
	VALUES
	('Stephen King'),
	('Zhoro Ignatov'),
	('Stephen Hoking'),
	('Boris Dali'),
	('Slavi Trifonov')

GO

INSERT INTO [Genres]([GenreName])
	VALUES
	('Horror'),
	('Comedy'),
	('Documental'),
	('Sci-fi'),
	('Action')

GO

INSERT INTO [Categories]([CategoryName])
	VALUES
	('Pets'),
	('Adventure'),
	('Books'),
	('Battle'),
	('Russia')

GO

INSERT INTO [Movies]([Title], [CopyrightYear], [Length], [Rating])
	VALUES
	('Title1', '2022-02-02', 124, 7.8),
	('Title2', '1999-02-02', 98, 4.6),
	('Title3', '1967-02-02', 134, 9.9),
	('Title4', '2004-02-02', 57, 4.5),
	('Title5', '2011-02-02', 160, 7.9)

	GO

CREATE DATABASE [CarRental]

USE [CarRental]

GO
	 
CREATE TABLE [Categories](
	[Id] INT IDENTITY PRIMARY KEY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[DailyRate] INT NOT NULL,
	[WeeklyRate] INT NOT NULL,
	[MonthlyRate] INT NOT NULL,
	[WeekendRate] INT NOT NULL

)

GO

CREATE TABLE [Cars](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[PlateNumber] NVARCHAR(8) NOT NULL,
	[Manufacturer] NVARCHAR(50) NOT NULL,
	[Model] NVARCHAR(50) NOT NULL,
	[CarYear] DATETIME2 NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]),
	[Doors] SMALLINT NOT NULL,
	[Picture] VARBINARY,
	[Condition] NVARCHAR(50) NOT NULL,
	[Available] BIT NOT NULL
)

GO

CREATE TABLE [Employees](
	[Id] INT IDENTITY PRIMARY KEY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Title] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR
)

GO

CREATE TABLE [Customers](
	[Id] INT IDENTITY PRIMARY KEY,
	[DriverLicenceNumber] NVARCHAR(20) NOT NULL,
	[FullName] NVARCHAR(200) NOT NULL,
	[Address] NVARCHAR(50) NOT NULL,
	[City] NVARCHAR(50) NOT NULL,
	[ZipCode] NVARCHAR(10) NOT NULL,
	[Notes] NVARCHAR
)

GO

CREATE TABLE [RentalOrders](
	[Id] INT IDENTITY PRIMARY KEY, 
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]),
	[CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]),
	[TankLevel] INT NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] INT NOT NULL,
	[StartDate] DATETIME2 NOT NULL,
	[EndDate] DATETIME2 NOT NULL,
	[TotalDays] INT NOT NULL,
	[RateApplied] BIT NOT NULL,
	[TaxRate] INT NOT NULL,
	[OrderStatus] NVARCHAR NOT NULL,
	[Notes] NVARCHAR
)

GO

INSERT INTO [Categories]([CategoryName], [DailyRate], 
						[WeeklyRate], [MonthlyRate], [WeekendRate])
	VALUES
	('Sport', 14, 51, 12, 54),
	('OffRoad', 14, 51, 12, 54),
	('Supercar', 14, 51, 12, 54)

GO

INSERT INTO [Cars]([PlateNumber], [Manufacturer], [Model], 
					[CarYear], [CategoryId], [Doors],
					[Condition], [Available])
	VALUES
	('ยา5229สฬ', 'Opel', 'Zafira', '2008-02-02', 1, 4, 'Brand New', 1),
	('ยา5229สฬ', 'Opel', 'Zafira', '2008-02-02', 1, 4, 'Brand New', 1),
	('ยา5229สฬ', 'Opel', 'Zafira', '2008-02-02', 1, 4, 'Brand New', 1)

GO

INSERT INTO [Employees]([FirstName], [Lastname], [Title])
	VALUES
	('Slavi', 'Dimitrov', 'Title'),
	('Slavi1', 'Dimitrov1', 'Title1'),
	('Slavi2', 'Dimitrov2', 'Title2')

GO

INSERT INTO [Customers]([DriverLicenceNumber], [FullName], 
						[Address], [City], [ZIPCode])
	VALUES
	('0442104121', 'Dimitar Kalinov Dimitrov', 'Chakarov 4', 'Svishtov', '5250'),
	('044210412', 'Dimitar Kalinov Dimitrov1', 'Chakarov 41', 'Svishtov1', '5250'),
	('04421041', 'Dimitar Kalinov Dimitrov1', 'Chakarov 42', 'Svishtov', '5250')


GO

INSERT INTO [RentalOrders]([EmployeeId], [CustomerId], [CarId], 
							[TankLevel], [KilometrageStart], [KilometrageEnd], 
							[TotalKilometrage], [StartDate], [EndDate], 
							[TotalDays], [RateApplied], [TaxRate], [OrderStatus])
	VALUES
	(1, 1, 3, 8, 0, 260, 0, '2000-01-01', '2000-01-07', 7, 1, 20, 1),
	(1, 1, 3, 8, 0, 260, 0, '2000-01-01', '2000-01-07', 7, 1, 20, 1),
	(1, 1, 3, 8, 0, 260, 0, '2000-01-01', '2000-01-07', 7, 1, 20, 1)

GO

CREATE DATABASE [SoftUni]

USE [SoftUni]

GO

CREATE TABLE [Towns](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

GO

CREATE TABLE [Addresses](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[AddressText] NVARCHAR NOT NULL,
	[TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL
)

GO

CREATE TABLE [Departments](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

GO

CREATE TABLE [Employees](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[MiddleName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[JobTitle] NVARCHAR(50) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]),
	[HireDate] DATETIME2 NOT NULL,
	[Salary] DECIMAL NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id])
)

GO

INSERT INTO [Towns]([Name])
	VALUES
	('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')

GO

INSERT INTO [Departments]([Name])
	VALUES
	('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance')

GO

INSERT INTO [Employees]([FirstName], [MiddleName], [LastName], 
			[JobTitle], [DepartmentId], [HireDate], [Salary])
	VALUES
	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
	('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
	('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
	('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)

GO

SELECT * 
FROM [Towns]

SELECT *
FROM [Departments]

SELECT *
FROM [Employees]

GO

SELECT * 
FROM [Towns]
ORDER BY ([Name])

SELECT * 
FROM [Departments]
ORDER BY ([Name])

SELECT * 
FROM [Employees]
ORDER BY [Salary] DESC

GO

SELECT [Name]
FROM [Towns]
ORDER BY ([Name])

SELECT [Name]
FROM [Departments]
ORDER BY ([Name])

SELECT [FirstName], [LastName], [JobTitle], [Salary]
FROM [Employees]
ORDER BY [Salary] DESC

GO

SELECT [Salary] + ([Salary] * 0.1)
FROM [Employees]

GO

