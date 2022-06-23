CREATE DATABASE [WMS]

--Section 1. DDL

CREATE TABLE [Clients]
(
	[ClientId] INT PRIMARY KEY IDENTITY
	,[FirstName] VARCHAR(50) NOT NULL
	,[LastName] VARCHAR(50) NOT NULL
	,[Phone] VARCHAR(12) CHECK(LEN([Phone]) = 12)
)

CREATE TABLE [Mechanics]
(
	[MechanicId] INT PRIMARY KEY IDENTITY
	,[FirstName] VARCHAR(50) NOT NULL
	,[LastName] VARCHAR(50) NOT NULL
	,[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE [Models]
(
	[ModelId] INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE [Jobs]
(
	[JobId] INT PRIMARY KEY IDENTITY
	,[ModelId] INT FOREIGN KEY REFERENCES [Models]([ModelId])
	,[Status] VARCHAR(11) CHECK([Status] IN('Pending','In Progress','Finished')) DEFAULT 'Pending'
	,[ClientId] INT FOREIGN KEY REFERENCES [Clients]([ClientId])
	,[MechanicId] INT FOREIGN KEY REFERENCES [Mechanics]([MechanicId])
	,[IssueDate] DATE NOT NULL
	,[FinishDate] DATE
)

CREATE TABLE [Orders]
(
	[OrderId] INT PRIMARY KEY IDENTITY
	,[JobId] INT FOREIGN KEY REFERENCES [Jobs]([JobId])
	,[IssueDate] DATE
	,[Delivered] BIT DEFAULT 0
)

CREATE TABLE [Vendors]
(
	[VendorId] INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE [Parts]
(
	[PartId] INT PRIMARY KEY IDENTITY
	,[SerialNumber] VARCHAR(50) NOT NULL UNIQUE
	,[Description] VARCHAR(255)
	,[Price] DECIMAL(6,2) CHECK([Price] BETWEEN 0.01 AND 9999.99)
	,[VendorId] INT FOREIGN KEY REFERENCES [Vendors]([VendorId]) 
	,[StockQty] INT CHECK([StockQty] >= 0) DEFAULT 0
)

CREATE TABLE [OrderParts]
(
	[OrderId] INT FOREIGN KEY REFERENCES [Orders]([OrderId])
	,[PartId] INT FOREIGN KEY REFERENCES [Parts]([PartId]) 
	,[Quantity] INT CHECK([Quantity] > 0) DEFAULT 1
	PRIMARY KEY([OrderId],[PartId])
)

CREATE TABLE [PartsNeeded]
(
	[JobId] INT FOREIGN KEY REFERENCES [Jobs]([JobId])
	,[PartId] INT FOREIGN KEY REFERENCES [Parts]([PartId]) 
	,[Quantity] INT CHECK([Quantity] > 0) DEFAULT 1
	PRIMARY KEY([JobId],[PartId])
)

--2. Insert

INSERT INTO [Clients]([FirstName], [LastName], [Phone]) VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO [Parts]([SerialNumber], [Description], [Price], [VendorId]) VALUES
('WP8182119', 'Door Boot Seal', 117.86, 2),
('W10780048', 'Suspension Rod', 42.81, 1),
('W10841140', 'Silicone Adhesive', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)

--3. Update

UPDATE [Jobs]
SET [MechanicId] = 3
WHERE [Status] = 'Pending'

UPDATE Jobs
	SET [Status] = 'In Progress'
	WHERE [Status] = 'Pending' AND [MechanicId] = 3

--4. Delete

DELETE FROM [OrderParts]
WHERE [OrderId] = 19

DELETE FROM [Orders]
WHERE [OrderId] = 19

--5. Mechanic Assignments

SELECT
	CONCAT(m.[FirstName],' ',m.[LastName]) AS Mechanic
	,j.[Status]
	,j.[IssueDate]
	FROM [Mechanics] AS m
	JOIN [Jobs] AS j ON m.[MechanicId] = j.[MechanicId]
	ORDER BY m.[MechanicId],j.[IssueDate],j.[JobId]

--6. Current Clients

SELECT
	CONCAT(c.[FirstName],' ',c.[LastName]) AS [Client]
	,DATEDIFF(DAY,j.[IssueDate],'04/24/2017') AS [Days going]
	,j.[Status]
	FROM [Clients] AS c
	JOIN [Jobs] AS j ON c.[ClientId] = j.[ClientId]
	WHERE j.[Status] <> 'Finished' 
	ORDER BY [Days going] DESC,c.[ClientId]

--7. Mechanic Performance

SELECT
	CONCAT(m.[FirstName],' ',m.[LastName]) AS [Mechanic]
	,AVG(DATEDIFF(DAY,j.[IssueDate],j.FinishDate)) AS [Average Days]
	FROM [Mechanics] AS m
	JOIN [Jobs] AS j ON m.[MechanicId] = j.[MechanicId]
	WHERE j.[Status] = 'Finished'
	GROUP BY m.[MechanicId],m.[FirstName],m.[LastName]
	ORDER BY m.[MechanicId]

--8. Available Mechanics

SELECT 
	CONCAT([FirstName],' ',[LastName]) AS [Available]
	FROM [Mechanics]
	WHERE [MechanicId] NOT IN(SELECT
								[MechanicId]
								FROM [Jobs]
								WHERE [Status] = 'In Progress' OR [Status] IS NULL 
								GROUP BY [MechanicId])
	ORDER BY [MechanicId]

--9. Past Expenses

SELECT 
	j.[JobId]
	,ISNULL(SUM(p.[Price] * op.[Quantity]),0) AS [Total]
	FROM [Jobs] AS j
	LEFT JOIN [Orders] AS o ON j.[JobId] = o.[JobId]
	LEFT JOIN [OrderParts] AS op ON o.[OrderId] = op.[OrderId]
	LEFT JOIN [Parts] AS p ON op.[PartId] = p.[PartId]
	WHERE j.[FinishDate] IS NOT NULL
	GROUP BY j.[JobId]
	ORDER BY [Total] DESC,j.[JobId]

--10. Missing Parts

SELECT p.PartId, p.[Description],
	pn.Quantity AS [Required], 
	p.StockQty AS [In Stock], ISNULL(op.Quantity, 0) AS [Ordered]
		FROM PartsNeeded AS pn
	LEFT JOIN Jobs AS j ON pn.JobId = j.JobId
	LEFT JOIN Parts AS p ON p.PartId = pn.PartId
	LEFT JOIN OrderParts AS op ON op.PartId = p.PartId
	LEFT JOIN Orders AS o ON o.OrderId = op.OrderId
	WHERE j.[Status] != 'Finished' AND
	pn.Quantity > p.StockQty AND
	op.Quantity IS NULL
	GROUP BY p.PartId, p.[Description], pn.Quantity, p.StockQty, op.Quantity, pn.PartId
	ORDER BY pn.PartId

