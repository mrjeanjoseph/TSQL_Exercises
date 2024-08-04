USE Northwind

SELECT * FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
ORDER BY o.OrderID

SELECT 
	o.OrderId, 
	OrderDate, 
	ShippedDate, 
	ShipAddress,
	Unitprice,
	Quantity,
	Discount
FROM Orders o  
	JOIN [Order Details] od ON o.OrderID = od.OrderID

SELECT DISTINCT OrderID from [Order Details] --return the DISTINCT orderID from Order Details
SELECT OrderId from Orders  --return all of the records from ORDERS

SELECT COUNT(*) FROM Orders
SELECT COUNT(DISTINCT OrderId) FROM [Order Details]





SELECT * FROM Products
SELECT DISTINCT ProductId FROM [Order Details]

--SELECT COUNT(*)FROM Products
--SELECT COUNT(DISTINCT ProductId) FROM [Order Details]

--SELECT 
--		p.ProductName,
--		COUNT(p.ProductID) AS NumberOfProductsSold,
--		CASE WHEN od.ProductID IS NULL
--		THEN 'Not Sold'
--		ELSE CAST(od.ProductID AS varchar) END 
--	AS orderdetailsProductID,
--	p.ProductID
--	FROM Products p LEFT JOIN [Order Details] od
--	ON p.ProductID = od.ProductID
--	GROUP BY od.ProductID,p.ProductName,p.ProductID
--	ORDER BY NumberOfProductsSold




--SELECT 
--	DISTINCT COUNT(od.ProductId) AS ProductsOrdered--,
--	--COUNT(p.ProductId) AS Products
--FROM Products p
--LEFT JOIN [Order Details] od ON p.ProductId = od.ProductId
