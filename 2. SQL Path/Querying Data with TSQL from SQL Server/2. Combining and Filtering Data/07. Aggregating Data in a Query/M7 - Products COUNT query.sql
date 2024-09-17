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
































--SELECT 
--	p.ProductName,
--	COUNT(od.OrderId) AS NumberOfTimesOrdered
--FROM Products p LEFT JOIN [Order Details] od
--ON p.ProductID = od.ProductID
--GROUP BY p.ProductName
--ORDER BY COUNT(od.OrderId)


----SELECT * FROM Products
----SELECT DISTINCT ProductId FROM [Order Details]

----SELECT COUNT(*) FROM Products
----SELECT COUNT(DISTINCT ProductId) FROM [Order Details]
