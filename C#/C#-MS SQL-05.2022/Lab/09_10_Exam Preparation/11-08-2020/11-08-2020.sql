--Section 1. DDL

CREATE DATABASE [Bakery]

--1. Database design

CREATE TABLE [Countries](
	[Id] INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE [Customers](
	[Id] INT PRIMARY KEY IDENTITY
	,[FirstName] NVARCHAR(25)
	,[LastName] NVARCHAR(25)
	,[Gender] CHAR CHECK([Gender] IN('M','F'))
	,[Age] INT
	,[PhoneNumber] VARCHAR(10) CHECK(LEN([PhoneNumber]) = 10)
	,[CountryId] INT FOREIGN KEY REFERENCES [Countries]([Id])
)

CREATE TABLE [Products](
	[Id] INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(25) UNIQUE
	,[Description] NVARCHAR(250)
	,[Recipe] NVARCHAR(MAX)
	,[Price] FLOAT CHECK([Price] >= 0)
)

CREATE TABLE [Feedbacks](
	[Id] INT PRIMARY KEY IDENTITY
	,[Description] NVARCHAR(255)
	,[Rate] DECIMAL(4,2) CHECK([Rate] BETWEEN 0 AND 10)
	,[ProductId] INT FOREIGN KEY REFERENCES [Products]([Id])
	,[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id])
)

CREATE TABLE [Distributors](
	[Id] INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(25) UNIQUE
	,[AddressText] NVARCHAR(30)
	,[Summary] NVARCHAR(200)
	,[CountryId] INT FOREIGN KEY REFERENCES [Countries]([Id])
)

CREATE TABLE [Ingredients](
	[Id] INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(30)
	,[Description] NVARCHAR(200)
	,[OriginCountryId] INT FOREIGN KEY REFERENCES [Countries]([Id])
	,[DistributorId] INT FOREIGN KEY REFERENCES [Distributors]([Id])
)

CREATE TABLE [ProductsIngredients](
	[ProductId] INT FOREIGN KEY REFERENCES [Products]([Id])
	,[IngredientId] INT FOREIGN KEY REFERENCES [Ingredients]([Id])
	PRIMARY KEY([ProductId],[IngredientId])
)

--Section 2. DML

--2. Insert

INSERT INTO [Distributors]([Name],[CountryId],[AddressText],[Summary])
VALUES
	('Deloitte & Touche',2,'6 Arch St #9757','Customizable neutral traveling')
	,('Congress Title',13,'58 Hancock St','Customer loyalty')
	,('Kitchen People',1,'3 E 31st St #77','Triple-buffered stable delivery')
	,('General Color Co Inc',21,'6185 Bohn St #72','Focus group')
	,('Beck Corporation',23,'21 E 64th Ave','Quality-focused 4th generation hardware')

INSERT INTO [Customers]([FirstName],[LastName],[Age],[Gender],[PhoneNumber],[CountryId])
VALUES
	('Francoise','Rautenstrauch',15,'M','0195698399',5)
	,('Kendra','Loud',22,'F','0063631526',11)
	,('Lourdes','Bauswell',50,'M','0139037043',8)
	,('Hannah','Edmison',18,'F','0043343686',1)
	,('Tom','Loeza',31,'M','0144876096',23)
	,('Queenie','Kramarczyk',30,'F','0064215793',29)
	,('Hiu','Portaro',25,'M','0068277755',16)
	,('Josefa','Opitz',43,'F','0197887645',17)

--3. Update

UPDATE [Ingredients]
SET [DistributorId] = 35
WHERE [Name] IN ('Bay Leaf','Paprika','Poppy')

UPDATE [Ingredients]
SET [OriginCountryId] = 14
WHERE [OriginCountryId] = 8

--4. Delete

DELETE FROM [Feedbacks]
WHERE [CustomerId] = 14 OR [ProductId] = 5

--Section 3. Querying 

--5. Products by Price

