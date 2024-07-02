USE [BonRepos];
GO



-- Add a select after each transformation
CREATE OR ALTER PROCEDURE Sales.ReportSalesCommission
	@StartDate date,
	@EndDate date,
	@SalesPersonLevelId int,
	@Debug bit = 0
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

	IF (@Debug = 1)
		BEGIN
			SELECT * FROM #SalesOrderData;
		END


	UPDATE #SalesOrderData SET Commission = 
								CASE WHEN WeekNumber BETWEEN 1 AND 12 THEN SalesAmount * .01
									 WHEN WeekNumber BETWEEN 13 AND 24 THEN SalesAmount * .02
									 WHEN WeekNumber BETWEEN 25 AND 51 THEN SalesAmount * .05
									ELSE SalesAmount * .10
								END;

	IF (@Debug = 1)
		BEGIN
			SELECT * FROM #SalesOrderData;
		END
	
	SELECT TOP 10
			SalesPersonId, 
			WeekNumber,
			Commission,
			ROW_NUMBER() OVER(PARTITION BY WeekNumber ORDER BY Commission DESC) AS WeeklyRank
	FROM #SalesOrderData;

END
GO


-- Override the default 
EXECUTE Sales.ReportSalesCommission @StartDate = '1/1/2018',
								   @EndDate = '1/10/2018',
								   @SalesPersonLevelId = 2,
								   @Debug = 1;
GO