/* Sales volume by quarter and year */
IF OBJECT_ID('tempdb..#TMP') IS NOT NULL
DROP TABLE #TMP;
DECLARE @all_sales AS BIT,@sales_quarter AS INT, @sales_year AS INT, @top AS INT;
DECLARE @company AS INT, @employee AS INT, @top_percent AS INT
SET @all_sales = 0 SET @sales_year = 2019
--this sets the most recent quarter and year
IF @all_sales = 0 --find the most recent quarter and year
    BEGIN
        SELECT @sales_year = DATEPART(yy, MAX(orderdate))
        FROM Orders;
        SELECT @sales_quarter = MAX(DATEPART(q, orderdate))
        FROM orders
        WHERE DATEPART(yy, orderdate) = @sales_year;
    END;
--SELECT @sales_quarter, @sales_year
SELECT  FORMAT(SUM((unitprice * Quantity) * (1 - Discount)),'C','en-us') AS Sales_Volume, 
		SUM((unitprice * Quantity) * (1 - Discount)) AS Unformatted,
		COUNT(o.OrderID) AS Number_Sales, 
		CASE WHEN e.EmployeeID IS NULL THEN
			'unknown'
		ELSE		
			CONCAT_WS(', ', TRIM(Lastname), TRIM(Firstname)) 
		END AS Employee, 
		c.CustomerID, c.CompanyName, e.EmployeeID,  
		DATEPART(q, o.OrderDate) AS Sales_Quarter, 
		DATEPART(yy, o.OrderDate) AS Sales_Year
INTO #TMP
FROM [Order Details] od
     JOIN Orders o ON o.OrderID = od.OrderID 
	 JOIN customers c ON o.CustomerID = c.CustomerID
     JOIN Employees e ON o.EmployeeID = e.EmployeeID
WHERE  DATEPART(yy, o.OrderDate) = @sales_year
GROUP BY DATEPART(yy, o.OrderDate), DATEPART(q, o.OrderDate), 
		 e.EmployeeID, c.CustomerID, e.LastName, e.FirstName, c.CompanyName
ORDER BY SUM((unitprice * Quantity) * (1 - Discount)) DESC,DATEPART(yy, o.OrderDate) DESC, DATEPART(q, o.OrderDate);
SELECT Sales_Volume, Number_Sales, Employee, CompanyName,Sales_Quarter, Sales_Year FROM #TMP ORDER BY Unformatted DESC
SELECT * FROM #TMP ORDER BY Unformatted DESC FOR JSON AUTO
SELECT * FROM #TMP ORDER BY Unformatted DESC FOR XML AUTO

