USE Northwind

DECLARE @intDays AS int
DECLARE @recordsReturned AS bit
SET @recordsReturned = 0
SET @intDays = 21

IF   
@recordsReturned > ALL  
   (  
	SELECT DATEDIFF(d, OrderDate, ShippedDate)
	FROM Orders
	WHERE OrderDate IS NOT NULL
	AND ShippedDate IS NOT NULL
	AND DATEDIFF(d, OrderDate, ShippedDate) >  @intDays
   )  
PRINT CONCAT_WS(' ', 'TRUE:','All orders were shipped within',@intDays,'days.')
ELSE   
PRINT CONCAT_WS(' ', 'FALSE:','Not all orders were shipped within',@intDays,'days.')


IF   
@recordsReturned = ALL  
   (  
	SELECT ShippedDate
	FROM Orders
	WHERE OrderDate IS NOT NULL
	AND ShippedDate IS NULL
   )  
PRINT 'TRUE: All orders have been shipped'
ELSE   
PRINT 'FALSE: There are orders that have not been shipped'
