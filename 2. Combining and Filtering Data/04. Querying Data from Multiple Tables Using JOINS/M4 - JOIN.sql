USE Northwind

SELECT FORMAT((od.unitprice * Quantity) - (od.unitprice * Quantity * Discount), 'C', 'en-us') AS Product_Cost,
       o.OrderID, 
       c.CompanyName, 
       CONCAT_WS(', ', ISNULL(dbo.Proper(e.LastName,'-'), 'unk'), 
				ISNULL(dbo.Proper(e.FirstName,DEFAULT),'unk')) AS Employee, 
       DATEPART(q, o.OrderDate) AS Sales_Quarter, 
       DATEPART(yy, o.OrderDate) AS Sales_Year
FROM [Order Details] od
     JOIN Orders o ON o.OrderID = od.orderid
     JOIN customers c ON o.CustomerID = c.CustomerID
     JOIN EmployeesExtraCharacters e ON o.EmployeeID = e.EmployeeID
ORDER BY DATEPART(yy, o.OrderDate), 
         DATEPART(q, o.OrderDate);