USE [BonRepos];
GO

-- Old way to check if it exists
IF OBJECT_ID('tempdb..#SalesOrder') IS NOT NULL
    DROP TABLE #SalesOrder;
GO

-- Drop if it exists starting with SQL 2016
DROP TABLE IF EXISTS #SalesOrder;
GO

-- Creating a temp table
CREATE TABLE #SalesOrder (
	SalesAmount decimal(36,2), Id int);
GO

-- Inserting data into our temp table
INSERT INTO #SalesOrder (SalesAmount, Id)
SELECT SalesAmount, Id FROM Sales.SalesOrder
WHERE SalesDate >= '1/1/2018' AND SalesDate <= '12/31/2018';
GO

 DROP TABLE IF EXISTS #SalesOrderDemo2;
 GO

 -- If you don't want to define the data structure
 SELECT SalesAmount, Id INTO #SalesOrderDemo2
 FROM Sales.SalesOrder 
 WHERE SalesDate >= '1/1/2018' AND SalesDate <= '12/31/2018';
GO

-- Make sure you don't add a GO statement until your done
DECLARE @SalesOrder AS TABLE 
	(SalesAmount decimal(36,2), Id int);

INSERT INTO @SalesOrder 
	SELECT SalesAmount, Id FROM Sales.SalesOrder
WHERE SalesDate >= '1/1/2018' AND SalesDate <= '12/31/2018';
GO

-- Will this work
SELECT SalesAmount, Id INTO @SalesOrder
FROM Sales.SalesOrder 
WHERE SalesDate >= '1/1/2018' AND SalesDate <= '12/31/2018';
GO

CREATE OR ALTER PROCEDURE Sales.ReportSalesCommision
	@StartDate date,
	@EndDate date,
	@SalesPersonLevelId int
AS
BEGIN

SET NOCOUNT ON;

	DROP TABLE IF EXISTS #SalesOrderData;

	CREATE TABLE #SalesOrderData (
			SalesAmount decimal(36,2), 
			SalesPersonId int,
			WeekNumber int,
			Commission decimal(36,2),
			WeeklyRank int);

	INSERT INTO #SalesOrderData (SalesPersonId, SalesAmount, WeekNumber)
		SELECT s.SalesPerson,
			   SUM(s.SalesAmount) AS SalesAmount,
			   DATEPART(WEEK,s.SalesDate) AS WeekNumber
		FROM Sales.SalesOrder s
		INNER JOIN Sales.SalesPerson sp ON s.SalesPerson = sp.Id
		INNER JOIN Sales.SalesPersonLevel spl ON sp.LevelId = spl.Id
		WHERE s.SalesDate >= @StartDate AND s.SalesDate <= @EndDate AND spl.Id = @SalesPersonLevelId
		GROUP BY DATEPART(WEEK,s.SalesDate), s.SalesPerson;


	UPDATE #SalesOrderData SET Commission = 
								CASE WHEN WeekNumber BETWEEN 1 AND 12 THEN SalesAmount * .01
									 WHEN WeekNumber BETWEEN 13 AND 24 THEN SalesAmount * .02
									 WHEN WeekNumber BETWEEN 25 AND 51 THEN SalesAmount * .05
									ELSE SalesAmount * .10
								END;

	SELECT	SalesPersonId, 
			WeekNumber,
			Commission,
			ROW_NUMBER() OVER(PARTITION BY WeekNumber ORDER BY Commission DESC) AS WeeklyRank
	FROM #SalesOrderData;

END
GO


EXECUTE Sales.ReportSalesCommision @StartDate = '1/1/2018',
								   @EndDate = '12/31/2018',
								   @SalesPersonLevelId = 2;
GO