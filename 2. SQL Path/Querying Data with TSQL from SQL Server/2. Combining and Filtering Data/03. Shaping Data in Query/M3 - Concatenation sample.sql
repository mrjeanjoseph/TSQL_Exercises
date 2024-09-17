/* M3C3 Concatenation example */




/*Return the first and last names from the employees table*/
SELECT 
	FirstName + ' ' + LastName, -- string concatenation method
	CONCAT(FirstName,' ', LastName), --Concat method
	CONCAT_WS(' ',FirstName, LastName) --Concat with separator method
FROM Employees




/* CONCAT_WS will convert the values to characters.  The limitation is that you have only one parameter for the space
--preferred method if the spacing will be consistent */
SELECT CONCAT_WS('Employee: ', LastName,', ', FirstName) FROM Employees
/* USE CONCAT instead */
SELECT CONCAT('Employee: ', LastName,' ,', FirstName) FROM Employees



/* The + method returns NULL even if some of the fields have values */
SELECT 
	NULL + ' ' + LastName, -- string concatenation method
	CONCAT(NULL,FirstName,' ', LastName), --Concat method
	CONCAT_WS(' ',NULL,FirstName, LastName) --Concat with separator method
FROM Employees



/*
  1. The string concatenation method requires explicit casting on non-string values
  2. The work-around if you must use the string concatenation method, 
     is to use the server setting CONCAT_NULL_YIELDS_NULL (OFF / ON)
*/
SET CONCAT_NULL_YIELDS_NULL OFF
SELECT 
	NULL + ' ' + LastName, -- string concatenation method
	CONCAT(FirstName,' ', LastName), --Concat method
	CONCAT_WS(' ',FirstName, LastName) --Concat with separator method
FROM Employees




/* if the values AREN'T all numeric, then there will be an error */
SELECT 5 + ', ' + 4 + ', ' + 3 + ', ' + 2 + ', ' + 1 -- ERROR!: Non string values must be converted


/*Alias name */
SELECT CONCAT_WS(' ',FirstName ,LastName) AS [Employee Name] FROM Employees --Assign an alias field name to the concatenated column


/* part 1 of final report */

SELECT e.EmployeeID, 
       CONCAT_WS(', ', Lastname, Firstname) AS Employee  --Alias column name 
FROM Employees e --Alias table name (e)




DECLARE @salary AS Decimal(18,0)
SET @salary = 30000.00

IF
@salary <= ALL (
	SELECT 
		ROUND(Salary, 2)
	FROM
		HR_Information
)
PRINT CONCAT_WS(' ','All employees make', FORMAT(@salary,'c','en-us'), 'or more')
ELSE
PRINT CONCAT_WS(' ','Not all employees make', FORMAT(@salary,'c','en-us'), 'or more') 




SET @salary = 130000.00

IF
@salary >= ALL (
	SELECT 
		ROUND(Salary, 2)
	FROM
		HR_Information
	--where Salary >= @salary
)
PRINT CONCAT_WS(' ','No employees make', FORMAT(@salary,'c','en-us'), 'or more') 
ELSE
PRINT CONCAT_WS(' ','There are employees that make', FORMAT(@salary,'c','en-us'), 'or more')


--DECLARE @orderID AS int
--SET @orderID = 10

--IF
--@orderID = ANY(
--SELECT OrderID FROM Orders WHERE OrderID = @orderID
--)
--PRINT 'TRUE: Order found'
--ELSE
--PRINT 'FALSE: No order found'
--IF
--@orderID = ALL(
--SELECT OrderID FROM Orders WHERE OrderID = @orderID
--)
--PRINT 'TRUE: Order found'
--ELSE
--PRINT 'FALSE: No order found'
