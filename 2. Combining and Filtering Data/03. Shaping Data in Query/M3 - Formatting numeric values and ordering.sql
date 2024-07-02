

/* the sum of each order using the user defined function, OrderAmountPurchased(OrderId) */
SELECT 
	OrderID,
	dbo.OrderAmountPurchased(OrderId)
FROM [Order Details]
ORDER BY dbo.OrderAmountPurchased(OrderId) DESC

/* using a formatted field to order by will not return the expected results */
SELECT 
	OrderID,
	FORMAT(dbo.OrderAmountPurchased(OrderId), 'c', 'en-us') AS OrderTotal
FROM [Order Details]
ORDER BY OrderTotal DESC

/*using format and ordering without formatting will return the correct result set */
SELECT 
	OrderID,
	FORMAT(dbo.OrderAmountPurchased(OrderId), 'c', 'en-us') AS OrderTotal
FROM [Order Details]
ORDER BY dbo.OrderAmountPurchased(OrderId) DESC

