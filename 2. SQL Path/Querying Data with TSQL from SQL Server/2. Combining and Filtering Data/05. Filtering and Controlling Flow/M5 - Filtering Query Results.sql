USE Northwind

SELECT FORMAT((unitprice * Quantity) * (1 - Discount), 'C', 'en-us') AS Sales_Volume, 
       o.OrderID, 
       c.CompanyName, 
       CONCAT_WS(', ', ISNULL(dbo.ProperWithCharacters(e.LastName), 'unk'), 
				ISNULL(dbo.ProperWithCharacters(e.FirstName),'unk')) AS Employee, 
       DATEPART(q, o.OrderDate) AS Sales_Quarter, 
       DATEPART(yy, o.OrderDate) AS Sales_Year
FROM [Order Details] od
     JOIN Orders o ON o.OrderID = od.orderid
     JOIN customers c ON o.CustomerID = c.CustomerID
     JOIN EmployeesExtraCharacters e ON o.EmployeeID = e.EmployeeID
ORDER BY DATEPART(yy, o.OrderDate), 
         DATEPART(q, o.OrderDate);