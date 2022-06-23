--PART I: Queries for Diablo Database

USE [Diablo]

--Problem 1. Number of Users for Email Provider

SELECT 
	SUBSTRING([Email],CHARINDEX('@',[Email])+1,LEN([Email]) - CHARINDEX('@',[Email])) AS [Email Provider]
	,COUNT(*) AS [Number Of Users]
	FROM [Users]
	GROUP BY SUBSTRING([Email],CHARINDEX('@',[Email])+1,LEN([Email]) - CHARINDEX('@',[Email]))
	ORDER BY [Number Of Users] DESC,[Email Provider]

--Problem 2. All User in Games

SELECT
	g.[Name] AS [Game]
	,gt.[Name] AS [Game Type]
	,u.[Username]
	,ug.[Level]
	,ug.[Cash]
	,c.[Name]
	FROM [Games] AS g
	JOIN [GameTypes] AS gt ON g.[GameTypeId]=gt.[Id]
	JOIN [UsersGames] AS ug ON g.[Id] = ug.[GameId]
	JOIN [Users] AS u ON ug.[UserId] = u.[Id]
	JOIN [Characters] AS c ON ug.[CharacterId] = c.[Id]
	ORDER BY ug.[Level] DESC,u.[Username],g.[Name]

--Problem 3. Users in Games with Their Items

SELECT 
	u.[Username]
    ,g.[Name] AS [Game] 
    ,COUNT(ugi.[ItemId]) AS [Items Count]
	,SUM(i.[Price]) AS [Items Price]
	FROM [Games] AS g
	JOIN [UsersGames] AS ug ON g.Id = ug.GameId
	JOIN [UserGameItems] AS ugi ON ug.[Id] = ugi.[UserGameId]
	JOIN [Items] AS i ON ugi.[ItemId] = i.[Id]
	JOIN [Users] AS u ON u.[Id] = ug.[UserId]
	GROUP BY g.[Name], u.[Username]
	HAVING COUNT(ugi.[ItemId]) >= 10
	ORDER BY COUNT(ugi.[ItemId]) DESC, SUM(i.[Price]) DESC, u.[Username]

--Problem 4. * User in Games with Their Statistics

WITH help AS (SELECT ug.UserId,
					 ug.GameId,
					 SUM(s.Strength) AS Strength,
					 SUM(s.Defence) AS Defence,
					 SUM(s.Speed) AS Speed,
					 SUM(s.Mind) AS Mind,
					 SUM(s.Luck) AS Luck
				FROM UsersGames AS ug
			   INNER JOIN UserGameItems AS ugi
			      ON ugi.UserGameId = ug.Id
			   INNER JOIN Items AS i
				  ON ugi.ItemId = i.Id
			   INNER JOIN [Statistics] AS s
			      ON s.Id = i.StatisticId
			   GROUP BY ug.UserId, ug.GameId)
SELECT DISTINCT u.Username,
	   g.[Name] AS 'Game',
	   MAX(c.[Name]) AS 'Character',
	   MAX(s1.Strength) + MAX(s2.Strength) + MAX(h.Strength) AS 'Strength',
	   MAX(s1.Defence) + MAX(s2.Defence) + MAX(h.Defence) AS 'Defence',
	   MAX(s1.Speed) + MAX(s2.Speed) + MAX(h.Speed) AS 'Speed',
	   MAX(s1.Mind) + MAX(s2.Mind) + MAX(h.Mind) AS 'Mind',
	   MAX(s1.Luck) + MAX(s2.Luck) + MAX(h.Luck) AS 'Luck'
  FROM UsersGames AS ug
 INNER JOIN Users AS u
    ON u.Id = ug.UserId
 INNER JOIN Games AS g
    ON g.Id = ug.GameId
 INNER JOIN UserGameItems AS ugi
    ON ugi.UserGameId = ug.Id
 INNER JOIN Items AS i
    ON ugi.ItemId = i.Id
 INNER JOIN Characters AS c
    ON c.Id = ug.CharacterId
 INNER JOIN GameTypes AS gt
    ON gt.Id = g.GameTypeId
 INNER JOIN [Statistics] AS s1
    ON s1.Id = c.StatisticId
 INNER JOIN [Statistics] AS s2
    ON s2.Id = gt.BonusStatsId
 INNER JOIN help AS h
    ON h.UserId = u.Id
   AND h.GameId = g.Id
 GROUP BY u.Username, g.[Name]
 ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC

 --Problem 5. All Items with Greater than Average Statistics

