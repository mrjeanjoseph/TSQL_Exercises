USE Northwind

SELECT 
	e.EmployeeID, 
	CONCAT_WS(', ',TRIM(e.LastName), TRIM(e.FirstName)) AS Employee, 
	CASE WHEN e.ReportsTo IS NULL THEN
		'Unknown'
	ELSE
		CONCAT_WS(', ', TRIM(mgr.LastName),TRIM(mgr.FirstName)) END AS Manager	
	INTO #emp
	FROM Employees e
	LEFT JOIN Employees mgr ON e.ReportsTo = mgr.EmployeeID
SELECT 
	CASE WHEN o.EmployeeID IS NULL THEN
		0
	ELSE
		o.EmployeeID END AS EmployeeID, 
	COUNT(o.OrderId) AS SalesCount,
	COUNT(c.Region) AS RegionCount
	INTO #orders
	FROM Orders o 
	JOIN Customers c ON o.customerid =c.CustomerID
	GROUP BY EmployeeID

SELECT DISTINCT
	o.EmployeeID,
	dbo.OrderAmountPurchased(od.OrderID) as TotalSales	
	INTO #sales
	FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID



SELECT 
	e.EmployeeId,
	e.Employee,
	e.Manager,
	CASE WHEN r.RegionCount IS NULL THEN
		0
	ELSE
		r.RegionCount END AS RegionCount,
	CASE WHEN r.SalesCount IS NULL THEN
		0
	ELSE
		r.SalesCount END AS SalesCount,
	CASE WHEN SUM(s.TotalSales) IS NULL THEN
		FORMAT(0,'c', 'en-us')
	ELSE
		FORMAT(SUM(s.TotalSales),'c','en-us') END AS SalesVolume,
	CASE WHEN AVG(s.TotalSales) IS NULL THEN
		FORMAT(0,'c','en-us')
	ELSE
		FORMAT(AVG(s.TotalSales),'c','en-us') END AS AverageSaleAmount
	FROM 
	#emp e 
	LEFT JOIN #orders r ON e.EmployeeID = r.EmployeeID
	LEFT JOIN #sales s ON e.EmployeeID = s.EmployeeId
	GROUP BY e.EmployeeID, e.Employee, e.Manager, r.RegionCount, r.SalesCount

DROP TABLE #emp, #orders, #sales