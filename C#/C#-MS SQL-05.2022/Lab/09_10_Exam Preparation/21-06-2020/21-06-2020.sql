CREATE DATABASE [TripService]

--Section 1. DDL

CREATE TABLE [Cities]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(20) NOT NULL
	,[CountryCode] VARCHAR(2) NOT NULL
)

CREATE TABLE [Hotels]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(30) NOT NULL
	,[CityId] INT FOREIGN KEY REFERENCES [Cities]([Id])
	,[EmployeeCount] INT NOT NULL
	,[BaseRate] DECIMAL(18,2)
)

CREATE TABLE [Rooms]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[Price] DECIMAL(18,2) NOT NULL
	,[Type] NVARCHAR(20) NOT NULL
	,[Beds] INT NOT NULL
	,[HotelId] INT FOREIGN KEY REFERENCES [Hotels]([Id])
)

CREATE TABLE [Trips]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[RoomId] INT FOREIGN KEY REFERENCES [Rooms]([Id])
	,[BookDate] DATE NOT NULL
	,[ArrivalDate] DATE NOT NULL
	,[ReturnDate] DATE NOT NULL
	,[CancelDate] DATE
)

ALTER TABLE [Trips]
ADD CONSTRAINT ch_Book_Arr CHECK ([BookDate] < [ArrivalDate])
ALTER TABLE [Trips]
ADD CONSTRAINT ch_Arr_Ret CHECK ([ArrivalDate] < [ReturnDate])

CREATE TABLE [Accounts]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[FirstName] NVARCHAR(50) NOT NULL
	,[MiddleName] NVARCHAR(20)
	,[LastName] NVARCHAR(50) NOT NULL
	,[CityId] INT FOREIGN KEY REFERENCES [Cities]([Id])
	,[BirthDate] DATE NOT NULL
	,[Email] VARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE [AccountsTrips]
(
	[AccountId] INT FOREIGN KEY REFERENCES [Accounts]([Id])
	,[TripId] INT FOREIGN KEY REFERENCES [Trips]([Id])
	,[Luggage] INT NOT NULL CHECK([Luggage] >= 0)
	PRIMARY KEY([AccountId],[TripId])
)

--2. Insert

INSERT INTO [Accounts]([FirstName],[MiddleName],[LastName],[CityId],[BirthDate],[Email])
VALUES
	('John','Smith','Smith',34,'1975-07-21','j_smith@gmail.com')
	,('Gosho',NULL,'Petrov',11,'1978-05-16','g_petrov@gmail.com')
	,('Ivan','Petrovich','Pavlov',59,'1849-09-26','i_pavlov@softuni.bg')
	,('Friedrich','Wilhelm','Nietzsche',2,'1844-10-15','f_nietzsche@softuni.bg')

INSERT INTO [Trips]([RoomId],[BookDate],[ArrivalDate],[ReturnDate],[CancelDate])
VALUES
	(101,'2015-04-12','2015-04-14','2015-04-20','2015-02-02')
	,(102,'2015-07-07','2015-07-15','2015-07-22','2015-04-29')
	,(103,'2013-07-17','2013-07-23','2013-07-24',NULL)
	,(104,'2012-03-17','2012-03-31','2012-04-01','2012-01-10')
	,(109,'2017-08-07','2017-08-28','2017-08-29',NULL)

--3. Update

UPDATE [Rooms]
SET [Price] *=1.14
WHERE [HotelId] IN (5,7,9)

--4. Delete

DELETE FROM [AccountsTrips]
WHERE [AccountId] = 47

DELETE FROM [Accounts]
WHERE [Id] = 47

--5. EEE-Mails

SELECT
	a.[FirstName]
	,a.[LastName]
	,FORMAT(a.[BirthDate],'MM-dd-yyyy')
	,c.[Name]
	,a.[Email]
	FROM [Accounts] AS a
	LEFT JOIN [Cities] AS c ON a.[CityId] = c.[Id]
	WHERE LEFT(a.[Email],1) = 'e'
	ORDER BY c.[Name]

--6. City Statistics

SELECT 
	c.[Name]
	,COUNT(*)
	FROM [Hotels] AS h
	JOIN [Cities] AS c ON h.[CityId] = c.[Id]
	GROUP BY c.[Name]
	ORDER BY COUNT(*) DESC,c.[Name]

--7. Longest and Shortest Trips

SELECT
	a.[Id]
	,CONCAT(a.[FirstName],' ',a.[LastName]) AS [FullName]
	,MAX(DATEDIFF(DAY,t.[ArrivalDate],t.[ReturnDate])) AS [LongestTrip]
	,MIN(DATEDIFF(DAY,t.[ArrivalDate],t.[ReturnDate])) AS [ShortestTrip]
	FROM [Accounts] AS a 
	JOIN [AccountsTrips] AS act ON a.[Id] = act.[AccountId]
	JOIN [Trips] AS t ON act.[TripId] = t.[Id]
	WHERE a.[MiddleName] IS NULL AND t.[CancelDate] IS NULL
	GROUP BY a.[Id],CONCAT(a.[FirstName],' ',a.[LastName])
	ORDER BY MAX(DATEDIFF(DAY,t.[ArrivalDate],t.[ReturnDate])) DESC
		,MIN(DATEDIFF(DAY,t.[ArrivalDate],t.[ReturnDate]))

