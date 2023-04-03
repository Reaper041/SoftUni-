USE [Gringotts]

SELECT 
	MAX(wd.MagicWandSize) AS [LongestMagicWand]
FROM 
	WizzardDeposits AS wd

SELECT TOP(2)
	wd.DepositGroup
FROM 
	WizzardDeposits AS wd
GROUP BY
	wd.DepositGroup	
ORDER BY 
	AVG(wd.MagicWandSize)



SELECT
	wd.DepositGroup,
	SUM(wd.DepositAmount) AS [TotalDeposit]
FROM 
	WizzardDeposits AS wd
WHERE
	wd.MagicWandCreator = 'Ollivander family'
GROUP BY
	wd.DepositGroup, wd.MagicWandCreator


SELECT
	wd.DepositGroup,
	SUM(wd.DepositAmount) AS [TotalDeposit]
FROM 
	WizzardDeposits AS wd
WHERE
	wd.MagicWandCreator = 'Ollivander family'
GROUP BY
	wd.DepositGroup, wd.MagicWandCreator
HAVING 
	SUM(wd.DepositAmount) < 150000
ORDER BY 
	TotalDeposit DESC

SELECT 
	wd.DepositGroup, 
	wd.MagicWandCreator,
	MIN(wd.DepositCharge) AS [MinDepositCharge]
FROM
	WizzardDeposits AS wd
GROUP BY
	wd.DepositGroup, wd.MagicWandCreator
ORDER BY
	wd.MagicWandCreator, wd.DepositGroup

SELECT 
	ag.AgeGroups,
	COUNT(*)
FROM
	(
	SELECT 
		Age,
		CASE
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END
		AS [AgeGroups]
	FROM 
		WizzardDeposits AS wd
	) AS [ag]
GROUP BY
	ag.AgeGroups

SELECT 
	LEFT(wd.FirstName, 1) AS FirstLetterOfName
FROM 
	WizzardDeposits AS wd
WHERE 
	wd.DepositGroup = 'Troll Chest'
GROUP BY
	LEFT(wd.FirstName, 1)
ORDER BY	
	FirstLetterOfName

SELECT
	DepositGroup,
	IsDepositExpired,
	AVG(DepositInterest)
FROM
	WizzardDeposits AS wd
WHERE
	YEAR(wd.DepositStartDate) > '1984'
GROUP BY
	DepositGroup, wd.IsDepositExpired
ORDER BY 
	wd.DepositGroup DESC,
	wd.IsDepositExpired

USE [SoftUni]

SELECT
	DepartmentID,
	SUM(Salary)
FROM
	Employees
GROUP BY
	DepartmentID
ORDER BY 
	DepartmentID

SELECT
	DepartmentID,
	MIN(Salary)
FROM
	Employees
WHERE
	DepartmentID IN (2, 5, 7) AND YEAR(HireDate) > 1999
GROUP BY
	DepartmentID
ORDER BY 
	DepartmentID

SELECT
	DepartmentID,
	MAX(Salary)
FROM
	Employees
GROUP BY
	DepartmentID
HAVING
	MAX(Salary) < 30000 AND MAX(Salary) > 70000

SELECT
	COUNT(Salary)
FROM
	Employees
WHERE
	ManagerID IS NULL


SELECT 
	DepartmentID,
	MaxSalaries
FROM
	(
	SELECT
		DepartmentID,
		MAX(Salary) AS [MaxSalaries],
		RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank]
	FROM
		Employees
	GROUP BY
		DepartmentID, Salary

	) AS [RankedSalaries]
WHERE
	[Rank] = 3

