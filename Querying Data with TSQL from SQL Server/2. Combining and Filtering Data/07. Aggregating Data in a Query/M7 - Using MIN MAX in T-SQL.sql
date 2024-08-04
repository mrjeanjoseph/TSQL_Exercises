USE Northwind

SELECT 
	c.CompanyName,
	SUBSTRING(FORMAT(MAX(o.OrderDate),'MMM dd yyyy'),1,11) As LastOrderPlaced,
	SUBSTRING(FORMAT(MIN(o.OrderDate),'MMM dd yyyy'),1,11) AS FirstOrderPlace,
	FORMAT(AVG(od.Quantity * od.UnitPrice), 'c', 'en-us') AS AverageOrderAmount
FROM Customers c
LEFT JOIN Orders o ON o.CustomerID = c.CustomerID
LEFT JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.CompanyName
ORDER BY AVG(od.Quantity * od.UnitPrice) DESC


