--Database Basics MS SQL Retake Exam – 10 Dec 2021

CREATE DATABASE [Airport]

--Section 1. DDL 

CREATE TABLE [Passengers](
	[Id] INT PRIMARY KEY IDENTITY
	,[FullName] VARCHAR(100) UNIQUE NOT NULL 
	,[Email] VARCHAR(50) UNIQUE NOT NULL 
)

CREATE TABLE [Pilots](
	[Id] INT PRIMARY KEY IDENTITY
	,[FirstName] VARCHAR(30) UNIQUE NOT NULL 
	,[LastName] VARCHAR(30) UNIQUE NOT NULL 
	,[Age] TINYINT CHECK ([Age] BETWEEN 21 AND 62) NOT NULL
	,[Rating] FLOAT	CHECK ([Rating] BETWEEN 0.0 AND 10.0)
)

CREATE TABLE [AircraftTypes](
	[Id] INT PRIMARY KEY IDENTITY
	,[TypeName] VARCHAR(30) UNIQUE NOT NULL 
)

CREATE TABLE [Aircraft](
	[Id] INT PRIMARY KEY IDENTITY
	,[Manufacturer] VARCHAR(25) NOT NULL
	,[Model] VARCHAR(30) NOT NULL
	,[Year] INT NOT NULL
	,[FlightHours] INT
	,[Condition] CHAR(1) NOT NULL
	,[TypeId] INT FOREIGN KEY REFERENCES [AircraftTypes]([Id]) NOT NULL
)

CREATE TABLE [PilotsAircraft](
	[AircraftId] INT FOREIGN KEY REFERENCES [Aircraft]([Id]) NOT NULL
	,[PilotId] INT FOREIGN KEY REFERENCES [Pilots]([Id]) NOT NULL
	,PRIMARY KEY ([AircraftId],[PilotId])
)

CREATE TABLE [Airports](
	[Id] INT PRIMARY KEY IDENTITY
	,[AirportName] VARCHAR(70) UNIQUE NOT NULL 
	,[Country] VARCHAR(100) UNIQUE NOT NULL 
)

CREATE TABLE [FlightDestinations](
	[Id] INT PRIMARY KEY IDENTITY
	,[AirportId] INT FOREIGN KEY REFERENCES [Airports]([Id]) NOT NULL
	,[Start] DATETIME NOT NULL
	,[AircraftId] INT FOREIGN KEY REFERENCES [Aircraft](Id) NOT NULL
	,[PassengerId] INT FOREIGN KEY REFERENCES [Passengers](Id) NOT NULL
	,[TicketPrice] DECIMAL(18,2) DEFAULT 15 NOT NULL
)

--Section 2. DML

--2. Insert

INSERT INTO [Passengers]([FullName],[Email])
SELECT
	CONCAT([FirstName],' ',[LastName]) AS [FullName]
	,CONCAT([FirstName],[LastName],'@gmail.com') AS [Email]
FROM [Pilots]
WHERE [Id] BETWEEN 5 AND 15

--3. Update

UPDATE [Aircraft]
SET [Condition] = 'A'
WHERE ([Condition] IN ('C','B'))
	AND (([FlightHours] IS NULL 
	OR [FlightHours] < 100))
	AND ([Year] > 2013)

--4. Delete

DELETE FROM [Passengers]
WHERE LEN([FullName]) BETWEEN 0 AND 10

--Section 3. Querying 

--5. Aircraft

SELECT 
	[Manufacturer]
	,[Model]
	,[FlightHours]
	,[Condition]
	FROM [Aircraft]
	ORDER BY [FlightHours] DESC

--6. Pilots and Aircraft

SELECT
	p.[FirstName]
	,p.[LastName]
	,a.Manufacturer
	,a.Model
	,a.FlightHours
	FROM [Pilots] AS p
	LEFT JOIN [PilotsAircraft] AS pa ON p.Id = pa.PilotId
	LEFT JOIN [Aircraft] AS a ON pa.AircraftId = a.Id
	WHERE a.FlightHours IS NOT NULL AND a.FlightHours<=303
	ORDER BY a.FlightHours DESC,p.FirstName

--7. Top 20 Flight Destinations

SELECT TOP(20)
	fd.[Id]
	,fd.[Start]
	,p.[FullName]
	,a.[AirportName]
	,fd.[TicketPrice]
	FROM [FlightDestinations] AS fd
	LEFT JOIN [Airports] AS a ON fd.[AirportID] = a.[Id]
	LEFT JOIN [Passengers] AS p ON fd.[PassengerId] = p.[Id]
	WHERE DATEPART(DAY,fd.[Start]) % 2 = 0
	ORDER BY fd.[TicketPrice] DESC, a.[AirportName]

--8. Number of Flights for Each Aircraft

