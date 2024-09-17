USE Northwind


SELECT DISTINCT o.OrderID FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID

SELECT OrderID FROM Orders
WHERE OrderID NOT IN (SELECT OrderID FROM [Order Details])

SELECT OrderID FROM Orders
INTERSECT
SELECT OrderID FROM [Order Details]
ORDER BY 1


SELECT City, 'Employee Table' FROM Employees
UNION
SELECT City, 'Customers Table' FROM Customers
ORDER BY 1

SELECT City, 'Employee Table' FROM Employees
INTERSECT
SELECT City, 'Customers Table' FROM Customers
ORDER BY 1

SELECT City FROM Employees
INTERSECT
SELECT City FROM Customers
ORDER BY 1