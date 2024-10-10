USE Northwind


SELECT 
	* 
FROM Products
WHERE ProductName LIKE 'C%' 
ORDER BY ProductName

SELECT 
	* 
FROM Products
WHERE ProductName NOT LIKE 'C%' 
ORDER BY ProductName

SELECT 
	* 
FROM Products
WHERE ProductName LIKE '%ing' 
ORDER BY ProductName

SELECT 
	* 
FROM Products
WHERE ProductName NOT LIKE '%ing' 
ORDER BY ProductName

SELECT 
	* 
FROM Products
WHERE ProductName LIKE '%g%' 
ORDER BY ProductName


SELECT 
	* 
FROM Products
WHERE ProductName NOT LIKE '%g%' 
ORDER BY ProductName




SELECT * FROM Customers WHERE CompanyName LIKE '%ome%'