--8. Metropolis

SELECT TOP(10)
	c.[Id]
	,c.[Name]
	,c.[CountryCode]
	,COUNT(*)
	FROM [Cities] AS c
	JOIN [Accounts] AS a ON c.[Id] = a.[CityId]
	GROUP BY c.[Id],c.[Name],c.[CountryCode]
	ORDER BY COUNT(*) DESC

--9. Romantic Getaways

SELECT 
	a.[Id]
	,a.[Email]
	,c.[Name]
	,COUNT(*)
	FROM [Trips] AS t
	LEFT JOIN [AccountsTrips] AS atr ON t.[Id] = atr.[TripId]
	LEFT JOIN [Accounts] AS a ON atr.[AccountId] = a.[Id]
	LEFT JOIN [Cities] AS c ON a.[CityId] = c.[Id]
	LEFT JOIN [Rooms] AS r ON t.[RoomId] = r.[Id]
	LEFT JOIN [Hotels] AS h ON r.[HotelId] = h.[Id]
	WHERE a.[CityId] = h.[CityId]
	GROUP BY a.[Id],a.[Email],c.[Name]
	ORDER BY COUNT(*) DESC, a.[Id]

--10. GDPR Violation

SELECT
	t.[Id]
	,a.[FirstName]+' '+ISNULL(a.[MiddleName]+' ','')+a.[LastName] AS [Full Name]
	,c.[Name] AS [Hometown]
	,ca.[Name] AS [To]
	,CASE
	WHEN t.[CancelDate] IS NULL THEN CONCAT(DATEDIFF(DAY,t.[ArrivalDate],t.[ReturnDate]), ' days')
	ELSE 'Canceled'
	END AS [Duration]
	FROM [AccountsTrips] AS [at]
	JOIN [Accounts] AS a ON a.[Id] = [at].[AccountId]
	JOIN [Trips] AS t ON t.[Id] = [at].TripId
	JOIN [Cities] AS c ON a.[CityId] = c.[Id]
	JOIN [Rooms] AS r ON t.[RoomId] = r.[Id]
	JOIN [Hotels] AS h ON r.[HotelId] = h.[Id]
	JOIN [Cities] AS ca ON h.[CityId] = ca.[Id]
	ORDER BY [Full Name],t.[Id]

--11. Available Room
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN

	DECLARE @RoomsBooked TABLE ([Id] INT)
	INSERT INTO @RoomsBooked
		SELECT DISTINCT
			r.[Id]
			FROM [Rooms] AS r
			JOIN [Trips] AS t ON r.[Id] = t.RoomId
			WHERE r.[HotelId] = @HotelId AND @Date BETWEEN t.[ArrivalDate] AND t.[ReturnDate] AND t.[CancelDate] IS NULL
	
	DECLARE @Rooms TABLE([Id] INT,[Price] DECIMAL(15,2),[Type] NVARCHAR(20),[Beds] INT,[TotalPrice] DECIMAL(15,2))
	INSERT INTO @Rooms
        SELECT TOP(1) r.Id, r.Price, r.[Type], r.Beds, ((h.BaseRate + r.Price) * @People) AS TotalPrice
        FROM Rooms AS r
        LEFT JOIN Hotels AS h ON r.HotelId = h.Id
        WHERE r.HotelId = @HotelId AND r.Beds >= @People AND r.Id NOT IN (SELECT Id 
                                                                            FROM @RoomsBooked)
        ORDER BY TotalPrice DESC

	DECLARE @RoomCount INT = (SELECT COUNT(*)  FROM @Rooms)

	IF (@RoomCount < 1)
        BEGIN
            RETURN 'No rooms available'
        END

	DECLARE @Result VARCHAR(MAX) = (SELECT CONCAT('Room ', Id, ': ', [Type],' (', Beds, ' beds',')', ' - ', '$', TotalPrice)
                                        FROM @Rooms)
    RETURN @Result
END

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)

--12. Switch Room

GO

CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
	DECLARE @SourceHotelID INT = (SELECT  
		h.[Id]
		FROM [Hotels] AS h
		JOIN [Rooms] AS r ON h.[Id] = r.[HotelId]
		JOIN [Trips] AS t ON r.[Id] = t.[RoomId]
		WHERE t.[Id] = @TripId)

	DECLARE @TargetHotelID INT = (SELECT  
		h.[Id]
		FROM [Hotels] AS h
		JOIN [Rooms] AS r ON h.[Id] = r.[HotelId]
		WHERE r.[Id] = @TargetRoomId)

	IF @SourceHotelID<>@TargetHotelID
	THROW 50001,'Target room is in another hotel!',1

	DECLARE @PeopleCount INT = (SELECT 
									COUNT(*) 
									FROM [AccountsTrips]
									WHERE [TripId] = @TripId)

	DECLARE @BedsInRoom INT = (SELECT [Beds] 
									FROM Rooms 
									WHERE [Id] = @TargetRoomId)

	IF @PeopleCount>@BedsInRoom
	THROW 50002,'Not enough beds in target room!',1

	UPDATE [Trips]
	SET [RoomId] = @TargetRoomId
	WHERE [Id] = @TripId

END