SELECT 
	[Name]
	,[Price]
	,[Description]
	FROM [Products]
	ORDER BY [Price] DESC,[Name]

--6. Negative Feedback

SELECT 
	f.[ProductId]
	,f.[Rate]
	,f.[Description]
	,f.[CustomerId]
	,c.[Age]
	,c.[Gender]
	FROM [Feedbacks] AS f
	LEFT JOIN [Customers] AS c ON f.[CustomerId]=c.[Id]
	WHERE [Rate]<5.0
	ORDER BY f.[ProductId] DESC, f.[Rate]

--7. Customers without Feedback

SELECT 
	CONCAT(c.[FirstName],' ',c.[LastName]) AS CustomerName
	,c.[PhoneNumber]
	,c.[Gender]
	FROM [Customers] AS c
	LEFT JOIN [Feedbacks] AS f ON c.[Id] = f.[CustomerId]
	WHERE f.[Id] IS NULL
	ORDER BY c.[Id]

--8. Customers by Criteria

SELECT 
	c.[FirstName]
	,c.[Age]
	,c.[PhoneNumber]
	FROM [Customers] AS c
	LEFT JOIN [Countries] AS con ON c.[CountryId] = con.[Id]
	WHERE (c.[Age]>=21 AND c.[FirstName] LIKE '%an%')
			OR (RIGHT(c.[PhoneNumber],2) = '38' AND con.[Name] <> 'Greece') 
	ORDER BY c.[FirstName], c.[Age] DESC

--9. Middle Range Distributors

SELECT
	d.[Name]
	,i.[Name]
	,p.[Name]
	,AVG(f.[Rate]) AS [AverageRate]
		FROM [Products] AS p
		JOIN [Feedbacks] AS f ON p.[Id] = f.[ProductId]
		JOIN [ProductsIngredients] AS pin ON p.[Id] = pin.[ProductId]
		JOIN [Ingredients] AS i ON pin.[IngredientId] = i.[Id]
		JOIN [Distributors] AS d ON i.[DistributorId] = d.[Id]
	GROUP BY d.[Name],i.[Name],p.[Name]
	HAVING AVG(f.[Rate]) BETWEEN 5 AND 8
	ORDER BY d.[Name],i.[Name],p.[Name]

--10. Country Repre

SELECT
	[CountryName]
	,[DisributorName]
	FROM (SELECT
			c.[Name] AS [CountryName]
			,d.[Name] AS [DisributorName]
			,DENSE_RANK() OVER(PARTITION BY c.[Name] ORDER BY COUNT(i.[id]) DESC) AS [Rank]
			FROM [Countries] AS c
			LEFT JOIN [Distributors] AS d ON c.[Id] = d.[CountryId]
			LEFT JOIN [Ingredients] AS i ON d.[Id] = i.[DistributorId]
			GROUP BY c.[Name],d.[Name]) AS [Temp]
	WHERE [Temp].[Rank] = 1
	ORDER BY [CountryName],[DisributorName]

--11. Customers with Countries
GO

CREATE VIEW v_UserWithCountries AS
SELECT
	CONCAT(cus.[FirstName],' ',cus.[LastName]) AS [CustomerName]
	,cus.[Age]
	,cus.[Gender]
	,con.[Name]
	FROM [Customers] AS cus
	LEFT JOIN [Countries] AS con ON cus.[CountryId] = con.[Id]

SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age

--12. Delete Products

CREATE TRIGGER tr_DeleteProducts ON Products
INSTEAD OF DELETE AS
BEGIN
    DECLARE @deletedProducts INT = (
        SELECT p.Id
            FROM Products AS p
                     JOIN deleted AS d
                          ON p.Id = d.Id)

    DELETE
        FROM Feedbacks
        WHERE ProductId = @deletedProducts

    DELETE
        FROM ProductsIngredients
        WHERE ProductId = @deletedProducts

    DELETE Products
        WHERE Id = @deletedProducts
END
    DELETE
        FROM Products
        WHERE Id = 7