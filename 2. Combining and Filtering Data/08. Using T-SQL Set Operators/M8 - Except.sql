USE Northwind

--SELECT City FROM Customers
--EXCEPT
--SELECT City FROM Employees
--ORDER BY 1

--SELECT City FROM Employees
--EXCEPT
--SELECT City FROM Customers
--ORDER BY 1

--SELECT City FROM Customers
--WHERE City NOT IN (SELECT City FROM Employees)
--ORDER BY 1

--SELECT o.OrderID FROM Orders o
--LEFT JOIN [Order Details] od ON o.OrderID = od.OrderID
--WHERE od.OrderID IS NULL
--ORDER BY od.OrderID

--SELECT COUNT(OrderID) FROM Orders
--SELECT COUNT(DISTINCT OrderID) FROM [Order Details]

--SELECT OrderID FROM Orders
--WHERE OrderID NOT IN (SELECT OrderID FROM [Order Details])


SELECT OrderID FROM [Order Details]
EXCEPT
SELECT OrderId FROM Orders

SELECT CustomerID FROM Customers
EXCEPT
SELECT CustomerID FROM Orders
