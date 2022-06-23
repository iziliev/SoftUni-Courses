CREATE DATABASE [Zoo]
USE [Zoo]

--1. DDL

CREATE TABLE [Owners]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,[PhoneNumber] VARCHAR(15) NOT NULL
	,[Address] VARCHAR(50)
)

CREATE TABLE [AnimalTypes]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[AnimalType] VARCHAR(30) NOT NULL
)

CREATE TABLE [Cages]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[AnimalTypeId] INT FOREIGN KEY REFERENCES [AnimalTypes]([Id]) NOT NULL
)

CREATE TABLE [Animals]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(30) NOT NULL
	,[BirthDate] DATE NOT NULL
	,[OwnerId] INT FOREIGN KEY REFERENCES [Owners]([Id])
	,[AnimalTypeId] INT FOREIGN KEY REFERENCES [AnimalTypes]([Id]) NOT NULL
)

CREATE TABLE [AnimalsCages]
(
	[CageId] INT FOREIGN KEY REFERENCES [Cages]([Id]) NOT NULL
	,[AnimalId] INT FOREIGN KEY REFERENCES [Animals]([Id]) NOT NULL
	PRIMARY KEY([CageId],[AnimalId])
)

CREATE TABLE [VolunteersDepartments]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[DepartmentName] VARCHAR(30) NOT NULL
)

CREATE TABLE [Volunteers]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,[PhoneNumber] VARCHAR(15) NOT NULL
	,[Address] VARCHAR(50)
	,[AnimalId] INT FOREIGN KEY REFERENCES [Animals]([Id])
	,[DepartmentId] INT FOREIGN KEY REFERENCES [VolunteersDepartments]([Id]) NOT NULL
)

--2. Insert

INSERT INTO [Volunteers]([Name],[PhoneNumber],[Address],[AnimalId],[DepartmentId])
VALUES
	('Anita Kostova','0896365412','Sofia, 5 Rosa str.',15,1)
	,('Dimitur Stoev','0877564223',NULL,42,4)
	,('Kalina Evtimova','0896321112','Silistra, 21 Breza str.',9,7)
	,('Stoyan Tomov','0898564100','Montana, 1 Bor str.',18,8)
	,('Boryana Mileva','0888112233',NULL,31,5)

INSERT INTO [Animals]([Name],[BirthDate],[OwnerId],[AnimalTypeId])
VALUES
	('Giraffe','2018-09-21',21,1)
	,('Harpy Eagle','2015-04-17',15,3)
	,('Hamadryas Baboon','2017-11-02',NULL,1)
	,('Tuatara','2021-06-30',2,4)

--3. Update

UPDATE [Animals]
SET [OwnerId] = (SELECT 
					[Id]
					FROM [Owners]
					WHERE [Name] = 'Kaloqn Stoqnov')
WHERE [OwnerId] IS NULL

--4. Delete

DELETE FROM [Volunteers]
WHERE [DepartmentId] = (SELECT 
							[Id] 
							FROM [VolunteersDepartments]
							WHERE [DepartmentName] = 'Education program assistant')

DELETE FROM [VolunteersDepartments]
WHERE [DepartmentName] = 'Education program assistant'

--5. Volunteers

SELECT 
	[Name]
	,[PhoneNumber]
	,[Address]
	,[AnimalId]
	,[DepartmentId]
	FROM [Volunteers]
	ORDER BY [Name],[AnimalId],[DepartmentId]

--6. Animals data

SELECT
	a.[Name]
	,ats.[AnimalType]
	,FORMAT(a.[BirthDate],'dd.MM.yyyy') AS [BirthDate]
	FROM [Animals] AS a
	LEFT JOIN [AnimalTypes] AS ats ON a.[AnimalTypeId] = ats.[Id]
	ORDER BY a.[Name]

--7. Owners and Their Animals

SELECT TOP(5)
	o.[Name]
	,COUNT(*) AS [CountOfAnimals]
	FROM [Animals] AS a
	JOIN [Owners] AS o ON a.[OwnerId] = o.[Id]
	GROUP BY o.[Name]
	ORDER BY COUNT(*) DESC, o.[Name]

--8. Owners, Animals and Cages

SELECT 
	CONCAT(o.[Name],'-',a.[Name]) AS [OwnersAnimals]
	,o.[PhoneNumber]
	,c.[Id] AS [CageId]	
	FROM [Owners] AS o
	JOIN [Animals] AS a ON o.[Id] = a.[OwnerId]
	JOIN [AnimalTypes] AS ats ON a.[AnimalTypeId] = ats.[Id]
	JOIN [AnimalsCages] AS ac ON a.[Id] = ac.[AnimalId]
	JOIN [Cages] AS c ON ac.[CageId] = c.[Id]
	WHERE ats.[AnimalType] = 'Mammals'
	ORDER BY o.[Name] ASC,a.[Name] DESC

--9. Volunteers in Sofia

SELECT 
	v.[Name]
	,v.[PhoneNumber]
	,SUBSTRING(v.[Address], (CHARINDEX(',',v.[Address])+1), LEN(v.[Address])- (CHARINDEX(',',v.[Address]))) AS [Address]
	FROM [Volunteers] AS v
	JOIN [VolunteersDepartments] AS vd ON v.[DepartmentId] = vd.[Id]
	WHERE [DepartmentName] = 'Education program assistant' AND v.[Address] LIKE '%Sofia%'
	ORDER BY v.[Name]

--10. Animals for Adoption

SELECT 
	a.[Name]
	,FORMAT(a.[BirthDate],'yyyy') AS [BirthYear]
	,ats.[AnimalType]
	FROM [Animals] AS a
	JOIN [AnimalTypes] AS ats ON a.[AnimalTypeId] = ats.[Id]
	WHERE [OwnerId] IS NULL AND
		[AnimalTypeId] <> (SELECT 
								[Id] 
								FROM [AnimalTypes] 
								WHERE AnimalType = 'Birds')
							AND 
		DATEDIFF(YEAR,[BirthDate],'01/01/2022') < 5
	ORDER BY [Name]

--11. All Volunteers in a Department

SELECT 
	COUNT(*)
	FROM [VolunteersDepartments] AS vd
	JOIN [Volunteers] AS v ON vd.[Id] = v.[DepartmentId]
	WHERE vd.[DepartmentName]='Education program assistant'
	GROUP BY vd.[DepartmentName]

--11.	All Volunteers in a Department

GO

CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @CountVolunters INT
	SET @CountVolunters = (SELECT 
							COUNT(*)
							FROM [VolunteersDepartments] AS vd
							JOIN [Volunteers] AS v ON vd.[Id] = v.[DepartmentId]
							WHERE vd.[DepartmentName] = @VolunteersDepartment
							GROUP BY vd.[DepartmentName])
	RETURN @CountVolunters
END

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant')
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Guest engagement')
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events')

--12.	Animals with Owner or Not


GO

CREATE PROCEDURE usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
BEGIN
	SELECT	
	a.[Name]
	,CASE
	WHEN o.[Name] IS NULL THEN 'For adoption'
	ELSE o.[Name] 
	END AS [OwnersName]
	FROM [Animals] AS a
	LEFT JOIN [Owners] AS o ON a.OwnerId = o.Id
	WHERE a.[Name] = @AnimalName
END

EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'
EXEC usp_AnimalsWithOwnersOrNot 'Hippo'
EXEC usp_AnimalsWithOwnersOrNot 'Brown bear'