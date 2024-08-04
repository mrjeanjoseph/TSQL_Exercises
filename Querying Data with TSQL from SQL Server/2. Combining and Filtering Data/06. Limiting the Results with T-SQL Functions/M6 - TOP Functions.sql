USE Northwind
/* TOP(n) and TOP(%) */
DECLARE @num AS BIGINT
DECLARE @type AS INT --when 1, return top, otherwise, return percent
SET @num = 30
SET @type = 1

IF @type = 1
	BEGIN
	SELECT TOP(@num) 
		CompanyName,
		COUNT(od.OrderId) AS NumberOfOrders
	FROM CUSTOMERS c
	JOIN Orders o ON c.CustomerID = o.CustomerID
	JOIN [Order Details] od ON o.OrderID = od.OrderID
	GROUP BY CompanyName
	ORDER BY NumberOfOrders DESC
	END
ELSE
	BEGIN
		SELECT TOP(@num) PERCENT
			CompanyName,
			COUNT(od.OrderId) AS NumberOfOrders
		FROM CUSTOMERS c
		JOIN Orders o ON c.CustomerID = o.CustomerID
		JOIN [Order Details] od ON o.OrderID = od.OrderID
		GROUP BY CompanyName
		ORDER BY NumberOfOrders DESC
	END


--91 total customers

SELECT TOP(12) PERCENT
	CONCAT_WS(' ', dbo.Proper(e.FirstName),dbo.Proper(e.LastName)) AS Employee,
	COUNT(o.EmployeeID) AS NumberOfSales
FROM Orders o
JOIN EmployeesUppercase e ON o.EmployeeID = e.EmployeeID
GROUP BY e.FirstName, e.LastName
ORDER BY NumberOfSales DESC

SELECT TOP(5) 
	CONCAT_WS(' ', dbo.FormatProperSimple(e.FirstName),dbo.FormatProperSimple(e.LastName)) AS Employee,
	COUNT(o.EmployeeID) AS NumberOfSales
FROM Orders o
JOIN Employees e ON o.EmployeeID = e.EmployeeID
GROUP BY e.FirstName, e.LastName
ORDER BY NumberOfSales DESC

/* TOP(n) and TOP(%) */
SELECT TOP(20) WITH TIES
	CompanyName,
	COUNT(od.OrderId) AS NumberOfOrders
FROM CUSTOMERS c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY CompanyName
ORDER BY NumberOfOrders DESC
--91 total customers


SELECT TOP(12) PERCENT
	CONCAT_WS(' ', dbo.FormatProperSimple(e.FirstName),dbo.FormatProperSimple(e.LastName)) AS Employee,
	COUNT(o.EmployeeID) AS NumberOfSales
FROM Orders o
JOIN Employees e ON o.EmployeeID = e.EmployeeID
GROUP BY e.FirstName, e.LastName
ORDER BY NumberOfSales DESC


SELECT TOP(5) WITH TIES
	CONCAT_WS(' ', dbo.FormatProperSimple(e.FirstName),dbo.FormatProperSimple(e.LastName)) AS Employee,
	COUNT(o.EmployeeID) AS NumberOfSales
FROM Orders o
JOIN Employees e ON o.EmployeeID = e.EmployeeID
GROUP BY e.FirstName, e.LastName
ORDER BY NumberOfSales DESC