USE Northwind

SELECT * FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
ORDER BY o.OrderID

SELECT  
	OrderDate, 
	ShippedDate, 
	ShipAddress,
	Unitprice,
	Quantity,
	Discount
FROM Orders o
	JOIN [Order Details] od ON o.OrderID = od.OrderID


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



SELECT DISTINCT ProductId FROM [Order Details]
SELECT ProductId FROM Products

SELECT DISTINCT OrderID from [Order Details]
SELECT OrderId from Orders

SELECT 
	DISTINCT COUNT(p.productId) AS NumberOfProductsSold,
		p.productname,
		CASE WHEN od.ProductID IS NULL
		THEN 'Not Sold'
		ELSE CAST(od.ProductID AS varchar) END 
	AS orderdetailsProductID
	FROM Products p LEFT JOIN [Order Details] od
	ON p.ProductID = od.ProductID
	GROUP BY od.ProductID,p.ProductName
	ORDER BY NumberOfProductsSold DESC

