--Part I – Queries for SoftUni Database

USE [SoftUni]

--Problem 1. Find Names of All Employees by First Name

SELECT 
	[FirstName]
	,[LastName]
	FROM [Employees]
	WHERE [FirstName] LIKE 'Sa%'

	--OR

SELECT 
	[FirstName]
	,[LastName]
	FROM [Employees]
	WHERE LEFT([FirstName],2) = 'Sa'

--Problem 2. Find Names of All employees by Last Name

SELECT
	[FirstName]
	,[LastName]
	FROM [Employees]
	WHERE LOWER([LastName]) LIKE '%ei%'

--Problem 3. Find First Names of All Employees

SELECT
	[FirstName]
	FROM [Employees]
	WHERE [DepartmentID] IN (3,10) 
	AND DATEPART(YEAR,[HireDate]) BETWEEN 1995 AND 2005

--Problem 4. Find All Employees Except Engineers

SELECT
	[FirstName]
	,[LastName]
	FROM [Employees]
	WHERE LOWER([JobTitle]) NOT LIKE '%engineer%'

	--OR

SELECT
	[FirstName]
	,[LastName]
	FROM [Employees]
	WHERE CHARINDEX('engineer',LOWER([JobTitle]),1) = 0

--Problem 5. Find Towns with Name Length

SELECT
	[Name]
	FROM [Towns]
	WHERE LEN([Name]) IN(5,6)
	ORDER BY [Name]

--Problem 6. Find Towns Starting With

SELECT
	[TownID]
	,[Name]
	FROM [Towns]
	WHERE [Name] LIKE 'M%'
		OR [Name] LIKE 'K%'
		OR [Name] LIKE 'B%'
		OR [Name] LIKE 'E%'
	ORDER BY [Name]

	--OR

SELECT
	[TownID]
	,[Name]
	FROM [Towns]
	WHERE LEFT([Name],1) IN ('M','K','B','E')
	ORDER BY [Name]

--Problem 7. Find Towns Not Starting With

SELECT
	[TownID]
	,[Name]
	FROM [Towns]
	WHERE [Name] NOT LIKE 'R%'
		AND [Name] NOT LIKE 'B%'
		AND [Name] NOT LIKE 'D%'
	ORDER BY [Name]

	--OR

SELECT
	[TownID]
	,[Name]
	FROM [Towns]
	WHERE LEFT([Name],1) NOT IN ('R','B','D','E')
	ORDER BY [Name]

--Problem 8. Create View Employees Hired After 2000 Year

GO

CREATE VIEW "V_EmployeesHiredAfter2000" AS
SELECT
	[FirstName]
	,[LastName]
	FROM [Employees]
	WHERE DATEPART(YEAR,[HireDate]) > 2000

GO

SELECT * FROM [V_EmployeesHiredAfter2000]

--Problem 9. Length of Last Name

SELECT
	[FirstName]
	,[LastName]
	FROM [Employees]
	WHERE LEN([LastName]) = 5

--RANKING 

--SELECT e.FirstName, e.LastName  
--    ,ROW_NUMBER() OVER (ORDER BY e.Salary) AS "Row Number"  
--    ,RANK() OVER (ORDER BY e.Salary DESC) AS Rank  
--    ,DENSE_RANK() OVER (ORDER BY e.Salary DESC,e.[EmployeeID]) AS "Dense Rank"  
--    ,NTILE(4) OVER (ORDER BY e.Salary) AS Quartile
--	,e.Salary
--FROM Employees AS e
--WHERE e.[Salary] BETWEEN 10000 AND 50000

--Problem 10. Rank Employees by Salary

SELECT
	[EmployeeID]
	,[FirstName]
	,[LastName]
	,[Salary]
	,DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
	FROM Employees
	WHERE [Salary] BETWEEN 10000 AND 50000
	ORDER BY [Salary] DESC

--Problem 11. Find All Employees with Rank 2 *

