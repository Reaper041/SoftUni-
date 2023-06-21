CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS
SELECT
	FirstName,
	LastName
FROM
	Employees
WHERE
	Salary > 35000

GO

CREATE PROC usp_GetEmployeesSalaryAboveNumber 
		@number DECIMAL(18,4)
AS
SELECT 
	Firstname,
	LastName
FROM 
	Employees
WHERE
	Salary >= @number

GO

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 48100

GO

CREATE PROC usp_GetTownsStartingWith 
		@letter VARCHAR(10)
AS
SELECT 
	[Name]
FROM 
	Towns
WHERE
	LEFT([Name], 1) = @letter

GO

EXEC usp_GetTownsStartingWith 'b'

GO

CREATE PROC usp_GetEmployeesFromTown 
		@townName VARCHAR(20)
AS
SELECT
	FirstName,
	LastName
FROM
	Employees AS e
	JOIN Addresses AS a ON a.AddressID = e.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
WHERE
	t.[Name] = @townName

GO

EXEC usp_GetEmployeesFromTown 'Sofia'

GO

CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(8)
AS
BEGIN
	DECLARE @result VARCHAR(8)
	SET @result = 'High'

	IF (@salary < 30000)
	SET @result = 'Low'
	ELSE IF (@salary <= 50000)
	SET @result = 'Average'

	RETURN @result
END

GO

SELECT dbo.ufn_GetSalaryLevel(13500.00)

GO

CREATE OR ALTER PROC usp_EmployeesBySalaryLevel 
		@levelOfSalary VARCHAR(8)
AS
SELECT
	FirstName, LastName
FROM
	Employees
WHERE
	dbo.ufn_GetSalaryLevel(Salary) = @levelOfSalary

GO

EXEC usp_EmployeesBySalaryLevel 'High'

GO

CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(30), 
											 @word VARCHAR (30)) 
RETURNS INT
AS
BEGIN
	DECLARE @result INT = 1

	DECLARE @cntWord INT = 1;

	WHILE @cntWord <= LEN(@word)
	BEGIN
	   DECLARE @cnt INT = 1;

	   DECLARE @resultLetter INT = 0
	   WHILE @cnt <= LEN(@setOfLetters)
	   BEGIN
			IF SUBSTRING(@word, @cntWord, 1) = SUBSTRING(@setOfLetters, @cnt, 1)
			BEGIN
			SET @resultLetter = 1
			END

			SET @cnt = @cnt + 1;
	   END
	   
	   IF @resultLetter = 0
	   BEGIN
	   SET @result = 0
	   END

	   SET @cntWord = @cntWord + 1;
	END;

	RETURN @result
END

GO

SELECT dbo.ufn_IsWordComprised('bobr', 'Rob')

GO

CREATE OR ALTER PROC usp_DeleteEmployeesFromDepartment 
					@departmentId INT
AS
DELETE
FROM Employees
WHERE Employees.DepartmentID = @departmentId 
DELETE 
FROM Departments
WHERE Departments.DepartmentID = @departmentId
SELECT 
COUNT(DepartmentID)
FROM Employees
WHERE DepartmentID = @departmentId
GROUP BY DepartmentID

GO

EXEC usp_DeleteEmployeesFromDepartment 1

GO

CREATE PROC usp_GetHoldersFullName 
AS
SELECT 
	CONCAT(FirstName, ' ', LastName)
FROM
	AccountHolders

GO

CREATE OR ALTER FUNCTION ufn_CalculateFutureValue
			(@sum DECIMAL, @yearlyInterestRate FLOAT, @numOfYears INT)
RETURNS DECIMAL(20, 4)
BEGIN
	DECLARE @result DECIMAL(20, 4);
	SET @result = @sum * POWER((1 + @yearlyInterestRate), @numOfYears)

	RETURN @result
END

GO

SELECT dbo.ufn_CalculateFutureValue(1000.21, 0.02, 1)