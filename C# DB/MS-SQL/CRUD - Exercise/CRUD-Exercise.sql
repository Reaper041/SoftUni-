USE [SoftUni]

SELECT *
FROM [Departments]

SELECT 
	[FirstName]
	,[MiddleName]
	,[LastName]
FROM [Employees]

SELECT 
	CONCAT([FirstName], '.', [LastName], '@softuni.bg') 
AS [Full Email Address]
FROM [Employees]

SELECT DISTINCT
	[Salary] AS [Salary]
FROM
	[Employees]

SELECT 
	*
FROM
	[Employees]
WHERE 
	[JobTitle] = 'Sales Representative'

SELECT 
	[FirstName], [LastName], [JobTitle]
FROM
	[Employees]
WHERE 
	Salary 
	BETWEEN 20000
	AND 30000

SELECT 
	CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) AS [Full Name]
FROM
	[Employees]
WHERE
	Salary IN(25000, 14000, 12500, 23600)

SELECT 
	[FirstName], [LastName]
FROM
	[Employees]
WHERE
	[ManagerID] IS NULL

SELECT
	[FirstName], [LastName]
FROM
	[Employees]
WHERE
	NOT [DepartmentID] = 4

SELECT
	*
FROM
	[Employees]
ORDER BY
	Salary DESC
	,FirstName ASC
	,LastName DESC
	,MiddleName ASC

CREATE VIEW [V_EmployeesSalaries] AS
SELECT
	[FirstName], [LastName], [Salary]
FROM [Employees]


CREATE VIEW [V_EmployeeNameJobTitle] AS
SELECT
	CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) AS [Full Name]
	,[JobTitle]
FROM [Employees]


SELECT DISTINCT
	[JobTitle]
FROM
	[Employees]

SELECT TOP(10)
	*
FROM
	[Projects]
ORDER BY StartDate, [Name]


SELECT TOP(7)
	[FirstName], [LastName], [HireDate]
FROM
	[Employees]
ORDER BY [HireDate] DESC

UPDATE 
	[Employees]
SET 
	[Salary] = [Salary] + [Salary] * 0.12
WHERE
	DepartmentID IN(1, 2, 4, 11)

SELECT [Salary]
FROM [Employees]

USE [Geography]

SELECT [PeakName] 
FROM [Peaks]
ORDER BY PeakName 

SELECT TOP(30)
	[CountryName], [Population]
FROM 
	[Countries]
WHERE 
	ContinentCode = 'EU'
ORDER BY
	[Population] DESC
	,[CountryName] ASC

SELECT
	[CountryName]
	,[CountryCode]
	,CASE
		WHEN CurrencyCode = 'EUR' THEN 'Euro'
		ELSE 'Not Euro'
	END AS [Currency]
FROM
	[Countries]
ORDER BY
	[CountryName]


USE [Diablo]

SELECT [Name] 
FROM [Characters]
ORDER BY [Name]