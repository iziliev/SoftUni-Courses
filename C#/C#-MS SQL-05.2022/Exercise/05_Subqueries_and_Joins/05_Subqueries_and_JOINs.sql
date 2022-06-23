--Part I – Queries for SoftUni Database

USE [SoftUni]

--Problem 1. Employee Address

SELECT TOP(5)
	e.[EmployeeID]
	,e.[JobTitle]
	,a.[AddressID]
	,a.[AddressText]
	FROM [Employees] AS e
	JOIN [Addresses] AS a ON e.AddressID = a.AddressID
	ORDER BY e.[AddressID]

--Problem 2. Addresses with Towns

SELECT TOP(50)
	e.[FirstName]
	,e.[LastName]
	,t.[Name] AS [Town]
	,a.[AddressText]
	FROM [Employees] AS e
	JOIN [Addresses] AS a ON e.AddressID = a.AddressID
	JOIN [Towns] AS t ON a.TownID = t.TownID
	ORDER BY e.[FirstName]
		,e.[LastName]

--Problem 3. Sales Employee

SELECT
	e.[EmployeeID]
	,e.[FirstName]
	,e.[LastName]
	,d.[Name]
	FROM [Employees] AS e
	JOIN [Departments] AS d ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] = 'Sales'
	ORDER BY e.[EmployeeID]

--Problem 4. Employee Departments

SELECT TOP(5)
	e.[EmployeeID]
	,e.[FirstName]
	,e.[Salary]
	,d.[Name] AS [DepartmentName]
	FROM [Employees] AS e
	JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
	WHERE e.[Salary] > 15000
	ORDER BY d.[DepartmentID]

--Problem 5. Employees Without Project

SELECT TOP(3)
	e.[EmployeeID]
	,e.[FirstName]
	FROM [Employees] AS e
	LEFT JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
	WHERE ep.[ProjectID] IS NULL
	ORDER BY e.[EmployeeID]

--Problem 6. Employees Hired After

SELECT
	e.[FirstName]
	,e.[LastName]
	,e.[HireDate]
	,d.[Name] AS [DeptName]
	FROM [Employees] AS e
	JOIN [Departments] AS d ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] IN ('Sales', 'Finance') AND e.[HireDate] > '1999-01-01'
	ORDER BY e.[HireDate]

--Problem 7. Employees with Project

SELECT TOP(5)
	e.[EmployeeID]
	,e.[FirstName]
	,p.[Name] AS [ProjectName]
	FROM [Employees] AS e
	JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
	JOIN [Projects] AS p ON ep.[ProjectID] = p.[ProjectID]
	WHERE p.[StartDate] > '2002-08-13' AND p.[EndDate] IS NULL
	ORDER BY e.[EmployeeID]

--Problem 8. Employee 24

SELECT
	e.[EmployeeID]
	,e.[FirstName]
	,CASE
		WHEN p.[StartDate] > '2004-12-31' THEN NULL
		ELSE p.[Name]
		END AS [ProjectName]
	FROM [Employees] AS e
	JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
	JOIN [Projects] AS p ON ep.[ProjectID] = p.[ProjectID]
	WHERE e.[EmployeeID] = 24

--Problem 9. Employee Manager

SELECT
	e.[EmployeeID]
	,e.[FirstName]
	,m.[EmployeeID] AS [ManagerID]
	,m.[FirstName] AS [ManagerName]
	FROM [Employees] AS e
	JOIN [Employees] AS m ON e.[ManagerID] = m.[EmployeeID]
	WHERE m.[EmployeeID] IN (3,7)
	ORDER BY e.[EmployeeID]

--Problem 10. Employee Summary

SELECT TOP(50)
	e.[EmployeeID]
	,CONCAT(e.[FirstName],' ', e.[LastName]) AS [EmployeeName]
	,CONCAT(m.[FirstName],' ', m.[LastName]) AS [ManagerName]
	,d.[Name] AS [DepartmentName]
	FROM [Employees] AS e
	JOIN [Employees] AS m ON e.[ManagerID] = m.[EmployeeID]
	LEFT JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
	ORDER BY e.[EmployeeID]

--Problem 11. Min Average Salary

SELECT
	MIN([AverageSalaryQuery].AvarageSalary) AS [MinAverageSalary]
	FROM (SELECT
	[DepartmentID]
	,AVG([Salary]) AS [AvarageSalary]
	FROM [Employees]
	GROUP BY [DepartmentID]) AS [AverageSalaryQuery]

--Part II – Queries for Geography Database

USE [Geography]

--Problem 12. Highest Peaks in Bulgaria

