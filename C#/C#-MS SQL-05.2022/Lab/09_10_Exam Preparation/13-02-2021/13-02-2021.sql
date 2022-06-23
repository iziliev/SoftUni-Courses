CREATE DATABASE [Bitbucket]

--Section 1. DDL

CREATE TABLE [Users]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[UserName] VARCHAR(30) NOT NULL
	,[Password] VARCHAR(30) NOT NULL
	,[Email] VARCHAR(30) NOT NULL
)

CREATE TABLE [Repositories]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE [RepositoriesContributors]
(
	[RepositoryId] INT FOREIGN KEY REFERENCES [Repositories]([Id])
	,[ContributorId] INT FOREIGN KEY REFERENCES [Users]([Id])
	PRIMARY KEY([RepositoryId],[ContributorId])
)

CREATE TABLE [Issues]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[Title] VARCHAR(255) NOT NULL
	,[IssueStatus] VARCHAR(6) NOT NULL
	,[RepositoryId] INT FOREIGN KEY REFERENCES [Repositories]([Id])
	,[AssigneeId] INT FOREIGN KEY REFERENCES [Users]([Id])
)

CREATE TABLE [Commits]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[Message] VARCHAR(255) NOT NULL
	,[IssueId] INT FOREIGN KEY REFERENCES [Issues]([Id])
	,[RepositoryId] INT FOREIGN KEY REFERENCES [Repositories]([Id])
	,[ContributorId] INT FOREIGN KEY REFERENCES [Users]([Id])
)

CREATE TABLE [Files]
(
	[Id] INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(100) NOT NULL
	,[Size] DECIMAL(18,2) NOT NULL
	,[ParentId] INT FOREIGN KEY REFERENCES [Files]([Id])
	,[CommitId] INT FOREIGN KEY REFERENCES [Commits]([Id])
)

--2. Insert

INSERT INTO [Files]([Name],[Size],[ParentId],[CommitId])
VALUES
	('Trade.idk',2598.0,1,1)
	,('menu.net',9238.31,2,2)
	,('Administrate.soshy',1246.93,3,3)
	,('Controller.php',7535.15,4,4)
	,('Find.java',9957.86,5,5)
	,('Controller.json',14034.87,3,6)
	,('Operate.xix',7662.92,7,7)

INSERT INTO [Issues]([Title],[IssueStatus],[RepositoryId],[AssigneeId])
VALUES
	('Critical Problem with HomeController.cs file','open',1,4)
	,('Typo fix in Judge.html','open',4,3)
	,('Implement documentation for UsersService.cs','closed',8,2)
	,('Unreachable code in Index.cs','open',9,8)

--3. Update

UPDATE [Issues]
SET [IssueStatus] = 'closed'
WHERE [AssigneeId] = 6

--4. Delete

DELETE FROM [RepositoriesContributors]
WHERE [RepositoryId] = (SELECT 
							[Id]
							FROM [Repositories]
							WHERE [Name] = 'Softuni-Teamwork')

DELETE FROM [Issues]
WHERE [RepositoryId] = (SELECT 
							[Id]
							FROM [Repositories]
							WHERE [Name] = 'Softuni-Teamwork')
--5. Commits

SELECT 
	[Id]
	,[Message]
	,[RepositoryId]
	,[ContributorId]
	FROM [Commits]
	ORDER BY [Id], [Message],[RepositoryId],[ContributorId]

--6. Front-end

SELECT
	[Id]
	,[Name]
	,[Size]
	FROM [Files]
	WHERE [Size]>1000 AND [Name] LIKE '%html%'
	ORDER BY [Size] DESC, [Id],[Name]

--7. Issue Assignment

SELECT
	i.[Id]
	,CONCAT(u.[UserName],' : ',i.[Title])
	FROM [Issues] AS i
	LEFT JOIN [Users] AS u ON i.[AssigneeId] = u.[Id]
	ORDER BY i.[Id] DESC,i.[AssigneeId]

--8. Single Files

SELECT 
	f.[Id]
	,f.[Name]
	,CONCAT(f.[Size],'KB') AS [Size]
	FROM [Files] AS f
	LEFT JOIN Files AS p ON f.[Id]=p.[ParentId]
WHERE p.[Id] iS NULL
ORDER BY f.[Id],f.[Name],f.[Size]

--9. Commits in Repositories

SELECT TOP(5)
	r.[Id]
	,r.[Name]
	,COUNT(c.[Id]) As [Commits]
	FROM [Commits] AS c
	JOIN [Repositories] AS r ON c.RepositoryId=r.[Id]
	JOIN [RepositoriesContributors] AS rc ON r.[Id]=rc.[RepositoryId]
	GROUP BY r.[Id],r.[Name]
	ORDER BY [Commits] DESC,r.[Id],r.[Name]

--10. Average Size

SELECT 
	u.[UserName]
	,AVG(f.[Size]) AS [Size]
	FROM [Users] AS u
	JOIN [Commits] AS c ON u.Id = c.ContributorId
	JOIN [Files] AS f ON c.[Id] = f.[CommitId]
	GROUP BY u.[UserName]
	ORDER BY AVG(f.[Size]) DESC,u.[UserName]

--11. All User Commits

GO

CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
BEGIN
	DECLARE @Result INT = (SELECT 
		COUNT(u.[Id])
		FROM [Users] AS u
		JOIN [Commits] AS c ON u.Id = c.ContributorId
		WHERE [UserName] = @username)
	RETURN @Result
END

SELECT dbo.udf_AllUserCommits('UnderSinduxrein')

--12. Search for Files

CREATE PROCEDURE usp_SearchForFiles(@fileExtension VARCHAR(10))
AS
BEGIN
	SELECT 
		[Id]
		,[Name]
		,CONCAT([Size],'KB') AS [Size]
		FROM [Files]
		WHERE [Name] LIKE CONCAT('%.',@fileExtension)
		ORDER BY [Id],[Name],[Size] DESC
END

EXEC usp_SearchForFiles 'txt'