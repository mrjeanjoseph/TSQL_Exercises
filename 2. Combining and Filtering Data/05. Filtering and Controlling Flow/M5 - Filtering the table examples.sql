USE Northwind
DECLARE @searchVal AS varchar(max)


SET @searchVal = '10268'
SELECT		
		OrderID,
		CompanyName,
		Convert(varchar,OrderDate,101) AS OrderDate
FROM  Customers c
	LEFT JOIN Orders o ON o.CustomerID = c.CustomerID 
WHERE OrderID = @searchVal



SET @searchVal = 'around the horn'
SELECT	
		CompanyName,
		OrderID,
		Convert(varchar,OrderDate,101) AS OrderDate
FROM  Customers c
	LEFT JOIN Orders o ON o.CustomerID = c.CustomerID
WHERE CompanyName = @searchVal



SET @searchVal = '%oms%'
SELECT	
		CompanyName,
		OrderID,
		Convert(varchar,OrderDate,101) AS OrderDate
FROM  Customers c
	LEFT JOIN Orders o ON o.CustomerID = c.CustomerID
WHERE CompanyName LIKE @searchVal
ORDER BY OrderDate DESC







--SELECT		
--		OrderID,
--		CompanyName,
--		Convert(varchar,OrderDate,101) AS OrderDate
--FROM  Customers c
--	JOIN Orders o ON o.CustomerID = c.CustomerID 
--ORDER BY o.OrderDate  