DECLARE @Avg_Mind INT = (SELECT
							AVG(s.[Mind]) 
							FROM [Items] AS i
							JOIN [Statistics] AS s ON i.[StatisticId] = s.[Id])
DECLARE @Avg_Luck INT = (SELECT
							AVG(s.[Luck]) 
							FROM [Items] AS i
							JOIN [Statistics] AS s ON i.[StatisticId] = s.[Id])
DECLARE @Avg_Speed INT = (SELECT
							AVG(s.[Speed]) 
							FROM [Items] AS i
							JOIN [Statistics] AS s ON i.[StatisticId] = s.[Id])



SELECT
	i.[Name],i.Price,i.MinLevel,s.Strength,s.Defence,s.Speed,s.Luck,s.Mind
	FROM [Items] AS i
	JOIN [Statistics] AS s ON i.[StatisticId] = s.[Id]
	GROUP BY i.[Name],i.Price,i.MinLevel,s.Strength,s.Defence,s.Speed,s.Luck,s.Mind
	HAVING s.Mind > (SELECT
							AVG(s.[Mind]) 
							FROM [Items] AS i
							JOIN [Statistics] AS s ON i.[StatisticId] = s.[Id])
		AND s.[Luck] > (SELECT
							AVG(s.[Luck]) 
							FROM [Items] AS i
							JOIN [Statistics] AS s ON i.[StatisticId] = s.[Id])
		AND s.Speed > (SELECT
							AVG(s.[Speed]) 
							FROM [Items] AS i
							JOIN [Statistics] AS s ON i.[StatisticId] = s.[Id])
	ORDER BY i.[Name]

--Problem 6. Display All Items with Information about Forbidden Game Type

SELECT
	i.[Name] AS [Item]
	,i.[Price]
	,i.[MinLevel]
	,gt.[Name] AS [Forbidden Game Type]
	FROM [Items] AS i
	LEFT JOIN [Statistics] AS s ON i.[StatisticId] = s.[Id]
	LEFT JOIN [GameTypeForbiddenItems] AS gtf ON i.[Id] = gtf.[ItemId]
	LEFT JOIN [GameTypes] AS gt ON gtf.[GameTypeId] = gt.[Id]
	ORDER BY gt.[Name] DESC,i.[Name]

--Problem 7. Buy Items for User in Game

--PART II – Queries for Geography Database

USE [Geography]

--Problem 8. Peaks and Mountains

SELECT 
	p.[PeakName]
	,m.[MountainRange]
	,MAX(p.[Elevation])
	FROM [Peaks] AS p
	JOIN [Mountains] AS m ON p.[MountainId] = m.[Id]
	GROUP BY m.[MountainRange],p.[PeakName],p.[Elevation]
	ORDER BY [Elevation] DESC,[PeakName]

--Problem 9. Peaks with Their Mountain, Country and Continent

SELECT
	p.[PeakName]
	,m.MountainRange
	,c.[CountryName]
	,con.[ContinentName]
	FROM [Peaks] AS p
	JOIN [Mountains] AS m ON p.[MountainId] = m.[Id]
	JOIN [MountainsCountries] AS mc ON m.[Id] = mc.[MountainId]
	JOIN [Countries] AS c ON mc.[CountryCode] = c.[CountryCode]
	JOIN [Continents] AS con ON c.[ContinentCode] = con.[ContinentCode]
	ORDER BY p.[PeakName],c.[CountryName]

