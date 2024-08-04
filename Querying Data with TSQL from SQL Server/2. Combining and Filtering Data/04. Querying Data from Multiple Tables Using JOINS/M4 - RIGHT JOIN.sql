USE Northwind

/*NOT RECOMMENDED ORDER OF TABLES TO BE JOINED
	Make the focused table, Products, the first table in 
	the join using a LEFT join instead	
*/
SELECT o.OrderID,  
       FORMAT(o.OrderDate,'d', 'en-US') AS OrderDate,
	   FORMAT(o.ShippedDate,'d', 'en-US') AS ShippedDate,
	   o.ShipAddress,
	   p.ProductName,
	   FORMAT(od.UnitPrice, 'C', 'en-US') AS UnitPrice,
	   od.Quantity,
	   od.Discount,
	   FORMAT((od.UnitPrice * od.Quantity) * (1 - od.Discount), 'C', 'en-us') AS Product_Cost       
FROM [Order Details] od
	RIGHT JOIN  Products p ON od.ProductID = p.ProductID 
	LEFT JOIN Orders o ON od.OrderID = o.OrderID
ORDER BY o.OrderID

/*THE RECOMMENDED ORDER OF TABLES TO BE JOINED
	The first table should be the focus of the query.
	This result set uses LEFT to return ALL 
	Products and any information from Orders and Order Details
	with corresponding data
*/
SELECT o.OrderID,  
       FORMAT(o.OrderDate,'d', 'en-US') AS OrderDate,
	   FORMAT(o.ShippedDate,'d', 'en-US') AS ShippedDate,
	   o.ShipAddress,
	   p.ProductName,
	   FORMAT(od.UnitPrice, 'C', 'en-US') AS UnitPrice,
	   od.Quantity,
	   od.Discount,
	   FORMAT((od.UnitPrice * od.Quantity) * (1 - od.Discount), 'C', 'en-us') AS Product_Cost       
FROM Products p
	LEFT JOIN  [Order Details] od ON od.ProductID = p.ProductID 
	LEFT JOIN Orders o ON od.OrderID = o.OrderID
ORDER BY o.OrderID

