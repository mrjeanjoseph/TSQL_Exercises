--USE Northwind 

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
