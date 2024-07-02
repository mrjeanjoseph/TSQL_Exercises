USE Northwind
/* M5C2 - Introduction to where - */
DECLARE @orderID AS int
SET @orderID = 10260

/*equal to*/
SELECT 
	* 
FROM Orders
WHERE OrderID = 10260
ORDER BY OrderID
/* not equal to*/
SELECT 
	* 
FROM Orders
WHERE OrderID != 10260
ORDER BY OrderID
/* greater than*/
SELECT 
	* 
FROM Orders
WHERE OrderID > 10260
ORDER BY OrderID

/* greater than or equal to*/
SELECT 
	* 
FROM Orders
WHERE OrderID >= 10260
ORDER BY OrderID

/* less than*/
SELECT 
	* 
FROM Orders
WHERE OrderID < 10260
ORDER BY OrderID

/* less than or equal to*/
SELECT 
	* 
FROM Orders
WHERE OrderID >= 10260
ORDER BY OrderID
/* WHERE using a variable */
SELECT 
	* 
FROM Orders
WHERE OrderID = @orderID
ORDER BY OrderID

/* using a stored procedure */
EXEC FindOrder @orderID

