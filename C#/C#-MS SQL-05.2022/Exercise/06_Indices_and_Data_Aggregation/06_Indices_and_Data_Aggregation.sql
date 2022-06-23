--Part I – Queries for Gringotts Database

USE [Gringotts]

--Problem 1. Records’ Count

SELECT 
	COUNT([Id]) AS [Count]
	FROM [WizzardDeposits]

--Problem 2. Longest Magic Wand

SELECT
	MAX([MagicWandSize]) AS LongestMagicWand
	FROM [WizzardDeposits]

-- Problem 3. Longest Magic Wand Per Deposit Groups

SELECT
	[DepositGroup]
	,MAX([MagicWandSize]) AS [LongestMagicWand]
	FROM [WizzardDeposits]
	GROUP BY [DepositGroup]

--Problem 4. Smallest Deposit Group Per Magic Wand Size

SELECT TOP(2)
	[DepositGroup]
	FROM [WizzardDeposits]
	GROUP BY [DepositGroup]
	ORDER BY AVG([MagicWandSize]) ASC

--Problem 5. Deposits Sum

SELECT
	[DepositGroup]
	,SUM([DepositAmount]) AS [TotalSum]
	FROM [WizzardDeposits]
	GROUP BY [DepositGroup]

--Problem 6. Deposits Sum for Ollivander Family

SELECT
	[DepositGroup]
	,SUM([DepositAmount]) AS [TotalSum]
	FROM [WizzardDeposits]
	WHERE [MagicWandCreator] = 'Ollivander family'
	GROUP BY [DepositGroup]

--Problem 7. Deposits Filter

SELECT
	*
	FROM(SELECT
		[DepositGroup]
		,SUM([DepositAmount]) AS [TotalSum]
		FROM [WizzardDeposits]
		WHERE [MagicWandCreator] = 'Ollivander family'
		GROUP BY [DepositGroup]) AS [SumQuery]
	WHERE [TotalSum]<150000
	ORDER BY [TotalSum] DESC

--Problem 8. Deposit Charge

SELECT
	[DepositGroup]
	,[MagicWandCreator]
	,MIN([DepositCharge])
	FROM [WizzardDeposits]
	GROUP BY [DepositGroup],[MagicWandCreator]

--Problem 9. Age Groups

SELECT
	[AgeGroup]
	,COUNT([Id]) AS [WizardCount]
	FROM(SELECT
		*
		,CASE
		WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
		ELSE '[61+]'
		END AS [AgeGroup]
		FROM [WizzardDeposits]) AS [Age Query]
	GROUP BY [AgeGroup]

-- Problem 10. First Letter

SELECT
	[FirstLetter]
	FROM(SELECT
		LEFT([FirstName],1) AS [FirstLetter]
		FROM [WizzardDeposits]
		WHERE [DepositGroup] = 'Troll Chest') AS [Letter Query]
	GROUP BY [FirstLetter] 
	ORDER BY [FirstLetter]

-- Problem 11. Average Interest 

SELECT
	[DepositGroup]
	,[IsDepositExpired]
	,AVG([DepositInterest]) AS [AverageInterest]
	FROM [WizzardDeposits]
	WHERE [DepositStartDate] > '1985-01-01'
	GROUP BY [DepositGroup],[IsDepositExpired]
	ORDER BY [DepositGroup] DESC, [IsDepositExpired]
 
 --Problem 12. *Rich Wizard, Poor Wizard

 SELECT
	SUM([Difference]) AS [SumDifference]
	FROM(SELECT
		[FirstName] AS [Host Wizard]
		,[DepositAmount] AS [Host Wizard Deposit]
		,LEAD([FirstName]) OVER(ORDER BY [Id]) AS [Guest Wizard]
		,LEAD([DepositAmount]) OVER(ORDER BY [Id]) AS [Guest Wizard Deposit]
		,[DepositAmount]-LEAD([DepositAmount]) OVER(ORDER BY [Id]) AS [Difference]
		FROM [WizzardDeposits]) AS [RichPoorQuery]

--Part II – Queries for SoftUni Database

USE [SoftUni]

--Problem 13. Departments Total Salaries

SELECT
	[DepartmentID]
	,SUM([Salary]) AS [TotalSalary]
	FROM [Employees]
	GROUP BY [DepartmentID]
	ORDER BY [DepartmentID]

--Problem 14. Employees Minimum Salaries

SELECT
	[DepartmentID]
	,MIN([Salary]) AS [MinimumSalary]
	FROM [Employees]
	WHERE [DepartmentID] IN(2,5,7) AND [HireDate] > '2000-01-01'
	GROUP BY [DepartmentID]

--Problem 15. Employees Average Salaries

SELECT 
	* 
	INTO [EmployeesAverageSalaries]
	FROM [Employees]
	WHERE [Salary] > 30000

DELETE 
	FROM [EmployeesAverageSalaries]
	WHERE [ManagerID] = 42

UPDATE [EmployeesAverageSalaries]
SET [Salary] += 5000
WHERE [DepartmentID] = 1

SELECT
	[DepartmentID]
	,AVG([Salary]) AS [AverageSalary]
	FROM [EmployeesAverageSalaries]
	GROUP BY [DepartmentID]

--Problem 16. Employees Maximum Salaries

SELECT 
	[DepartmentID]
	,MAX([Salary]) AS [MaxSalary]
	FROM [Employees]
	GROUP BY [DepartmentID]
	HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000

--Problem 17. Employees Count Salaries

SELECT
	[Count]
	FROM(SELECT
	[ManagerID]
	,COUNT([EmployeeID]) AS [Count]
	FROM [Employees]
	WHERE [ManagerID] IS NULL
	GROUP BY [ManagerID]) AS [ManagerQuery]

--Problem 18. *3rd Highest Salary

SELECT
	[DepartmentID]
	,[Salary]
	FROM(SELECT
		[DepartmentID]
		,[Salary]
		,DENSE_RANK() OVER(PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS [Rank]
		FROM [Employees]
		GROUP BY [DepartmentID], [Salary]) AS [HighestSalaryQuery]
	WHERE [Rank] = 3

--Problem 19. **Salary Challenge

SELECT TOP(10)
		e.[FirstName]
		,e.[LastName]
		,e.[DepartmentID]
		FROM [Employees] AS e
		WHERE [Salary] > (SELECT
							AVG(esub.[Salary]) AS [DepartmentAVGSalary]
							FROM [Employees] AS esub
							WHERE esub.[DepartmentID] = e.[DepartmentID]
							GROUP BY [DepartmentID]
							)
ORDER BY e.[DepartmentID]