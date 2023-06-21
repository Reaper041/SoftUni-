USE [SoftUni]

SELECT TOP(5)
	e.EmployeeID,
	e.JobTitle,
	e.AddressID,
	a.AddressText
FROM
	[Employees] AS [e] 
	JOIN [Addresses] AS [a] ON e.AddressID = a.AddressID
ORDER BY
	e.AddressID

SELECT TOP(50)
	FirstName,
	LastName,
	t.[Name],
	a.AddressText
FROM
	Employees AS e
	JOIN [Addresses] AS a ON e.AddressID = a.AddressID
	JOIN [Towns] AS t ON a.TownID = t.TownID
ORDER BY
	FirstName,
	LastName

SELECT
	e.EmployeeID,
	FirstName,
	LastName,
	d.[Name]
FROM
	Employees AS e
	JOIN [Departments] AS d ON e.DepartmentID = d.DepartmentID AND d.[Name] = 'Sales'
ORDER BY
	e.EmployeeID


SELECT TOP(5)
	e.EmployeeID,
	FirstName,
	e.Salary,
	d.[Name]
FROM
	Employees AS e
	JOIN [Departments] AS d ON e.DepartmentID = d.DepartmentID 
WHERE
	e.Salary >= 15000
ORDER BY
	d.DepartmentID

SELECT TOP(3)
	e.EmployeeID,
	e.FirstName
FROM
	Employees AS e
	LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE
	ep.EmployeeID IS NULL
ORDER BY 
	e.EmployeeID

SELECT
	e.FirstName,
	e.LastName,
	e.HireDate,
	d.[Name]
FROM
	Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID AND d.[Name] IN ('Sales', 'Finance')
WHERE 
	YEAR(e.HireDate) > 1998
ORDER BY
	HireDate

SELECT TOP(5)
	e.EmployeeID,
	e.FirstName,
	p.[Name]
FROM
	Employees AS e
	JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE
	p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY
	e.EmployeeID

SELECT
	e.EmployeeID,
	e.FirstName,
	CASE 
		WHEN YEAR(p.StartDate) >= 2005 THEN NULL
		ELSE p.[Name]
	END
FROM
	Employees AS e
	JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE
	e.EmployeeID = 24

SELECT
	e.EmployeeID,
	e.FirstName,
	m.EmployeeID,
	m.FirstName
FROM
	Employees AS e
	JOIN Employees AS m ON e.ManagerID = m.EmployeeID AND m.EmployeeID IN (3, 7)
ORDER BY
	e.EmployeeID

SELECT TOP(50)
	e.EmployeeID,
	CONCAT(e.FirstName, ' ', e.LastName),
	CONCAT(m.FirstName, ' ', m.LastName),
	d.[Name]
FROM
	Employees AS e
	JOIN Employees AS m ON e.ManagerID = m.EmployeeID
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY 
	e.EmployeeID


SELECT TOP(1)
	AVG(Salary) AS [avg]
FROM
	Employees
GROUP BY
	DepartmentID
ORDER BY 
	[avg]

USE [Geography]

SELECT 
	mc.CountryCode,
	m.MountainRange,
	p.PeakName,
	p.Elevation
FROM
	Peaks AS p
	JOIN Mountains AS m ON p.MountainId = m.Id AND p.Elevation > 2835
	JOIN MountainsCountries AS mc ON m.Id = mc.MountainId AND mc.CountryCode = 'BG'
ORDER BY
	p.Elevation DESC

SELECT
	CountryCode,
	COUNT(m.MountainRange)
FROM
	MountainsCountries AS mc
	JOIN Mountains AS m ON mc.MountainId = m.Id
WHERE
	mc.CountryCode IN ('RU', 'BG', 'US')
GROUP BY
	CountryCode


SELECT TOP(5)
	c.CountryName,
	r.RiverName
FROM
	Countries AS c
	LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
	JOIN Continents AS cont ON cont.ContinentCode = c.ContinentCode AND cont.ContinentName = 'Africa'
ORDER BY 
	c.CountryName



SELECT
	COUNT(*)
FROM
	Countries AS c
	FULL JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE
	mc.MountainId IS NULL

SELECT TOP(5)
	c.CountryName,
	MAX(p.Elevation) AS [MaxElevation],
	MAX(r.[Length]) AS [MaxLength]
FROM
	Countries AS c
	LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
	LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
	LEFT JOIN Peaks AS p ON p.MountainId = m.Id
GROUP BY c.CountryName
ORDER BY 
	[MaxElevation] DESC,
	[MaxLength] DESC,
	c.CountryName