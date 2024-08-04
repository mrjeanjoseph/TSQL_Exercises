USE Northwind
/* M6 FETCH NEXT use the DataTableExample.html to view the FETCH NEXT in action */

/* return the first 10 records */
SELECT
	CompanyName,
	OrderID,
	CONVERT(VARCHAR, OrderDate, 101) AS OrderDate
FROM Customers c
	JOIN Orders o ON o.CustomerID = c.CustomerID
ORDER BY OrderID
OFFSET 0 ROWS
FETCH NEXT 10 ROWS ONLY


/* return the 11th through 20th records */
SELECT
	CompanyName,
	OrderID,
	CONVERT(VARCHAR, OrderDate, 101) AS OrderDate
FROM Customers c
	JOIN Orders o ON o.CustomerID = c.CustomerID
ORDER BY OrderID
OFFSET 10 ROWS
FETCH NEXT 10 ROWS ONLY

/* Using Variables to return a specific set of records */
DECLARE @offsetNum AS INT, @fetchNum AS INT, @pageNum AS INT
SET @fetchNum = 10
SET @pageNum = 1

SET @offsetNum = (@pageNum - 1) * @fetchNum

SELECT
	CompanyName,
	OrderID,
	CONVERT(VARCHAR, OrderDate, 101) AS OrderDate
FROM Customers c
	JOIN Orders o ON o.CustomerID = c.CustomerID
ORDER BY OrderID
OFFSET @fetchNum ROWS
FETCH NEXT @fetchNum ROWS ONLY