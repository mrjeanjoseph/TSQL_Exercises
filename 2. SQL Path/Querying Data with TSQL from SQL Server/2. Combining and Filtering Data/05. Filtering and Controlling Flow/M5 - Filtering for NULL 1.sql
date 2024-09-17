USE Northwind

SELECT 
	CompanyName
FROM 
	Customers c
LEFT JOIN
	Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderID IS NULL
ORDER BY o.OrderID