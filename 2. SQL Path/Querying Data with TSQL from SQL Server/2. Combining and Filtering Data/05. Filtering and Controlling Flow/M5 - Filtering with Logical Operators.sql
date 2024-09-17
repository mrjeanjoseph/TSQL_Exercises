USE Northwind
/* Filtering with Expressions and Logical Operators */

SELECT 
	* 
FROM Employees
ORDER BY Title, City

SELECT 
	* 
FROM Employees 
WHERE LastName = 'Davolio'

SELECT 
	* 
FROM Employees
WHERE Title = 'Sales Representative' AND City = 'London'
ORDER BY Title,City


SELECT 
	* 
FROM Employees
WHERE Title = 'Sales Representative' OR City = 'London'
ORDER BY Title,City



SELECT 
	* 
FROM Employees
WHERE 
(Title = 'Sales Representative' AND City = 'London') 
OR
(Title != 'Sales Representative' AND City = 'Tacoma')
ORDER BY Title,City



SELECT 
	* 
FROM Employees
WHERE LastName != 'Davolio' AND LastName != 'FULLER' AND LastName != 'Leverling'
ORDER BY LastName



SELECT 
	* 
FROM Employees
WHERE LastName != 'Davolio' OR LastName != 'FULLER' OR LastName != 'Leverling'
ORDER BY LastName

/*best practice*/
SELECT 
	* 
FROM Employees
WHERE LastName IN ('Davolio' ,'FULLER', 'Leverling')
ORDER BY LastName

SELECT 
	* 
FROM Employees
WHERE LastName NOT IN ('Davolio' ,'FULLER', 'Leverling')
ORDER BY LastName

/* all alpha values = 'Davolio' and any string values alpha greater than or equal to(alphabetical order)*/
SELECT 
	* 
FROM Employees
WHERE LastName >= 'Davolio' AND LastName <= 'Leverling'
ORDER BY LastName

SELECT 
	* 
FROM Employees
WHERE LastName BETWEEN 'Davolio' AND 'Leverling'
ORDER BY LastName

SELECT 
	* 
FROM Employees
WHERE LastName BETWEEN 'Leverling' AND 'Davolio'
ORDER BY LastName

SELECT 
	* 
FROM Employees
WHERE LastName NOT BETWEEN 'Davolio' AND 'Leverling' 
ORDER BY LastName







DECLARE @begin AS INT
DECLARE @end AS INT
SET @begin = -7
SET @end = -1

--SELECT
--DATEPART(yyyy,DATEADD(yyyy,@begin, GETDATE())), DATEPART(yyyy,DATEADD(yyyy,@end, GETDATE()))


--SELECT
--	DATEPART(yyyy,HireDate),
--	DATEADD(yyyy,@begin, GETDATE()),
--	DATEADD(yyyy,@end, GETDATE()) ,
--	* 
--FROM Employees
--WHERE  DATEPART(yyyy,HireDate) BETWEEN DATEPART(yyyy,DATEADD(yyyy,@begin, GETDATE())) AND DATEPART(yyyy,DATEADD(yyyy,@end, GETDATE())) 

SELECT
	DATEPART(yyyy,HireDate),
	DATEADD(yyyy,@begin, GETDATE()),
	DATEADD(yyyy,@end, GETDATE()) ,
	* 
FROM Employees
WHERE  DATEPART(yyyy,HireDate) BETWEEN DATEPART(yyyy,DATEADD(yyyy,@end, GETDATE())) AND DATEPART(yyyy,DATEADD(yyyy,@begin, GETDATE())) 