SELECT 
	* 
	FROM (SELECT 
				[AircraftId]
				,[Manufacturer]
				,[FlightHours]
				,COUNT([FlightDestinationsCount]) AS [FlightDestinationsCount]
				,ROUND(AVG([TicketPrice]),2) AS [TicketPrice]
				FROM(SELECT 
							a.[Id] AS [AircraftId]
							,a.[Manufacturer] AS [Manufacturer]
							,a.[FlightHours] AS [FlightHours]
							,a.[Id] AS [FlightDestinationsCount]
							,fd.[TicketPrice] AS [TicketPrice]
							FROM [Aircraft] AS a
							LEFT JOIN [FlightDestinations] AS fd ON a.[Id] = fd.[AircraftId]) AS [JoinSubQuery]
	GROUP BY [FlightDestinationsCount],[AircraftId],[Manufacturer],[FlightHours]) AS [GroupSubQuery]
	WHERE [FlightDestinationsCount] >=2
	ORDER BY [FlightDestinationsCount] DESC, [AircraftId]

--9. Regular Passengers

SELECT
	*	
	FROM(SELECT
			p.[FullName] AS [FullName]
			,COUNT(p.[FullName]) AS [CountOfAircraft]
			,SUM(fd.[TicketPrice]) AS [TotalPayed]
			FROM [Passengers] AS p
			LEFT JOIN [FlightDestinations] AS fd ON p.[Id] = fd.[PassengerId]
			GROUP BY p.[FullName]) AS [PassengersSubQuery]
		WHERE [CountOfAircraft] > 1 AND SUBSTRING([FullName],2,1) = 'a'
		ORDER BY [FullName]

--10. Full Info for Flight Destinations

SELECT 
	a.[AirportName]
	,fd.[Start] AS [DayTime]
	,fd.TicketPrice
	,p.[FullName]
	,ac.[Manufacturer]
	,ac.[Model]
	FROM [Airports] AS a
	LEFT JOIN [FlightDestinations] AS fd ON a.[Id] = fd.[AirportID]
	LEFT JOIN [Passengers] AS p ON fd.[PassengerId] = p.[Id]
	LEFT JOIN [Aircraft] AS ac ON fd.[AircraftId] = ac.[Id]
	WHERE (DATEPART(HOUR,fd.[Start]) BETWEEN 6 AND 20)
		AND fd.[TicketPrice] > 2500
	ORDER BY ac.[Model]

--Section 4. Programmability

--11. Find all Destinations by Email Address

GO

CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @Result INT = (SELECT
								COUNT(PassengerId) 
								FROM [Passengers] AS p
								LEFT JOIN [FlightDestinations] AS fd ON p.[Id] = fd.[PassengerId]
								WHERE p.[Email] = @email
								GROUP BY p.[Id], p.[Email]
						   )
	RETURN @Result
END

SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')

GO

--12. Full Info for Airports

SELECT
	a.[AirportName]
	,p.[FullName]
	,CASE
	WHEN fd.[TicketPrice] BETWEEN 0 AND 400 THEN 'Low'
	WHEN fd.[TicketPrice] BETWEEN 401 AND 1500 THEN 'Medium'
	ELSE 'High'
	END AS [LevelOfTickerPrice]
	,ac.[Manufacturer]
	,ac.[Condition]
	,aty.[TypeName]
	FROM [Airports] AS a
	LEFT JOIN [FlightDestinations] AS fd ON a.[Id] = fd.[AirportID]
	LEFT JOIN [Aircraft] AS ac ON fd.[AircraftId] = ac.[Id]
	LEFT JOIN [AircraftTypes] AS aty ON ac.[TypeId] = aty.[Id]
	LEFT JOIN [Passengers] As p ON fd.[PassengerId] = p.[Id]
	WHERE a.[AirportName] = 'Sir Seretse Khama International Airport'
	ORDER BY ac.[Manufacturer], p.[FullName]



CREATE PROCEDURE usp_SearchByAirportName @airportName VARCHAR(70)
AS
BEGIN
	SELECT
	a.[AirportName]
	,p.[FullName]
	,CASE
	WHEN fd.[TicketPrice] BETWEEN 0 AND 400 THEN 'Low'
	WHEN fd.[TicketPrice] BETWEEN 401 AND 1500 THEN 'Medium'
	ELSE 'High'
	END AS [LevelOfTickerPrice]
	,ac.[Manufacturer]
	,ac.[Condition]
	,aty.[TypeName]
	FROM [Airports] AS a
	LEFT JOIN [FlightDestinations] AS fd ON a.[Id] = fd.[AirportID]
	LEFT JOIN [Aircraft] AS ac ON fd.[AircraftId] = ac.[Id]
	LEFT JOIN [AircraftTypes] AS aty ON ac.[TypeId] = aty.[Id]
	LEFT JOIN [Passengers] As p ON fd.[PassengerId] = p.[Id]
	WHERE a.[AirportName] = @airportName
	ORDER BY ac.[Manufacturer], p.[FullName]
END

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'