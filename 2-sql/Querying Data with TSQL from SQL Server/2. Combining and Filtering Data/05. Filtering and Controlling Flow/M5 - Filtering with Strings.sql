USE Northwind

--SELECT 
--	c.CompanyName,
--	o.OrderID
--FROM Customers c
--LEFT JOIN Orders o ON o.CustomerID = c.CustomerID
--WHERE CompanyName = 'Alfreds Futterkiste'
--ORDER BY c.CompanyName


/* all records where the last name equals 'Davilio' */
SELECT 
	* 
FROM Employees
WHERE LastName = 'Davolio'
ORDER BY LastName

/* all records where the last name is not equal to 'Davilio' */
SELECT 
	* 
FROM Employees
WHERE LastName != 'Davolio'
ORDER BY LastName


/* all alpha and any string values alpha greater than 'Davilio' (alphabeticaly)*/
SELECT 
	* 
FROM Employees
WHERE LastName > 'Davolio'
ORDER BY LastName

/* all alpha values = 'Davolio' and any string values alpha greater than (alphabetical order)*/
SELECT 
	* 
FROM Employees
WHERE LastName >= 'Davolio'
ORDER BY LastName


/* all alpha values = 'Davolio' and any string values less than 'Davilio' (alphabetical order)*/
SELECT 
	* 
FROM Employees
WHERE LastName < 'Davolio'

/* all alpha values = 'Davolio' and any string values alpha greater than (alphabetical order)*/
SELECT 
	* 
FROM Employees
WHERE LastName <= 'Davolio'
ORDER BY LastName

/* using LIKE with wildcard */
SELECT 
	* 
FROM Employees
WHERE LastName LIKE 'D%'
ORDER BY LastName

/* using NOT LIKE with wildcard */
SELECT 
	* 
FROM Employees
WHERE LastName NOT LIKE 'D%'
ORDER BY LastName



SELECT 
	* 
FROM Employees
WHERE LastName = 'Davolio'
ORDER BY LastName

UPDATE Employees SET HireDate = GETDATE() -- Original date '2015-05-01 00:00:00.000'
WHERE EmployeeID = 1

/*must cast before this will work.  GETDATE() is current date and time*/
SELECT
	* 
FROM Employees
WHERE HireDate = GETDATE()


SELECT GETDATE()

SELECT
	* 
FROM Employees
WHERE CAST(HireDate AS varchar(11)) = CAST(GETDATE() AS varchar(11))









