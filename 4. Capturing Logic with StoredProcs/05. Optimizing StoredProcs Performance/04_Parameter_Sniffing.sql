USE [BonRepos];
GO




-- Please do not run this in production
DBCC FREEPROCCACHE;
GO




CREATE OR ALTER PROCEDURE Sales.GenerateSalesReport
@StartDate date,
@EndDate date
AS
SELECT SUM(so.SalesAmount) AS 'SalesAmount'
	   ,spl.LevelName AS 'Level'
	   ,CONCAT(sp.LastName,', ',sp.FirstName) AS 'FullName'
	   ,YEAR(so.SalesDate) AS 'SalesYear'
	   ,MONTH(so.SalesDate) AS 'SalesMonth' 
FROM Sales.SalesPerson sp
INNER JOIN Sales.SalesOrder so ON so.SalesPerson = sp.Id
INNER JOIN Sales.SalesPersonLevel spl ON spl.Id = sp.LevelId
WHERE so.SalesDate >= @StartDate AND so.SalesDate <= @EndDate
GROUP BY spl.LevelName, sp.LastName, sp.FirstName, YEAR(so.SalesDate), MONTH(so.SalesDate);
GO





-- Only one month
EXECUTE Sales.GenerateSalesReport @StartDate = '01/01/2018',
								  @EndDate = '01/31/2018';
GO





-- Now three years
-- Lets look at the execution plan
EXECUTE Sales.GenerateSalesReport @StartDate = '01/01/2017',
								  @EndDate = '12/31/2019';
GO





-- Recompile at runtime
EXECUTE Sales.GenerateSalesReport @StartDate = '01/01/2017',
								  @EndDate = '12/31/2019'
								  WITH RECOMPILE;
GO





-- Recompile every time
CREATE OR ALTER PROCEDURE Sales.GenerateSalesReport
@StartDate date,
@EndDate date
WITH RECOMPILE
AS
SELECT SUM(so.SalesAmount) AS 'SalesAmount'
	   ,spl.LevelName AS 'Level'
	   ,CONCAT(sp.LastName,', ',sp.FirstName) AS 'FullName'
	   ,YEAR(so.SalesDate) AS 'SalesYear'
	   ,MONTH(so.SalesDate) AS 'SalesMonth' 
FROM Sales.SalesPerson sp
INNER JOIN Sales.SalesOrder so ON so.SalesPerson = sp.Id
INNER JOIN Sales.SalesPersonLevel spl ON spl.Id = sp.LevelId
WHERE so.SalesDate >= @StartDate AND so.SalesDate <= @EndDate
GROUP BY spl.LevelName, sp.LastName, sp.FirstName, YEAR(so.SalesDate), MONTH(so.SalesDate);
GO




-- At the statement level
CREATE OR ALTER PROCEDURE Sales.GenerateSalesReport
@StartDate date,
@EndDate date
AS
SELECT SUM(so.SalesAmount) AS 'SalesAmount'
	   ,spl.LevelName AS 'Level'
	   ,CONCAT(sp.LastName,', ',sp.FirstName) AS 'FullName'
	   ,YEAR(so.SalesDate) AS 'SalesYear'
	   ,MONTH(so.SalesDate) AS 'SalesMonth' 
FROM Sales.SalesPerson sp
INNER JOIN Sales.SalesOrder so ON so.SalesPerson = sp.Id
INNER JOIN Sales.SalesPersonLevel spl ON spl.Id = sp.LevelId
WHERE so.SalesDate >= @StartDate AND so.SalesDate <= @EndDate
GROUP BY spl.LevelName, sp.LastName, sp.FirstName, YEAR(so.SalesDate), MONTH(so.SalesDate)
OPTION (RECOMPILE);
GO



-- Only one month
EXECUTE Sales.GenerateSalesReport @StartDate = '01/01/2018',
								  @EndDate = '01/07/2018';
GO




-- Now three years
-- Lets look at the execution plan
EXECUTE Sales.GenerateSalesReport @StartDate = '01/01/2017',
								  @EndDate = '12/31/2019';
GO




/*
Pluralsight course Identifying & Fixing Performance Issues Caused by Parameter Sniffing
By Gail Shaw

-- Optimize for
-- Declare local variables
-- Clear single execution plan

*/