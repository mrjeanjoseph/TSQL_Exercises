USE Northwind

DECLARE @timesOrdered AS INT
SET @timesOrdered = 50
SELECT 
	p.ProductName,
	COUNT(od.ProductID)
FROM Products p
LEFT JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductName
HAVING COUNT(od.ProductID) > @timesOrdered
ORDER BY COUNT(od.ProductID)

--SELECT COUNT (*) FROM Products
--SELECT COUNT(DISTINCT ProductID) FROM [Order Details]