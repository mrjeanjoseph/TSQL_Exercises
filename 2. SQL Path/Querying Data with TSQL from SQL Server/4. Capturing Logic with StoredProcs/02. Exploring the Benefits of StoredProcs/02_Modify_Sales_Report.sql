-- Run this script to follow along with the demo
USE [ABCCompany];
GO

CREATE OR ALTER PROCEDURE [Sales].[GenerateSalesReport]
AS
SELECT SUM(so.SalesAmount) AS 'SalesAmount'
	   ,spl.LevelName AS 'Level'
	   ,CONCAT(sp.LastName,', ',sp.FirstName) AS 'FullName' 
FROM Sales.SalesPerson sp
LEFT OUTER JOIN Sales.SalesOrder so ON so.SalesPerson = sp.Id
LEFT OUTER JOIN Sales.SalesPersonLevel spl ON spl.Id = sp.LevelId
WHERE spl.LevelName NOT IN ('President')
GROUP BY spl.LevelName, sp.LastName, sp.FirstName;
GO