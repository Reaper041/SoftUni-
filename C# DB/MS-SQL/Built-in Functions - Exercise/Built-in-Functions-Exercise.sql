SELECT 
	FirstName, LastName
FROM
	Employees
WHERE
	FirstName LIKE 'Sa%'

SELECT 
	FirstName, LastName
FROM
	Employees
WHERE
	LastName LIKE '%ei%'

SELECT 
	FirstName
FROM 
	Employees AS e
WHERE 
	e.DepartmentID = 3 OR e.DepartmentID = 10
	AND e.HireDate BETWEEN '01-01-1995' AND '01-01-2005'

SELECT 
	FirstName, LastName
FROM 
	Employees AS e
WHERE 
	e.JobTitle NOT LIKE '%engineer%'

SELECT 
	TownID, [Name]
FROM 
	Towns AS t
WHERE 
	t.[Name] LIKE '[M,K,B,E]%'
ORDER BY 
	t.[Name]

SELECT 
	[Name]
FROM 
	Towns AS t
WHERE 
	LEN(t.[Name]) = 6 OR LEN(t.[Name]) = 5
ORDER BY 
	t.[Name]

SELECT 
	TownID, [Name]
FROM 
	Towns AS t
WHERE 
	t.[Name] NOT LIKE '[R,B,D]%'
ORDER BY 
	t.[Name]

CREATE VIEW [V_EmployeesHiredAfter2000] AS 
SELECT
	FirstName, LastName
FROM 
	Employees AS e
WHERE
	e.HireDate > '01/01/2000'

SELECT
	FirstName, LastName
FROM 
	Employees AS e
WHERE
	LEN(e.LastName) = 5

CREATE VIEW [v_DenseRankEmployees] AS
SELECT
	e.EmployeeID, 
	e.FirstName, 
	e.LastName, 
	e.Salary, 
	DENSE_RANK () OVER (
		PARTITION BY Salary
		ORDER BY e.EmployeeID 
	) AS [Rank]
FROM 
	Employees AS e
WHERE
	e.Salary BETWEEN 10000 AND 50000
ORDER BY 
	e.Salary DESC


SELECT
	*
FROM 
	v_DenseRankEmployees
WHERE 
	[Rank] = 2
ORDER BY
	Salary DESC

USE [Geography]

SELECT
	c.CountryName, c.IsoCode
FROM
	Countries AS c
WHERE
	c.CountryName LIKE '%a%a%a%'
ORDER BY 
	c.IsoCode 

SELECT 
	p.PeakName
	,r.RiverName
	,LOWER(CONCAT(p.PeakName, SUBSTRING(r.RiverName, 2, LEN(r.RiverName) - 1))) AS [Mix]
FROM
	[Peaks] AS [p],
	[Rivers] AS [r]
WHERE
	RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY 
	Mix

USE [Diablo]

SELECT TOP(50)
	g.[Name]
	,CONVERT(VARCHAR, g.[Start], 23) AS [StartDate]
FROM
	[Games] AS [g]
WHERE 
	YEAR(g.[Start]) IN (2011, 2012)
ORDER BY
	g.[Start],
	g.[Name]

GO

SELECT
	u.Username
	,u.Email
	,SUBSTRING(u.Email, CHARINDEX('@', u.Email) + 1, LEN(u.Email)) AS [Email Provider]
FROM
	[Users] AS [u]
ORDER BY
	[Email Provider]
	,u.Username

SELECT
	u.Username
	,u.IpAddress
FROM
	[Users] AS [u]
WHERE
	u.IpAddress LIKE '___.1%.%.___'
ORDER BY
	u.Username

GO

SELECT
	g.[Name]
	,CASE
		WHEN DATEPART(HOUR, g.[Start]) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN DATEPART(HOUR, g.[Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
		WHEN DATEPART(HOUR, g.[Start]) BETWEEN 18 AND 24 THEN 'Evening'
	END AS [PartOfTheDay]
	,CASE
		WHEN g.Duration <= 3 THEN 'Extra Short'
		WHEN g.Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN g.Duration > 6 THEN 'Long'
		ELSE  'Extra Long'
	END AS [Duration]
FROM 
	[Games] AS [g]
ORDER BY
	g.[Name]
	,[Duration]
	,[PartOfTheDay]


