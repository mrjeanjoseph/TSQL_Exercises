USE Northwind
/* Using Union All to combine result sets */

--SELECT TOP(3) CompanyName FROM Customers
--UNION ALL
--SELECT TOP(3) CONCAT_WS(' ',FirstName, LastName) FROM Employees

/*using try_cast or try_convert will return NULL where the conversion is incompatible */
--SELECT CustomerID, CompanyName AS Combined2 FROM Customers
--UNION ALL
--SELECT EmployeeID, CONCAT_WS(' ',FirstName, LastName) FROM Employees

--SELECT TOP(3) TRY_CAST(CustomerID AS int), CompanyName AS Combined2 FROM Customers
--UNION ALL
--SELECT TOP(3) EmployeeID, CONCAT_WS(' ',FirstName, LastName) FROM Employees

/* explicitly not allowed data types cannot be combined */
--SELECT TOP(3) TRY_CAST(CustomerID AS image) AS Combined1, CompanyName AS Combined2 FROM Customers
--UNION ALL
--SELECT TOP(3) TRY_CAST(EmployeeID AS image), CONCAT_WS(' ',FirstName, LastName) FROM Employees

SELECT TOP(3) CompanyName FROM Customers
UNION ALL
SELECT TOP(3) CONCAT_WS(' ',FirstName, LastName) AS Employee FROM Employees
ORDER BY 1
