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
FROM Orders o
     JOIN [Order Details] od ON o.OrderID = od.orderid 
	 JOIN Products p ON od.ProductID = p.ProductID
ORDER BY o.OrderDate DESC
