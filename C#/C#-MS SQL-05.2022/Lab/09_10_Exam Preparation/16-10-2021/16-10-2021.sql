--Database Basics MS SQL Exam – 16 Oct 2021

CREATE DATABASE [CigarShop]

--Section 1. DDL 

CREATE TABLE [Sizes]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[Length] INT CHECK([Length] BETWEEN 10 AND 25) NOT NULL
	,[RingRange] DECIMAL(3,2) CHECK([RingRange] BETWEEN 1.5 AND 7.5) NOT NULL
)

CREATE TABLE [Tastes]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[TasteType] VARCHAR(20) NOT NULL
	,[TasteStrength] VARCHAR(15) NOT NULL
	,[ImageURL] NVARCHAR(100) NOT NULL
)

CREATE TABLE [Brands]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[BrandName] VARCHAR(30) UNIQUE NOT NULL 
	,[BrandDescription] VARCHAR(MAX)
)

CREATE TABLE [Cigars]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[CigarName] VARCHAR(80) NOT NULL 
	,[BrandId] INT FOREIGN KEY REFERENCES [Brands]([Id])
	,[TastId] INT FOREIGN KEY REFERENCES [Tastes]([Id])
	,[SizeId] INT FOREIGN KEY REFERENCES [Sizes]([Id])
	,[PriceForSingleCigar] DECIMAL(18,2) NOT NULL
	,[ImageURL] VARCHAR(100) NOT NULL
)

CREATE TABLE [Addresses]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[Town] VARCHAR(30) NOT NULL 
	,[Country] NVARCHAR(30) NOT NULL 
	,[Streat] NVARCHAR(100) NOT NULL 
	,[ZIP] VARCHAR(20) NOT NULL 
)

CREATE TABLE [Clients]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[FirstName] NVARCHAR(30) NOT NULL 
	,[LastName] NVARCHAR(30) NOT NULL 
	,[Email] NVARCHAR(50) NOT NULL 
	,[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id])
)

CREATE TABLE [ClientsCigars]
(
	[ClientId] INT FOREIGN KEY REFERENCES [Clients]([Id])
	,[CigarId] INT FOREIGN KEY REFERENCES [Cigars]([Id])
	PRIMARY KEY([ClientId],[CigarId])
)

--2. Insert

