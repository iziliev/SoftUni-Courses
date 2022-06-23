
CREATE DATABASE [ColonialJourney]
GO
USE [ColonialJourney]

--1. DDL

CREATE TABLE [Planets]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE [Spaceports]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,[PlanetId] INT FOREIGN KEY REFERENCES [Planets]([Id])
)

CREATE TABLE [Spaceships]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,[Manufacturer] VARCHAR(30) NOT NULL
	,[LightSpeedRate] INT DEFAULT 0
)

CREATE TABLE [Colonists]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[FirstName] VARCHAR(20) NOT NULL
	,[LastName] VARCHAR(20) NOT NULL
	,[Ucn] VARCHAR(10) NOT NULL UNIQUE
	,[BirthDate] DATE NOT NULL
)

CREATE TABLE [Journeys]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[JourneyStart] DATETIME NOT NULL
	,[JourneyEnd] DATETIME NOT NULL
	,[Purpose] VARCHAR(11)
	CHECK([Purpose] IN ('Medical', 'Technical', 'Educational', 'Military'))
	,[DestinationSpaceportId] INT FOREIGN KEY REFERENCES [Spaceports]([Id])
	,[SpaceshipId] INT FOREIGN KEY REFERENCES [Spaceships]([Id])
)

CREATE TABLE [TravelCards]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[CardNumber] VARCHAR(10) NOT NULL UNIQUE
	,[JobDuringJourney] VARCHAR(8) 
	CHECK([JobDuringJourney] IN('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook'))
	,[ColonistId] INT FOREIGN KEY REFERENCES [Colonists]([Id])
	,[JourneyId] INT FOREIGN KEY REFERENCES [Journeys]([Id])
)

--2. Insert

INSERT INTO[Planets]([Name])
VALUES
	('Mars')
	,('Earth')
	,('Jupiter')
	,('Saturn')

INSERT INTO[Spaceships]([Name],[Manufacturer],[LightSpeedRate])
VALUES
	('Golf','VW',3)
	,('WakaWaka','Wakanda',4)
	,('Falcon9','SpaceX',1)
	,('Bed','Vidolov',6)

--3. Update

UPDATE [Spaceships]
SET [LightSpeedRate] += 1
WHERE [Id] BETWEEN 8 AND 12

--4. Delete

DELETE [TravelCards]
WHERE [JourneyId] IN(SELECT TOP(3) 
						[Id] 
						FROM [Journeys])

DELETE [Journeys]
WHERE [Id] BETWEEN 1 AND 3

--5. Select all military journeys

SELECT
	[Id]
	,FORMAT([JourneyStart],'dd/MM/yyyy') AS [JourneyStart]
	,FORMAT([JourneyEnd],'dd/MM/yyyy') AS [JourneyEnd]
	FROM [Journeys]
	WHERE [Purpose] = 'Military'
	ORDER BY [JourneyStart]

--6. Select all pilots

SELECT
	c.[Id] AS [id]
	,CONCAT(c.[FirstName],' ',c.[LastName]) AS [full_name]
	FROM [Colonists] AS c
	JOIN [TravelCards] AS t ON c.[Id] = t.[ColonistId]
	WHERE t.[JobDuringJourney] = 'Pilot'
	ORDER BY c.[Id]

--7. Count colonists.

SELECT
	COUNT(*) AS [count]
	FROM Journeys AS j
	JOIN [TravelCards] AS t ON j.[Id] = t.[JourneyId]
	JOIN [Colonists] AS c ON t.[ColonistId] = c.[Id]
	WHERE j.Purpose = 'Technical'

--8. Select spaceships with pilots younger than 30 years

SELECT 
	s.[Name]
	,s.[Manufacturer]
	FROM [TravelCards] AS t
	JOIN [Colonists] AS c ON t.[ColonistId] = c.[Id]
	JOIN [Journeys] AS j ON t.[JourneyId] = j.[Id]
	JOIN [Spaceships] AS s ON j.[SpaceshipId] = s.[Id]
	WHERE t.[JobDuringJourney] = 'Pilot' AND DATEDIFF(YEAR,c.[BirthDate],'01/01/2019') < 30
	ORDER BY s.[Name]

--9. Select all planets and their journey count

SELECT
	p.[Name] AS [PlanetName]
	,COUNT(*) AS [JourneysCount]
	FROM [Planets] AS p
	JOIN [Spaceports] AS s ON p.[Id]=s.[PlanetId]
	JOIN [Journeys] AS j ON s.[Id] = j.[DestinationSpaceportId]
	GROUP BY p.[Name]
	ORDER BY [JourneysCount] DESC,p.[Name]

--10. Select Second Oldest Important Colonist

SELECT 
	[JobDuringJourney]
	,CONCAT([FirstName],' ',[LastName]) AS [FullName]
	,[Rank] AS [JobRank]
	FROM
	(
		SELECT
				j.[Id],c.[FirstName],c.[LastName],tc.JobDuringJourney,c.[BirthDate]
				,DENSE_RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.[BirthDate] ASC) AS [Rank]
				FROM [Colonists] AS c
				JOIN [TravelCards] AS tc ON c.[Id] = tc.[ColonistId]
				JOIN [Journeys] AS j ON tc.[JourneyId] = j.[Id]
				GROUP BY j.[Id],c.[FirstName],c.[LastName],tc.JobDuringJourney,c.BirthDate
	) AS [TableRankingQuery]
	WHERE [Rank] = 2

--11. Get Colonists Count

GO

CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN
RETURN (SELECT 
			COUNT(*)
			FROM [TravelCards] AS tc
			JOIN [Colonists] AS c ON tc.[ColonistId] = c.[Id]
			JOIN [Journeys] AS j ON tc.[JourneyId] = j.[Id]
			JOIN [Spaceports] AS s ON j.[DestinationSpaceportId] = s.[Id]
			JOIN [Planets] AS p ON s.[PlanetId] = p.[Id]
			WHERE p.[Name] = @PlanetName)
END

SELECT dbo.udf_GetColonistsCount('Otroyphus')

--12. Change Journey Purpose

GO

CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
BEGIN

	DECLARE @ExistJourney INT = (SELECT 
									COUNT(*) 
									FROM [Journeys]
									WHERE [Id] = @JourneyId
								)
	
	IF @ExistJourney < 1
		THROW 50001,'The journey does not exist!',1

	DECLARE @CurrentPurpose VARCHAR(11) = (SELECT 
												[Purpose]
												FROM [Journeys]
												WHERE [Id] = @JourneyId
											)
	IF @CurrentPurpose = @NewPurpose
		THROW 50002,'You cannot change the purpose!',1

	UPDATE [Journeys]
	SET [Purpose] = @NewPurpose
	WHERE [Id] = @JourneyId

END

EXEC usp_ChangeJourneyPurpose 4, 'Technical'
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'