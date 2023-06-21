CREATE DATABASE [Accounting]

USE [Accounting]

CREATE TABLE Countries(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(10) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	StreetName NVARCHAR(20) NOT NULL,
	StreetNumber INT NOT NULL,
	PostCode INT NOT NULL,
	City VARCHAR(25) NOT NULL,
	CountryId INT NOT NULL REFERENCES Countries(Id)
)

CREATE TABLE Vendors(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(25) NOT NULL,
	NumberVAT NVARCHAR(15) NOT NULL,
	AddressId INT NOT NULL REFERENCES Addresses(Id)
)

CREATE TABLE Clients(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(25) NOT NULL,
	NumberVAT NVARCHAR(15) NOT NULL,
	AddressId INT NOT NULL REFERENCES Addresses(Id)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(10) NOT NULL
)

CREATE TABLE Products(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(35) NOT NULL,
	Price DECIMAL(18, 2) NOT NULL,
	CategoryId INT NOT NULL REFERENCES Categories(Id),
	VendorId INT NOT NULL REFERENCES Vendors(Id),

)

CREATE TABLE Invoices(
	Id INT PRIMARY KEY IDENTITY,
	Number INT UNIQUE NOT NULL,
	IssueDate DATETIME2 NOT NULL,
	DueDate DATETIME2 NOT NULL,
	Amount DECIMAL(18, 2) NOT NULL,
	Currency VARCHAR(5) NOT NULL,
	ClientId INT NOT NULL REFERENCES Clients(Id)
)

CREATE TABLE ProductsClients(
	ProductId INT NOT NULL REFERENCES Products(Id),
	ClientId INT NOT NULL REFERENCES Clients(Id),
	PRIMARY KEY(ProductId, ClientId)
)

GO

INSERT INTO Products(Name, Price, CategoryId, VendorId)
	VALUES
	('SCANIA Oil Filter XD01', 78.69, 1, 1),
	('MAN Air Filter XD01', 97.38, 1, 5),
	('DAF Light Bulb 05FG87', 55.00, 2, 13),
	('ADR Shoes 47-47.5', 49.85, 3, 5),
	('Anti-slip pads S', 5.87, 5, 7)


INSERT INTO Invoices(Number, IssueDate, DueDate, Amount, Currency, ClientId)
	VALUES
	(1219992181, '2023-03-01', '2023-04-30', 180.96, 'BGN', 3),
	(1729252340, '2022-11-06', '2023-01-04', 158.18, 'EUR', 13),
	(1950101013, '2023-02-17', '2023-04-18', 615.15, 'USD', 19)


UPDATE Invoices
SET DueDate = '2023-04-01'
WHERE MONTH(IssueDate) = 11 AND YEAR(IssueDate) = 2022

UPDATE Clients
SET AddressId = 3
WHERE Clients.Name LIKE '%CO%'


SELECT * FROM Clients WHERE Clients.NumberVAT LIKE 'IT%'
SELECT * FROM ProductsClients WHERE ClientId = 11
SELECT * FROM Invoices WHERE ClientId = 11

DELETE FROM Invoices WHERE ClientId = 11
DELETE FROM ProductsClients WHERE ClientId = 11
DELETE FROM Clients
WHERE Clients.NumberVAT LIKE 'IT%'

SELECT
	Number, Currency
FROM
	Invoices
ORDER BY
	Amount DESC,
	DueDate
	
SELECT
	p.Id, p.Name, p.Price, c.Name
FROM
	Products AS p
	JOIN Categories AS c ON p.CategoryId = c.Id
WHERE
	c.Name IN ('ADR', 'Others')
ORDER BY p.Price DESC


SELECT 
	c.Id, 
	c.Name, 
	CONCAT(a.StreetName, ' ', a.StreetNumber, ', ', a.City, ', ', a.PostCode, ', ', coun.Name)
FROM 
	Clients AS c
	LEFT JOIN ProductsClients AS pc ON c.Id = pc.ClientId
	LEFT JOIN Addresses AS a ON c.AddressId = a.Id
	LEFT JOIN Countries AS coun ON a.CountryId = coun.Id
WHERE
	pc.ProductId IS NULL
ORDER BY c.Name 

SELECT TOP(7)
	i.Number, i.Amount, c.Name
FROM
	Invoices AS i
	JOIN Clients AS c ON c.Id = i.ClientId
WHERE
	(YEAR(IssueDate) < 2023 AND Currency = 'EUR')
	OR (Amount > 500 AND c.NumberVAT LIKE 'DE%')
ORDER BY
	i.Number,
	i.Amount DESC

SELECT
	c.Name, MAX(p.Price), c.NumberVAT
FROM
	Clients AS c
	JOIN ProductsClients AS pc ON c.Id = pc.ClientId
	JOIN Products AS p ON pc.ProductId = p.Id
WHERE
	c.Name NOT LIKE '%KG'
GROUP BY
	c.Name, c.NumberVAT
ORDER BY
	MAX(p.Price) DESC

SELECT
	c.Name, FLOOR(AVG(p.Price))
FROM
	Clients AS c
	JOIN ProductsClients AS pc ON c.Id = pc.ClientId
	JOIN Products AS p ON pc.ProductId = p.Id
	JOIN Vendors AS v ON p.VendorId = v.Id
WHERE
	v.NumberVAT LIKE '%FR%'
GROUP BY
	c.Name
ORDER BY
	AVG(p.Price),
	c.Name DESC


GO

CREATE OR ALTER FUNCTION udf_ProductWithClients(@name VARCHAR(30)) 
RETURNS INT
BEGIN
	RETURN
	(
		SELECT
			COUNT(*)
		FROM
			Clients AS c
			JOIN ProductsClients AS pc ON pc.ClientId = c.Id
			JOIN Products AS p ON p.Id = pc.ProductId
		WHERE
			p.Name = @name
	)
END

GO

SELECT dbo.udf_ProductWithClients('DAF FILTER HU12103X')

GO

CREATE OR ALTER PROC usp_SearchByCountry @country VARCHAR(30)
AS
BEGIN
	SELECT
		v.Name,
		v.NumberVAT,
		CONCAT(a.StreetName, ' ', a.StreetNumber),
		CONCAT(a.City, ' ', a.PostCode)
	FROM
		Vendors AS v
		JOIN Addresses AS a ON v.AddressId = a.Id
		JOIN Countries AS c ON c.Id = a.CountryId
	WHERE
		c.Name = @country
	ORDER BY
		v.Name,
		a.City
END

GO

EXEC usp_SearchByCountry 'France'