--Problem 10. Rivers by Country

SELECT
	c.[CountryName]
	,con.[ContinentName]
	,COUNT(r.[Id]) AS [RiversCount]
	,ISNULL(SUM(r.[Length]),0) AS [TotalLength]
	FROM [Countries] AS c 
	LEFT JOIN [CountriesRivers] AS cr ON c.[CountryCode]=cr.[CountryCode]
	LEFT JOIN [Rivers] AS r ON cr.[RiverId] = r.[Id]
	LEFT JOIN [Continents] AS con ON c.[ContinentCode] = con.[ContinentCode]
	GROUP BY c.[CountryName],con.[ContinentName] 
	ORDER BY [RiversCount] DESC,[TotalLength] DESC,c.[CountryName]
	
--Problem 11. Count of Countries by Currency

SELECT 
	curr.[CurrencyCode] AS [CurrencyCode]
	,curr.[Description] AS [Currency]
	,COUNT(*) AS [NumberOfCountries]
	FROM [Currencies] AS curr
	JOIN [Countries] AS c ON curr.[CurrencyCode] = c.[CurrencyCode]
	GROUP BY curr.[CurrencyCode],curr.[Description]
	ORDER BY [NumberOfCountries] DESC, [Currency]

--Problem 12. Population and Area by Continent

SELECT
	con.[ContinentName]
	,SUM(c.[AreaInSqKm]) AS [CountriesArea]
	,SUM(c.[Population]) AS [CountriesPopulation]
	FROM [Countries] AS c
	JOIN [Continents] AS con ON c.[ContinentCode] = con.[ContinentCode]
	GROUP BY con.[ContinentName]
	ORDER BY [CountriesPopulation] DESC

--Problem 13. Monasteries by Country

CREATE TABLE [Monasteries]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50)
	,[CountryCode] CHAR(2) FOREIGN KEY REFERENCES [Countries]([CountryCode])
)

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

ALTER TABLE [Countries] 
ADD [IsDeleted]  BIT DEFAULT 0

UPDATE [Countries]
SET [IsDeleted] = 1
WHERE [CountryCode] IN (SELECT
						c.[CountryCode]
						FROM [Countries] AS c
						JOIN [CountriesRivers] AS cr ON c.[CountryCode] = cr.[CountryCode]
						JOIN [Rivers] AS r ON cr.[RiverId] = r.[Id]
						GROUP BY c.[CountryCode]
						HAVING COUNT(*) > 3
						)

SELECT 
	m.[Name] AS [Monastery]
	,c.[CountryName] AS [Country]
	FROM [Monasteries] AS m
	JOIN [Countries] As c ON m.[CountryCode] = c.[CountryCode]
	WHERE c.[IsDeleted] = 1
	ORDER BY m.[Name]

--Problem 14. Monasteries by Continents and Countries

UPDATE [Countries] 
SET [CountryName] = 'Burma'
WHERE [CountryName] = 'Myanmar'

INSERT INTO [Monasteries]([Name],[CountryCode])
	VALUES('Hanga Abbey','TZ')

INSERT INTO [Monasteries]([Name],[CountryCode])
	VALUES('Myin-Tin-Daik','MM')

SELECT 
	con.[ContinentName]
	,c.[CountryName]
	,COUNT(m.[Id]) AS [MonasteriesCount]
	FROM [Countries] AS c
	LEFT JOIN [Monasteries] AS m ON c.[CountryCode] = m.[CountryCode]
	LEFT JOIN [Continents] AS con ON c.[ContinentCode] = con.[ContinentCode]
	GROUP BY con.[ContinentName],c.[CountryName],c.[IsDeleted]
	HAVING c.IsDeleted IS NULL
	ORDER BY COUNT(m.[Id]) DESC,c.[CountryName]