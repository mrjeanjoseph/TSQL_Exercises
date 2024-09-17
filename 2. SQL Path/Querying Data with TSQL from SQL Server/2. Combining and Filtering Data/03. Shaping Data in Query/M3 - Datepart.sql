USE Northwind

DECLARE @all_sales AS BIT,@sales_quarter AS INT, @sales_year AS INT, 
	@top AS INT, @company AS INT, @employee AS INT, @top_percent AS INT
SET @all_sales = 0; SET @sales_quarter = 1; SET @sales_year = 2020
SET @all_sales = 0; SET @top = 10

IF OBJECT_ID('tempdb..#TMP') IS NOT NULL DROP TABLE #TMP;
--this sets the most recent quarter and year
    BEGIN
        SELECT @sales_year = DATEPART(yy, MAX(orderdate))
        FROM Orders;
        SELECT @sales_quarter = MAX(DATEPART(q, orderdate))
        FROM orders
        WHERE DATEPART(yy, orderdate) = @sales_year;
    END;

SET @top = 100; SET @top_percent = 100; 
SET @employee = 8;   -- When employee id = NULL, return all employees
SET @company = NULL; --When company id = NULL, return all companies

SELECT SUM(dbo.OrderAmountPurchased(o.OrderID)) AS Sales_Volume, 
       COUNT(o.OrderID) AS Number_Sales, 
       c.CustomerID, 
       c.CompanyName, 
       e.EmployeeID, 
       CONCAT_WS(', ', ISNULL(dbo.Proper(Lastname), 'unk'), ISNULL(dbo.Proper(Firstname),'unk')) AS Employee, 
       CASE WHEN DATEPART(q, o.OrderDate) IS NULL THEN 0
			ELSE DATEPART(q, o.OrderDate) END AS Sales_Quarter, 
		CASE WHEN DATEPART(yy, o.OrderDate) IS NULL THEN 0
			ELSE DATEPART(yy, o.OrderDate) END AS Sales_Year
INTO #TMP
FROM [Order Details] od
     JOIN Orders o ON o.OrderID = od.orderid
     JOIN customers c ON o.CustomerID = c.CustomerID
     JOIN Employees e ON o.EmployeeID = e.EmployeeID
GROUP BY DATEPART(yy, o.OrderDate), DATEPART(q, o.OrderDate), e.EmployeeID, 
         c.CustomerID, e.LastName, e.FirstName, c.CompanyName
ORDER BY SUM(dbo.OrderAmountPurchased(o.OrderID)) DESC, 
         DATEPART(yy, o.OrderDate) , 
         DATEPART(q, o.OrderDate);

IF @employee IS NOT NULL
    BEGIN
        SELECT FORMAT(Sales_Volume, 'C', 'en-us') AS Total_Sales,
			Number_Sales, 
			CompanyName, 
			Employee, 
            Sales_Quarter, 
			Sales_Year
		FROM #TMP
        WHERE EmployeeID = @employee
		ORDER BY Sales_Volume DESC END;
--IF @top IS NOT NULL  --select the top X records
--    BEGIN
--        SELECT TOP (@top) FORMAT(Sales_Volume, 'C', 'en-us') AS Total_Sales, 
--                          Number_Sales, CompanyName,  
--                          Employee, 
--						  CASE WHEN Sales_Quarter IS NULL THEN 0
--						  ELSE Sales_Quarter END AS Sales_Quarter, 
--						  CASE WHEN Sales_Year IS NULL THEN 0
--						  ELSE Sales_Year END AS Sales_Year
--        FROM #TMP
--        ORDER BY Sales_Volume DESC END;
--    ELSE
--    IF @top_percent IS NOT NULL  --select the top X percent of records
--        BEGIN
--            SELECT TOP (@top) PERCENT FORMAT(Sales_Volume, 'C', 'en-us') AS Total_Sales, 
--                              Number_Sales, 
--							  CompanyName, 
--							  Employee, 
--                              CASE WHEN Sales_Quarter IS NULL THEN 0
--									ELSE Sales_Quarter END AS Sales_Quarter, 
--							  CASE WHEN Sales_Year IS NULL THEN 0
--									ELSE Sales_Year END AS Sales_Year
--            FROM #TMP
--            ORDER BY Sales_Volume DESC;
--        END;
--        ELSE
--        BEGIN
--            SELECT *
--            FROM #TMP;
--		END;
