USE [WideWorldImporters]

UPDATE sales.orderlines 
SET quantity=quantity+1000 
WHERE orderID IN (
	SELECT TOP 100 OL.orderID FROM sales.orderlines OL
	INNER JOIN sales.orders O on ol.orderID = O.orderID
	WHERE o.OrderDate > DATEADD(DAY,-10,GETDATE())
	AND StockItemID=164)