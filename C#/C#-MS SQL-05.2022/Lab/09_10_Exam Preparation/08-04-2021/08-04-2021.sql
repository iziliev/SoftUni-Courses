--Database Basics MS SQL Exam – 8 April 2021

--Section 1. DDL

CREATE DATABASE [Service]

CREATE TABLE [Users](
	[Id] INT PRIMARY KEY IDENTITY
	,[Username] NVARCHAR(30) NOT NULL UNIQUE
	,[Password] NVARCHAR(50) NOT NULL
	,[Name] NVARCHAR(50)
	,[Birthdate] DATETIME2
	,[Age] INT
		CHECK ([Age] BETWEEN 14 AND 110)
	,[Email] VARCHAR(50) NOT NULL
)

CREATE TABLE [Departments](
	[Id] INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY
	,[FirstName] NVARCHAR(25)
	,[LastName] NVARCHAR(25)
	,[Birthdate] DATETIME2
	,[Age] INT
		CHECK ([Age] BETWEEN 18 AND 110)	
	,[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id])
)

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(50) NOT NULL
	,[DepartmentId] INT NOT NULL FOREIGN KEY REFERENCES [Departments]([Id])
)

CREATE TABLE [Status](
	[Id] INT PRIMARY KEY IDENTITY
	,[Label] NVARCHAR(30) NOT NULL
)	

CREATE TABLE [Reports](
	[Id] INT PRIMARY KEY IDENTITY
	,[CategoryId] INT NOT NULL
	,[StatusId] INT NOT NULL
	,[OpenDate] DATETIME2 NOT NULL
	,[CloseDate] DATETIME2
	,[Description] NVARCHAR(200) NOT NULL
	,[UserId] INT NOT NULL
	,[EmployeeId] INT
	,FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id])
	,FOREIGN KEY ([StatusId]) REFERENCES [Status]([Id])
	,FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
	,FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id])
)

--Section 2. DML

INSERT INTO [Employees]([FirstName],[LastName],[Birthdate],[DepartmentId])
VALUES
	('Marlo','O''Malley','1958-09-21',1)
	,('Niki','Stanaghan','1969-11-26',4)
	,('Ayrton','Senna','1960-03-21',9)
	,('Ronnie','Paterson','1944-02-14',9)
	,('Giovanna','Amati','1959-07-20',5)

INSERT INTO [Reports]([CategoryId],[StatusId],[OpenDate],[CloseDate],[Description],[UserId],[EmployeeId])
VALUES
	(1,1,'2017-04-13',NULL,'Stuck Road on Str.133',6,2)
	,(6,3,'2015-09-05','2015-12-06','Charity trail running',3,5)
	,(14,2,'2015-09-07',NULL,'Falling bricks on Str.58',5,2)
	,(4,3,'2017-07-03','2017-07-06','Cut off streetlight on Str.11',1,1)

-- 3. Update

UPDATE [Reports]
SET [CloseDate] = GETDATE()
WHERE [CloseDate] IS NULL

--4. Delete

DELETE FROM [Reports]
WHERE [StatusId] = 4

--Section 3. Querying

--5. Unassigned Reports

SELECT
	[Description]
	,FORMAT([OpenDate],'dd-MM-yyyy')
	FROM [Reports]
	WHERE [EmployeeId] IS NULL
	ORDER BY [OpenDate],[Description]

--6. Reports & Categories

SELECT
	r.[Description]
	,c.[Name] AS [CategoryName]
	FROM [Reports] AS r
	JOIN [Categories] AS c ON r.[CategoryId] = c.[Id]
	ORDER BY r.[Description],c.[Name]

--7. Most Reported Category

SELECT TOP(5)
	c.[Name]
	,COUNT(*) AS [ReportsNumber]
	FROM [Reports] AS r
	JOIN [Categories] AS c ON r.[CategoryId] = c.[Id]
	GROUP BY c.[Name]
	ORDER BY [ReportsNumber] DESC,c.[Name]

--8. Birthday Report

SELECT
	u.[Username]
	,c.[Name] AS [CategoryName]
	FROM [Users] AS u
	JOIN [Reports] AS r ON u.[Id] = r.[UserId]
	JOIN [Categories] AS c ON r.[CategoryId] = c.[Id]
	WHERE DATEPART(MONTH,u.[Birthdate]) = DATEPART(MONTH,r.[OpenDate]) AND
		  DATEPART(DAY,u.[Birthdate]) = DATEPART(DAY,r.[OpenDate])
	ORDER BY u.[Username],c.[Name]

--9. Users per Employee 

SELECT
	CONCAT(e.[FirstName], ' ', e.[LastName]) AS [FullName]
	,COUNT(DISTINCT r.[UserId]) AS [UsersCount]
	FROM [Employees] AS e
	LEFT JOIN [Reports] AS r ON e.Id = r.EmployeeId
	LEFT JOIN [Users] As u ON r.UserId = u.Id
	GROUP BY CONCAT(e.[FirstName], ' ', e.[LastName])
	ORDER BY [UsersCount] DESC,[FullName]

--10. Full Info

SELECT
	ISNULL(e.[FirstName] + ' ' + e.[LastName],'None') AS [Employee]
	,ISNULL(d.[Name],'None') AS [Department]
	,c.[Name] AS [Category]
	,r.[Description]
	,FORMAT(r.[OpenDate],'dd.MM.yyyy') AS [OpenDate]
	,s.[Label] AS [Status]
	,u.[Name] AS [User]
	FROM [Reports] AS r 
	LEFT JOIN [Employees] AS e ON e.[Id] = r.[EmployeeId]
	LEFT JOIN [Categories] AS c ON c.[Id] = r.[CategoryId]
	LEFT JOIN [Departments] AS d ON d.[Id] = e.[DepartmentId]
	LEFT JOIN [Status] AS s ON s.[Id] = r.[StatusId]
	LEFT JOIN [Users] AS u ON u.[Id] = r.[UserId]
	ORDER BY e.[FirstName] DESC
			,e.[LastName] DESC
			,[Department] ASC
			,[Category] ASC
			,[Description] ASC
			,[OpenDate] ASC
			,[Status] ASC
			,[User] ASC

--Section 4. Programmability

GO

--11. Hours to Complete

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
BEGIN
	DECLARE @Value INT
	IF @StartDate IS NULL OR @EndDate IS NULL
		BEGIN
			SET @Value = 0
		END
	ELSE SET @Value = DATEDIFF(HOUR,@StartDate,@EndDate)
	
	RETURN @Value
END

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

GO

--12. Assign Employee

CREATE OR ALTER PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
DECLARE @EmployeeDepartment INT = 
(	
	SELECT [DepartmentId] 
		FROM [Employees] 
		WHERE [Id] = @EmployeeId
)
DECLARE @ReportDepartment INT = 
(	
	SELECT [DepartmentId] 
		FROM [Categories]
		WHERE [Id] = (
						SELECT [CategoryId] 
							FROM [Reports] 
							WHERE [Id] = @ReportId
					)
)

IF(@EmployeeDepartment <> @ReportDepartment)
	BEGIN
		THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1;
	END
ELSE
	BEGIN
		UPDATE [Reports]
		SET EmployeeId = @EmployeeId
		WHERE [Id] = @ReportId
	END

EXEC usp_AssignEmployeeToReport 30, 1

EXEC usp_AssignEmployeeToReport 17, 2