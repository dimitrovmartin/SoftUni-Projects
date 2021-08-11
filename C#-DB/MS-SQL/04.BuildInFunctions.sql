USE SoftUni

--1.Find Names of All Employees by First Name

SELECT FirstName, LastName
	FROM Employees
	WHERE FirstName LIKE 'sa%'

--2.Find Names of All employees by Last Name 

SELECT FirstName, LastName
	FROM Employees
	WHERE LastName LIKE '%ei%'

--3.Find First Names of All Employees

SELECT FirstName
	FROM Employees
	WHERE DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005 AND DepartmentID IN (3, 10)

--4.Find All Employees Except Engineers

SELECT FirstName, LastName
	FROM Employees
	WHERE JobTitle NOT LIKE '%engineer%'

--5.Find Towns with Name Length

SELECT [Name]
	FROM Towns
	WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
	ORDER BY [Name]

--6.Find Towns Starting With

SELECT *
	FROM Towns
	WHERE [Name] LIKE '[MKBE]%'
	ORDER BY [Name]

--7.Find Towns Not Starting With

SELECT *
	FROM Towns
	WHERE [Name] NOT LIKE '[RBD]%'
	ORDER BY [Name]

--8.Create View Employees Hired After 2000 Year

CREATE VIEW V_EmployeesHiredAfter2000 AS
	SELECT FirstName, LastName
		FROM Employees
		WHERE DATEPART(YEAR, HireDate) > 2000

--9.Length of Last Name

SELECT FirstName, LastName
	FROM Employees
	WHERE LEN(LastName) = 5

--10.Rank Employees by Salary

SELECT EmployeeID, FirstName, LastName, Salary, DENSE_RANK() 
		OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
	ORDER BY Salary DESC

--11.Find All Employees with Rank 2 *

SELECT * FROM(
SELECT EmployeeID, FirstName, LastName, Salary, DENSE_RANK() 
		OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
	) AS Result
		WHERE [Rank] = 2
	ORDER BY Salary DESC

--12.Countries Holding ‘A’ 3 or More Times

USE Geography

SELECT CountryName, IsoCode
	FROM Countries
	WHERE CountryName LIKE '%A%A%A%'
	ORDER BY IsoCode

--13.Mix of Peak and River Names

SELECT PeakName, RiverName, LOWER(SUBSTRING(PeakName, 1, LEN(PeakName) - 1) + RiverName)
		AS Mix 
	FROM Peaks, Rivers
	WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
	ORDER BY Mix

--14.Games from 2011 and 2012 year

USE Diablo

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
	FROM Games
	WHERE DATEPART(YEAR, [Start]) BETWEEN 2011 AND 2012
	ORDER BY [Start]

--15.User Email Providers

SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS EmailProvider
	FROM Users
	ORDER BY EmailProvider, Username

--16.Get Users with IPAdress Like Pattern

SELECT Username, IpAddress
	FROM Users
	WHERE IpAddress LIKE '___.1%.%.___' 
	ORDER BY Username

--17.Show All Games with Duration and Part of the Day

SELECT [Name],
	CASE
		WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
		WHEN DATEPART(HOUR, [Start]) BETWEEN 18 AND 23 THEN 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS Duration
	FROM Games
	ORDER BY [Name], Duration

