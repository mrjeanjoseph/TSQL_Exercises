USE Northwind
/* Using Union All to combine result sets */


/* order by needs to be added below the last query*/
--SELECT City FROM Customers
--UNION
--SELECT City FROM Employees
--WHERE City IS NOT NULL
--ORDER BY 1

--SELECT c.City,
--	   e.City
--FROM Customers c
--FULL OUTER JOIN Employees e ON c.City = e.City


/* order by needs to be added below the last query*/
SELECT City, 'Customers' AS [Originating Table] FROM Customers
UNION
SELECT City, 'Employees Table' FROM Employees
WHERE City IS NOT NULL
ORDER BY 1