SELECT
	c.[CountryCode]
	,m.[MountainRange]
	,p.[PeakName]
	,p.[Elevation]
	FROM [Countries] AS c
	JOIN [MountainsCountries] AS mc ON c.CountryCode = mc.CountryCode
	JOIN [Mountains] AS m ON mc.MountainId = m.Id
	JOIN [Peaks] AS p ON m.Id = p.MountainId
	WHERE c.[CountryName] = 'Bulgaria' AND p.[Elevation]>2835
	ORDER BY p.[Elevation] DESC

--Problem 13. Count Mountain Ranges

SELECT
	[CountRangeMountain].CountryCode
	,[MountainRanges]
	FROM (
		SELECT
		mc.[CountryCode]
		,COUNT(mc.MountainId) AS [MountainRanges]
		FROM [MountainsCountries] AS mc
		JOIN [Mountains] AS m ON mc.[MountainId]=[Id]
		GROUP BY mc.[CountryCode]) AS [CountRangeMountain]
	WHERE [CountRangeMountain].CountryCode IN('US','RU','BG')

--Problem 14. Countries with Rivers

SELECT TOP(5)
	c.[CountryName]
	,r.[RiverName]
	FROM [Countries] AS c
	LEFT JOIN [CountriesRivers] AS cr ON c.[CountryCode]=cr.[CountryCode]
	LEFT JOIN [Rivers] AS r ON cr.[RiverId] = r.[Id]
	WHERE c.[ContinentCode] = 'AF'
	ORDER BY c.[CountryName]

--Problem 15. *Continents and Currencies

SELECT [ContinentCode]
	,[CurrencyCode]
	,[CurrencyUsage] 
	FROM (SELECT
	[ContinentCode]
	,[CurrencyCode]
	,[CountCurrencies] AS [CurrencyUsage]
	,DENSE_RANK() OVER(PARTITION BY [ContinentCode] ORDER BY [CountCurrencies] DESC) AS [RankingCount]
		FROM (
			SELECT 
			[ContinentCode]
			,[CurrencyCode]
			,COUNT([ContinentCode]) AS [CountCurrencies]
			FROM [Countries]
			GROUP BY [ContinentCode],[CurrencyCode]) AS [CountQuery]
		WHERE [CountCurrencies] > 1) AS [CurrencyCountQuery]
		WHERE [RankingCount]=1
		ORDER BY [ContinentCode]

--Problem 16. Countries Without Any Mountains

SELECT 
	COUNT(c.[CountryName]) AS [Count]
	FROM [Countries] AS c
	LEFT JOIN [MountainsCountries] AS mc ON c.CountryCode = mc.CountryCode
	WHERE mc.[MountainId] IS NULL

--Problem 17. Highest Peak and Longest River by Country

SELECT TOP(5)
	[CountryName]
	,[HighestPeakElevation]
	,[LongestRiverLength]
	FROM(
		SELECT
		c.[CountryName]
		,MAX(p.[Elevation]) AS [HighestPeakElevation]
		,MAX(r.[Length]) AS [LongestRiverLength]
		,DENSE_RANK() OVER(PARTITION BY c.[CountryName] ORDER BY p.[Elevation] DESC,r.[Length] DESC) AS [Rnk]
		FROM [Countries] AS c
		LEFT JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
		LEFT JOIN [Peaks] AS p ON mc.[MountainId] = p.[MountainId]
		LEFT JOIN [CountriesRivers] AS cr ON c.[CountryCode] = cr.[CountryCode]
		LEFT JOIN [Rivers] AS r ON cr.[RiverId] = r.[Id]
		GROUP BY c.[CountryName],p.[Elevation],r.[Length]) AS [Query]
	WHERE [Rnk] = 1
	ORDER BY [HighestPeakElevation] DESC,[LongestRiverLength] DESC,[CountryName]

--Problem 18. Highest Peak Name and Elevation by Country

SELECT TOP(5)
	[Country]
	,ISNULL([Highest Peak Name],'(no highest peak)') AS [Highest Peak Name]
	,ISNULL([Highest Peak Elevation],0) AS [Highest Peak Elevation]
	,ISNULL([Mountain],'(no mountain)') AS [Mountain]
	FROM 
		(SELECT
		[CountryName] AS [Country]
		,p.[PeakName] AS [Highest Peak Name]
		,p.[Elevation] AS [Highest Peak Elevation]
		,m.[MountainRange] AS [Mountain]
		,DENSE_RANK() OVER (PARTITION BY [CountryName] ORDER BY [Elevation] DESC) AS [Rank]
		FROM [Countries] AS c
		LEFT JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
		LEFT JOIN [Mountains] AS m ON mc.[MountainId] = m.[Id]
		LEFT JOIN [Peaks] AS p ON m.[Id] = p.[MountainId]
		GROUP BY c.[CountryName],p.[PeakName],p.[Elevation],m.[MountainRange]) AS [RankingQuery]
	WHERE [Rank] = 1
	ORDER BY [Country]
