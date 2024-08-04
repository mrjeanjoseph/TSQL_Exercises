USE Northwind
DECLARE @qtr AS INT
DECLARE @yr	AS INT
SET @qtr = 3
SET @yr = 2020

SELECT 	
	
	p.ProductID,
	p.ProductName,
	AVG(od.Quantity) AS AverageSoldByQuarter,
	DATEPART(q,o.OrderDate) AS [Quarter]
	--DATEPART(yy,o.OrderDate) AS [Year]
FROM Products p
	LEFT JOIN [Order Details] od ON od.ProductId = p.ProductID
	LEFT JOIN Orders o ON o.OrderID = od.OrderID
GROUP BY
	p.ProductID,
	p.ProductName,
	DATEPART(q, o.OrderDate)
--	DATEPART(yy,o.OrderDate)	
--WHERE od.OrderID IS NULL
ORDER BY
	p.ProductName
--HAVING
--	(DATEPART(q,o.OrderDate) = @qtr
--	AND DATEPART(yy,o.OrderDate) = @yr)
--ORDER BY
	--CAST(AVG(od.Quantity) AS INT) DESC

--select AVG(Quantity) as avgerage
--into #tmp
--from [order details] od
--join orders o on od.orderid = o.orderid
--group by DATEPART(yy,OrderDate)

--SELECT MAX(avgerage) FROM #TMP
--drop table #tmp
