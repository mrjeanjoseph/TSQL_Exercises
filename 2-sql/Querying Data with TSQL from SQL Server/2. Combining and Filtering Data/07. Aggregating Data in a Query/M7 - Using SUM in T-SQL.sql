USE Northwind

DECLARE @timesOrdered AS INT
DECLARE @totalOrdered AS INT
SET @timesOrdered = 50
SET @totalOrdered = 1000
SELECT 
	p.ProductName,
	COUNT(od.ProductID) AS TimesOrdered,
	CASE WHEN SUM(od.Quantity) IS NULL THEN
		0
	ELSE
	SUM(od.Quantity) END AS TotalOrdered
FROM Products p
LEFT JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductName
HAVING COUNT(od.ProductID) > @timesOrdered
	AND SUM(od.Quantity) > @totalOrdered
ORDER BY COUNT(od.ProductID) DESC


--SELECT COUNT (*) FROM Products
--SELECT COUNT(DISTINCT ProductID) FROM [Order Details]
