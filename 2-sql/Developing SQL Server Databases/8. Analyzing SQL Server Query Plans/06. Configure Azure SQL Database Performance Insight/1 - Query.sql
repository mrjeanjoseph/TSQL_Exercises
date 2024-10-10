SELECT *
FROM [SalesLT].[Product]
CROSS JOIN [SalesLT].[ProductCategory]
CROSS JOIN [SalesLT].[ProductDescription]
CROSS JOIN [SalesLT].[ProductModel]
GO
RETURN;

SELECT p.Color, p.DiscountinuedDate, sod.LineTotal, * 
FROM LargeTable sod
INNER JOIN [SalesLT].[Product] p
	ON p.[ProductID] = sod.[ProductID]
WHERE sod.LineTotal = 1717.800000
GO
RETURN;

INSERT INTO LargeTable ([SalesOrderID], [OrderQty], [ProductID], [UnitPrice], [UnitPriceDiscount], [ModifiedDate])
SELECT [SalesOrderID], [OrderQty], [ProductID], [UnitPrice], [UnitPriceDiscount], [ModifiedDate]
FROM [SalesLT].[SalesOrderDetail]
GO

SELECT * FROM [SalesLT].[Product] CROSS JOIN [SalesLT].[ProductCategory]