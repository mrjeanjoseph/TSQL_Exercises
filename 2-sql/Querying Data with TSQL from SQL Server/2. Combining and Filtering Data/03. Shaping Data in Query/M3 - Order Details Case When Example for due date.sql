
USE Northwind;



/*
How long does it take from the time an order was placed to when it was shipped?
DATEDIFF(interval, date from, date to) returns an INT data type
*/

--SELECT DATEDIFF(d, GETDATE(), '01/01/2060')
--SELECT DATEDIFF(YEAR, GETDATE(), '01/01/2060')
--SELECT DATEDIFF(n, GETDATE(), '01/01/2060')

--SELECT 
--		OrderId, 
--		CONVERT(VARCHAR,OrderDate, 101) AS OrderDate,
--		CONVERT(VARCHAR,ShippedDate, 101) AS ShippedDate,
--		DATEDIFF( d, OrderDate, ShippedDate ) AS ShippingTime
--FROM Orders

--SELECT 
--		OrderId, 
--		CASE WHEN OrderDate IS NULL THEN
--			'no order date'
--		ELSE 
--			CONVERT(VARCHAR,OrderDate, 101) END AS OrderDate,
--		CASE WHEN ShippedDate IS NULL THEN
--			'not shipped'
--		ELSE
--			CONVERT(VARCHAR,ShippedDate, 101) END AS ShippedDate,
--		CASE WHEN ShippedDate IS NULL THEN
--			0
--		ELSE
--			DATEDIFF( d, OrderDate, ShippedDate ) END AS ShippingTime
--FROM Orders


SELECT DATENAME(DW, '06/25/2021')

SELECT
	FORMAT(OrderDate, 'MM/dd/yyyy') AS OrderDate,
	FORMAT(DATEADD(d,14,OrderDate), 'MM/dd/yyyy') AS ShippingDueDate
FROM Orders
ORDER BY OrderDate DESC, ShippingDueDate DESC


SELECT @@DATEFIRST


SELECT
		OrderId,
		FORMAT(OrderDate, 'MM/dd/yyyy') AS OrderDate,
		CASE WHEN DATENAME(dw, DATEADD(d,14, OrderDate)) = 'Sunday' THEN
			FORMAT(DATEADD(d,15,OrderDate), 'MM/dd/yyyy')
		WHEN DATENAME (dw, DATEADD(d, 14, OrderDate)) = 'Saturday' THEN
			FORMAT(DATEADD(d,15,OrderDate), 'MM/dd/yyyy')
		ELSE
			FORMAT(DATEADD(d,14,OrderDate), 'MM/dd/yyyy')
		END AS ShippingDueDate
FROM Orders
WHERE ShippedDate IS NULL
ORDER BY ShippingDueDate DESC



--SELECT 
--	DATENAME(DW, '06/25/2021') AS DayName,
--	DATENAME(MONTH,'06/25/2021') AS MonthName,
--	DATENAME(YEAR,'06/25/2021') AS YearName