INSERT INTO [Cigars]([CigarName],[BrandId],[TastId],[SizeId],[PriceForSingleCigar],[ImageURL])
VALUES
	('COHIBA ROBUSTO',9,1,5,15.50,'cohiba-robusto-stick_18.jpg')
	,('COHIBA SIGLO I',9,1,10,410.00,'cohiba-siglo-i-stick_12.jpg')
	,('HOYO DE MONTERREY LE HOYO DU MAIRE',14,5,11,7.50,'hoyo-du-maire-stick_17.jpg')
	,('HOYO DE MONTERREY LE HOYO DE SAN JUAN',14,4,15,32.00,'hoyo-de-san-juan-stick_20.jpg')
	,('TRINIDAD COLONIALES',2,3,8,85.21,'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses([Town],[Country],[Streat],[ZIP])
VALUES
	('Sofia','Bulgaria','18 Bul. Vasil levski','1000')
	,('Athens','Greece','4342 McDonald Avenue','10435')
	,('Zagreb','Croatia','4333 Lauren Drive','10000')

--3. Update

UPDATE [Cigars]
SET [PriceForSingleCigar] *= 1.20
WHERE [TastId] = (SELECT
						[Id]
						FROM [Tastes]
						WHERE [TasteType] = 'Spicy'
				  )
UPDATE [Brands]
SET [BrandDescription] = 'New description'
WHERE [BrandDescription] IS NULL

--4. Delete

DELETE FROM [Clients]
WHERE [AddressId] IN (SELECT
						[Id]
						FROM [Addresses]
						WHERE LEFT([Country], 1) = 'C')


DELETE FROM [Addresses]
WHERE LEFT([Country],1) = 'C'

--5. Cigars by Price

SELECT
	[CigarName]
	,[PriceForSingleCigar]
	,[ImageURL]
	FROM [Cigars]
	ORDER BY [PriceForSingleCigar],[CigarName] DESC

--6. Cigars by Taste

SELECT
	c.[Id]
	,c.[CigarName]
	,c.[PriceForSingleCigar]
	,t.[TasteType]
	,t.TasteStrength
	FROM [Cigars] AS c
	LEFT JOIN [Tastes] AS t ON c.[TastId] = t.[Id]
	WHERE t.[TasteType] IN ('Earthy','Woody')
	ORDER BY c.[PriceForSingleCigar] DESC

--7. Clients without Cigars

SELECT
	cl.[Id]
	,CONCAT(cl.[FirstName], ' ',cl.[LastName]) AS [ClientName]
	,cl.Email
	FROM [Clients] AS cl
	LEFT JOIN [ClientsCigars] AS cc ON cl.[Id]=cc.ClientId
	LEFT JOIN [Cigars] AS c ON cc.[CigarId] = c.[Id]
WHERE [ClientId] IS NULL
ORDER BY [ClientName]
	
--8. First 5 Cigars

SELECT TOP(5)
	c.[CigarName]
	,c.[PriceForSingleCigar]
	,c.[ImageURL]
	FROM [Cigars] AS c
	JOIN [Sizes] AS s ON c.[SizeId] = s.[Id]
	WHERE s.[Length] >= 12 AND (LOWER(c.[CigarName]) LIKE '%ci%'
		OR c.[PriceForSingleCigar] >= 50) AND s.[RingRange] >= 2.55
	ORDER BY c.[CigarName] ASC,c.[PriceForSingleCigar] DESC

--9. Clients with ZIP Codes

SELECT 
	CONCAT([FirstName],' ',[LastName]) AS [FullName]
	,[Country]
	,[ZIP]
	,FORMAT([PriceForSingleCigar], 'c', 'en-US')
	FROM
	(
		SELECT 
		c.[Id]
		,c.[FirstName]
		,c.[LastName]
		,a.[Country]
		,a.[ZIP]
		,cig.[PriceForSingleCigar]
		,DENSE_RANK() OVER(PARTITION BY c.[Id] ORDER BY cig.[PriceForSingleCigar] DESC) AS [Rank]
		FROM [Cigars] AS cig
			JOIN [ClientsCigars] AS cl ON cig.[Id] = cl.[CigarId]
			JOIN [Clients] AS c ON cl.[ClientId] = c.[Id]
			JOIN [Addresses] AS a ON c.[AddressId] = a.[Id]
			WHERE a.ZIP NOT LIKE '%[^0-9]%'
			GROUP BY c.[Id],c.[FirstName],c.[LastName],a.[Country],a.[ZIP],cig.[PriceForSingleCigar]
	) AS [Temp]
	WHERE [Rank] = 1
	ORDER BY [FullName]

--10. Cigars by Size

SELECT
	cl.[LastName]
	,AVG(s.[Length])
	,CEILING(AVG(s.[RingRange]))
	FROM [Clients] AS cl
	JOIN [ClientsCigars] AS cc ON cl.[Id] = cc.[ClientId]
	JOIN [Cigars] AS c ON cc.[CigarId] = c.[Id]
	JOIN [Sizes] AS s ON c.[SizeId] = s.[Id]
	GROUP BY cl.[LastName]
	ORDER BY AVG(s.[Length]) DESC

--11. Client with Cigars

GO

CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN (SELECT
				COUNT(*)
				FROM [Clients] AS c 
				LEFT JOIN [ClientsCigars] AS cc ON c.[Id] = cc.[ClientId]
				WHERE c.[FirstName] = @name
			)
END

SELECT dbo.udf_ClientWithCigars('Betty')

--12. Search for Cigar with Specific Taste

GO

CREATE PROCEDURE usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN
	SELECT 
		c.[CigarName]
		,FORMAT(c.[PriceForSingleCigar], 'c', 'en-US') AS [Price]
		,t.[TasteType]
		,b.[BrandName]
		,CONCAT(s.[Length],' cm') AS [CigarLength]
		,CONCAT(s.[RingRange], ' cm') AS [CigarRingRange]
		FROM [Cigars] AS c
		LEFT JOIN [Tastes] AS t ON c.[TastId] = t.[Id]
		LEFT JOIN [Sizes] AS s ON c.[SizeId] = s.[Id]
		LEFT JOIN [Brands] AS b ON c.[BrandId] = b.[Id]
		WHERE t.TasteType = @taste
		ORDER BY [CigarLength],[CigarRingRange] DESC
END