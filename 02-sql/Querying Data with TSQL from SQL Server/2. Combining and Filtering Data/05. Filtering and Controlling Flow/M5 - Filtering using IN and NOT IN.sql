USE Northwind

SELECT OrderID FROM Orders --832 orders
SELECT DISTINCT OrderID FROM [Order Details] --830 associated orders

SELECT * FROM Orders
WHERE OrderID NOT IN (SELECT OrderID FROM [Order Details])--2

SELECT * FROM Orders
WHERE OrderID IN (SELECT OrderID FROM [Order Details]) --830


SELECT OrderID FROM Orders
WHERE EXISTS (SELECT OrderID FROM [Order Details]) --830