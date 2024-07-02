USE Northwind
/* nested select and null example*/
SELECT		
		OrderID,
		CompanyName,
		Convert(varchar,OrderDate,101) AS OrderDate
FROM  Customers c
	LEFT JOIN Orders o ON o.CustomerID = c.CustomerID 
WHERE c.CustomerID NOT IN (SELECT CustomerID FROM Orders)
ORDER BY o.OrderID  

SELECT	
		CompanyName,
		OrderID,
		Convert(varchar,OrderDate,101) AS OrderDate
FROM  Customers c
	LEFT JOIN Orders o ON o.CustomerID = c.CustomerID
WHERE o.CustomerID IS NULL
ORDER BY o.OrderID
