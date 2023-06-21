CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	StreetName NVARCHAR(100) NOT NULL,
	StreetNumber INT NOT NULL,
	Town VARCHAR(30) NOT NULL,
	Country VARCHAR(50) NOT NULL,
	ZIP INT NOT NULL
)

CREATE TABLE Publishers(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) UNIQUE NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL,
	Website NVARCHAR(40),
	Phone NVARCHAR(20)
)

CREATE TABLE PlayersRanges(
	Id INT PRIMARY KEY IDENTITY,
	PlayersMin INT NOT NULL,
	PlayersMax INT NOT NULL
)

CREATE TABLE Boardgames(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	YearPublished INT NOT NULL,
	Rating DECIMAL(10, 2) NOT NULL,
	CategoryId INT REFERENCES Categories(Id) NOT NULL,
	PublisherId INT REFERENCES Publishers(Id) NOT NULL,
	PlayersRangeId INT REFERENCES PlayersRanges(Id) NOT NULL
)

CREATE TABLE Creators(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(30) NOT NULL
)

CREATE TABLE CreatorsBoardgames(
	CreatorId INT REFERENCES Creators(Id) NOT NULL,
	BoardgameId INT REFERENCES Boardgames(Id) NOT NULL,
	PRIMARY KEY (CreatorId, BoardgameId)
)

INSERT INTO Boardgames(Name, YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId)
	VALUES
	('Deep Blue', 2019, 5.67, 1, 15, 7),
	('Paris', 2016, 9.78, 7, 1, 5),
	('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
	('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
	('One Small Step', 2019, 5.75, 5, 9, 2)

INSERT INTO Publishers(Name, AddressId, Website, Phone)
	VALUES
	('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
	('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
	('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')


UPDATE PlayersRanges
SET PlayersMax = 3
WHERE PlayersMin = 2 AND PlayersMax = 2

UPDATE Boardgames
SET Name = CONCAT(Name, 'V2')
WHERE Boardgames.YearPublished >=2020

SELECT * FROM Addresses WHERE LEFT(Town, 1) = 'L'
SELECT * FROM Publishers WHERE AddressId = 5
SELECT * FROM Boardgames WHERE PublisherId IN (1, 16)

DELETE FROM CreatorsBoardgames WHERE BoardgameId IN (1, 16, 31, 47)
DELETE FROM Boardgames WHERE PublisherId IN (1, 16)
DELETE FROM Publishers WHERE AddressId = 5
DELETE FROM Addresses WHERE LEFT(Town, 1) = 'L'

GO

SELECT 
	Name,
	Rating
FROM
	Boardgames
ORDER BY
	YearPublished,
	Name DESC

SELECT
	bg.Id, 
	bg.[Name], 
	YearPublished, 
	c.Name
FROM
	Boardgames AS bg
	JOIN Categories AS c ON bg.CategoryId = c.Id
WHERE
	c.Name IN ('Strategy Games', 'Wargames')
ORDER BY
	bg.YearPublished DESC

SELECT
	c.Id,
	CONCAT(c.FirstName, ' ', c.LastName),
	c.Email
FROM
	Creators AS c
	LEFT JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
	LEFT JOIN Boardgames AS b ON cb.BoardgameId = b.Id
WHERE
	b.Name IS NULL

SELECT TOP(5)
	b.Name,
	b.Rating,
	c.Name
FROM
	Boardgames AS b
	JOIN PlayersRanges AS pr ON b.PlayersRangeId = pr.Id
	JOIN Categories AS c ON c.Id = b.CategoryId
WHERE
	(b.Rating > 7 AND b.Name LIKE '%a%')
	OR (b.Rating > 7.5 AND pr.PlayersMin = 2 AND pr.PlayersMax = 5)
ORDER BY 
	b.Name,
	b.Rating DESC

SELECT
	FullName,
	Email,
	Rating
FROM
	(
	SELECT
		CONCAT(c.FirstName, ' ', c.LastName) AS [FullName], 
		c.Email AS Email,
		b.Rating AS Rating,
		RANK() OVER(PARTITION BY c.FirstName ORDER BY Rating DESC) AS [Rank]
	FROM 
		Creators AS c
		JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
		JOIN Boardgames AS b ON cb.BoardgameId = b.Id
	WHERE
		Email LIKE '%.com'
	) AS CreatorsRanked
WHERE
	CreatorsRanked.Rank = 1
ORDER BY
	FullName

SELECT * FROM Creators

SELECT 
	c.LastName,
	CEILING(AVG(b.Rating)) AS AverageRating,
	p.Name
FROM
	Creators AS c
	JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
	JOIN Boardgames AS b ON cb.BoardgameId = b.Id
	JOIN Publishers AS p ON b.PublisherId = p.Id
WHERE
	p.Name = 'Stonemaier Games'
GROUP BY
	c.LastName, p.Name
ORDER BY 
	AVG(b.Rating) DESC

GO

CREATE OR ALTER FUNCTION udf_CreatorWithBoardgames(@name VARCHAR(30)) 
RETURNS INT
BEGIN
	DECLARE @result INT

	SET @result =
	(
		SELECT 
		COUNT(*) 
		FROM 
			CreatorsBoardgames AS cb 
			JOIN Creators AS c ON c.Id = cb.CreatorId
		WHERE 
			c.FirstName = @name
	)

	RETURN @result

END

GO

SELECT dbo.udf_CreatorWithBoardgames('Bruno')

GO

CREATE OR ALTER PROC usp_SearchByCategory @category VARCHAR(30)
AS
SELECT
	b.Name,
	b.YearPublished,
	b.Rating,
	c.Name,
	p.Name,
	CONCAT(pr.PlayersMin, ' people'),
	CONCAT(pr.PlayersMax, ' people')
FROM
	Boardgames AS b
	JOIN Categories AS c ON b.CategoryId = c.Id
	JOIN Publishers AS p ON b.PublisherId = p.Id
	JOIN PlayersRanges AS pr ON b.PlayersRangeId = pr.Id
WHERE
	c.Name = @category
ORDER BY
	p.Name,
	b.YearPublished DESC

GO

EXEC usp_SearchByCategory 'Wargames'