SELECT
	*
	FROM (SELECT
	[EmployeeID]
	,[FirstName]
	,[LastName]
	,[Salary]
	,DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
	FROM Employees
	WHERE [Salary] BETWEEN 10000 AND 50000) AS [Ranking]
	WHERE [Rank] = 2
	ORDER BY [Salary] DESC

-- Part II - Queries for Geography Database

USE [Geography]

--Problem 12. Countries Holding 'A' 3 or More Times

SELECT
	[CountryName] AS [Country Name]
	,[IsoCode] AS [ISO Code]
	FROM [Countries]
	WHERE LOWER([CountryName]) LIKE '%a%a%a%'
	ORDER BY [IsoCode]

	--OR

SELECT
	[CountryName] AS [Country Name]
	,[IsoCode] AS [ISO Code]
	FROM [Countries]
	WHERE LEN([CountryName]) - LEN(REPLACE(LOWER([CountryName]),'a','')) >=3
	ORDER BY [IsoCode]

--Problem 13. Mix of Peak and River Names

SELECT
	p.[PeakName]
	,r.[RiverName]
	,CONCAT(LEFT(LOWER(p.[PeakName]),LEN(p.[PeakName])-1),LOWER(r.[RiverName])) AS 'Mix'
	FROM [Peaks] AS p,[Rivers] AS r
	WHERE RIGHT(p.[PeakName],1) = LEFT(r.[RiverName],1)
	ORDER BY [Mix]

--Part III - Queries for Diablo Database

USE [Diablo]

--Problem 14. Games from 2011 and 2012 year

SELECT TOP(50)
	[Name]
	,FORMAT([Start],'yyyy-MM-dd') AS [Start]
	FROM [Games]
	WHERE DATEPART(YEAR,[Start]) BETWEEN 2011 AND 2012
	ORDER BY [Start]
		,[Name]

--Problem 15. User Email Providers

SELECT
	[Username]
	,RIGHT([Email],LEN([Email]) - CHARINDEX('@',[Email],1)) AS [Email Provider]
	FROM [Users]
	ORDER BY [Email Provider],[Username]

--Problem 16. Get Users with IPAdress Like Pattern

SELECT
	[UserName]
	,[IPAddress] AS 'IP Address'
	FROM [Users]
	WHERE [IPAddress] LIKE '___.1%.%.___'
	ORDER BY [Username]

--Problem 17. Show All Games with Duration and Part of the Day

SELECT
	[Name] AS [Game]
	,CASE
	WHEN DATEPART(HOUR,[Start]) BETWEEN 0 AND 11 THEN 'Morning'
	WHEN DATEPART(HOUR,[Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
	ELSE 'Evening'
	END AS [Part of the Day]
	,CASE
	WHEN [Duration] <= 3 THEN 'Extra Short'
	WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
	WHEN [Duration] > 6 THEN 'Long'
	ELSE 'Extra Long'
	END AS 'Duration'
	FROM [Games]
	ORDER BY [Name]
		,[Duration]

--Part IV – Date Functions Queries

USE [Orders]

--Problem 18. Orders Table

SELECT
	[ProductName]
	,[OrderDate]
	,DATEADD(DAY,3,[OrderDate]) AS [Pay Due]
	,DATEADD(MONTH,1,[OrderDate]) AS [Deliver Due]
	FROM [Orders]

--Problem 19. People Table

CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(50) NOT NULL
	,[Birthdate] DATETIME2 NOT NULL
)

INSERT INTO [People]([Name],[Birthdate])
VALUES('Victor','2000-12-17')
	,('Steven','1992-09-10')
	,('Stephen','1910-09-19')
	,('John','2010-01-06')

SELECT
	[Name]
	,DATEDIFF(YEAR,[BirthDate],GETDATE()) AS [Age in Years]
	,DATEDIFF(MONTH,[BirthDate],GETDATE()) AS [Age in Months]
	,DATEDIFF(DAY,[BirthDate],GETDATE()) AS [Age in Days]
	,DATEDIFF(MINUTE,[BirthDate],GETDATE()) AS [Age in Minutes]
	FROM [People]