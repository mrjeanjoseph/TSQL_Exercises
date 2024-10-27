
SELECT 
       CASE WHEN o.OrderID IS NULL THEN
			'No purchases'
	   ELSE
			CAST(o.OrderID AS varchar)
	   END AS OrderID,

	   CASE WHEN o.OrderDate IS NULL THEN
			'N/A'
	   ELSE
			FORMAT(o.OrderDate,'d', 'en-US')
	   END AS OrderDate,

	   CASE WHEN o.ShippedDate IS NULL THEN
			'N/A'
	   ELSE
			FORMAT(o.ShippedDate,'d', 'en-US')
	   END AS ShippedDate,

	   CASE WHEN o.ShipAddress IS NULL THEN
			'N/A'
	   ELSE
			o.ShipAddress
	   END AS ShipAddress,

	   CASE WHEN p.ProductName IS NULL THEN
			'N/A'
	   ELSE
			p.ProductName
	   END AS ProductName,

	   CASE WHEN od.UnitPrice IS NULL THEN
			'0'
	   ELSE
			FORMAT(od.UnitPrice, 'C', 'en-US')
	   END AS UnitPrice,
	   CASE WHEN od.Quantity IS NULL THEN
			'0'
	   ELSE
			FORMAT(od.Quantity, 'C', 'en-US')
	   END AS Quantity,
	   CASE WHEN od.Discount IS NULL THEN
			'0'
	   ELSE
			FORMAT(od.Discount, 'C', 'en-US')
	   END AS Discount,

	   CASE WHEN od.UnitPrice IS NULL OR od.Discount IS NULL
			OR od.Quantity IS NULL THEN
			'0'
	   ELSE
			FORMAT((od.unitprice * Quantity) - (od.unitprice * Quantity * Discount), 'C', 'en-us')
	   END AS Product_Cost       
FROM Products p
	FULL OUTER JOIN  [Order Details] od ON od.ProductID = p.ProductID 
	FULL OUTER JOIN Orders o ON od.OrderID = o.OrderID
ORDER BY od.OrderID

