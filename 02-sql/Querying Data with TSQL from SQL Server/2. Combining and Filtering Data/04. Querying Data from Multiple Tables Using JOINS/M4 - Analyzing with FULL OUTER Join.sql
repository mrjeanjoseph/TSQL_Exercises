
SELECT p.*, o.*, od.*
FROM Products p
	FULL OUTER JOIN  [Order Details] od ON od.ProductID = p.ProductID 
	FULL OUTER JOIN Orders o ON od.OrderID = o.OrderID
ORDER BY od.OrderID

SELECT p.ProductID, o.OrderID, od.OrderID 
FROM Products p
	FULL OUTER JOIN  [Order Details] od ON od.ProductID = p.ProductID 
	FULL OUTER JOIN Orders o ON od.OrderID = o.OrderID
ORDER BY od.OrderID,o.OrderID, p.ProductID


SELECT p.ProductID, o.OrderID AS Order_OrderID, od.OrderID AS Order_Details_OrderID
FROM Products p
	FULL OUTER JOIN  [Order Details] od ON od.ProductID = p.ProductID 
	FULL OUTER JOIN Orders o ON od.OrderID = o.OrderID
WHERE p.ProductID IS NULL OR o.OrderID IS NULL OR od.OrderID IS NULL

