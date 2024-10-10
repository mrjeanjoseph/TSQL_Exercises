USE Northwind

SELECT o.OrderID,  
       FORMAT(o.OrderDate,'d', 'en-US') AS OrderDate,
	   FORMAT(o.ShippedDate,'d', 'en-US') AS ShippedDate,
	   o.ShipAddress,
	   p.ProductName,
	   FORMAT(od.UnitPrice, 'C', 'en-US') AS UnitPrice,
	   od.Quantity,
	   od.Discount,
	   FORMAT((od.unitprice * Quantity) - (od.unitprice * Quantity * Discount), 'C', 'en-us') AS Product_Cost  
FROM Products p 
	RIGHT JOIN [Order Details] od ON od.ProductID = p.ProductID 
	RIGHT JOIN Orders o ON od.OrderID = o.OrderID
ORDER BY o.OrderID

