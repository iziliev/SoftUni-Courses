--Part I – Queries for SoftUni Database

USE [SoftUni]

--Problem 1. Employees with Salary Above 35000

GO

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT [FirstName]
		  ,[LastName]
		FROM [Employees]
		WHERE [Salary] > 35000
END

EXEC usp_GetEmployeesSalaryAbove35000

GO
--Problem 2.Employees with Salary Above Number

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@salary DECIMAL(18,4))
AS
BEGIN
	SELECT
		[FirstName]
		,[LastName]
		FROM [Employees]
		WHERE [Salary] >=@salary
END

EXEC usp_GetEmployeesSalaryAboveNumber 70000

GO

--Problem 3. Town Names Starting With

CREATE PROCEDURE usp_GetTownsStartingWith (@pattern NVARCHAR(50))
AS
BEGIN
	SELECT 
		[Name]
		FROM [Towns]
		WHERE LEFT([Name],LEN(@pattern)) = @pattern
END

EXEC usp_GetTownsStartingWith 'b'

GO

--Problem 4. Employees from Town

CREATE PROCEDURE usp_GetEmployeesFromTown(@townName VARCHAR(50))
AS
BEGIN
	SELECT
		e.[FirstName]
		,e.[LastName]
		FROM [Employees] AS e
		JOIN [Addresses] AS a ON e.[AddressID]=a.[AddressID]
		JOIN [Towns] AS t ON a.[TownID]=t.[TownID]
		WHERE t.[Name] = @townName
END

EXEC usp_GetEmployeesFromTown 'Sofia'

GO

--Problem 5. Salary Level Function

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS
BEGIN
	IF @salary < 30000 RETURN 'Low'
	ELSE IF @salary BETWEEN 30000 AND 50000 RETURN 'Average'
	ELSE RETURN 'High'
	RETURN ''
END

GO

SELECT
[Salary]
,[dbo].ufn_GetSalaryLevel([Salary]) AS [Salary Level]
From [Employees]

GO

--Problem 6. Employees by Salary Level

CREATE PROCEDURE usp_EmployeesBySalaryLevel(@levelSalary VARCHAR(7))
AS
BEGIN
	SELECT
		[FirstName]
		,[LastName]
		From [Employees]
		WHERE [dbo].ufn_GetSalaryLevel([Salary]) = @levelSalary
END

EXEC usp_EmployeesBySalaryLevel 'high'

GO

--Problem 7. Define Function

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
  RETURNS BIT
AS
  BEGIN
    DECLARE @isComprised BIT = 0;
    DECLARE @currentIndex INT = 1;
    DECLARE @currentChar CHAR;

    WHILE (@currentIndex <= LEN(@word))
      BEGIN
        SET @currentChar = substring(@word, @currentIndex, 1);
        IF (charindex(@currentChar, @setOfLetters) = 0)
          BEGIN
            RETURN @isComprised;
          END
        SET @currentIndex+= 1;
      END

    RETURN @isComprised + 1;
  END

GO

SELECT [dbo].[ufn_IsWordComprised]('oistmiahf','halves') AS [Result]
SELECT [dbo].[ufn_IsWordComprised]('oistmiahf','Sofia') AS [Result]

GO

--Problem 8. * Delete Employees and Departments

CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS

DECLARE @empIDsToBeDeleted TABLE
(
Id int
)

INSERT INTO @empIDsToBeDeleted
SELECT e.EmployeeID
FROM Employees AS e
WHERE e.DepartmentID = @departmentId

ALTER TABLE Departments
ALTER COLUMN ManagerID int NULL

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (SELECT Id FROM @empIDsToBeDeleted)

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN (SELECT Id FROM @empIDsToBeDeleted)

UPDATE Departments
SET ManagerID = NULL
WHERE ManagerID IN (SELECT Id FROM @empIDsToBeDeleted)

DELETE FROM Employees
WHERE EmployeeID IN (SELECT Id FROM @empIDsToBeDeleted)

DELETE FROM Departments
WHERE DepartmentID = @departmentId 

SELECT COUNT(*) AS [Employees Count] FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.DepartmentID = @departmentId

GO

--Part II – Queries for Bank Database

USE [Bank]

GO
--Problem 9. Find Full Name

CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
	SELECT
		CONCAT([FirstName],' ',[LastName]) AS [FullName]
		FROM [AccountHolders]
END

EXEC usp_GetHoldersFullName

GO

--Problem 10. People with Balance Higher Than

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@parameter MONEY)
AS
BEGIN
		SELECT
			[FirstName]
			,[LastName]
			FROM(
				SELECT
				ah.[Id]
				,ah.[FirstName]
				,ah.[LastName]
				,SUM(a.[Balance]) AS [Total]
				FROM [AccountHolders]  AS ah
				LEFT JOIN [Accounts] AS a ON ah.[Id] = a.[AccountHolderId]
				GROUP BY ah.[Id],ah.[FirstName],ah.[LastName]) AS [SalaryQuery]
			WHERE [Total] > @parameter
			ORDER BY [FirstName]
					,[LastName]
END

EXEC usp_GetHoldersWithBalanceHigherThan 100000

GO

--Problem 11. Future Value Function

CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(20,4),@interestRate FLOAT, @years INT)
RETURNS DECIMAL(20,4)
BEGIN 
	DECLARE @FutureValue DECIMAL(20,4);
	SET @FutureValue = @sum * POWER((1+@interestRate),@years)
	RETURN @FutureValue
END

SELECT [dbo].[ufn_CalculateFutureValue](1000,0.1,5)

GO

--Problem 12. Calculating Interest

CREATE PROCEDURE usp_CalculateFutureValueForAccount(@accountID INT,@interestRate FLOAT)
AS
	SELECT
		a.[Id] AS [Account Id]
		,ah.[FirstName] AS [First Name]
		,ah.[LastName] AS [Last Name]
		,a.[Balance]
		,[dbo].[ufn_CalculateFutureValue]([Balance],@interestRate,5) AS [Balance in 5 years]
		FROM [AccountHolders] AS ah 
		JOIN [Accounts] AS a ON ah.[Id] = a.[AccountHolderId]
		WHERE a.[Id] = @accountID

EXEC usp_CalculateFutureValueForAccount 1,0.1

GO

--Part II – Queries for Diablo Database

USE [Diablo]

--Problem 13. *Scalar Function: Cash in User Games Odd Rows

GO

CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN SELECT(
				SELECT SUM([Cash]) AS [SumCash]
				FROM(
						SELECT
							g.[Name]
							,ug.[Cash]
							,ROW_NUMBER() OVER(PARTITION BY ug.[GameId] ORDER BY ug.[GameId] ASC) AS [RowNum]
						FROM [UsersGames] AS ug
						JOIN [Games] AS g ON ug.[GameId]=g.[Id] 
						WHERE g.[Name] = @gameName		
					) AS [RowNumberQuery]
	WHERE [RowNum] % 2 <> 0) AS [SumCash]

SELECT * FROM [dbo].[ufn_CashInUsersGames]('Love in a mist')