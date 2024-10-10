
/* REPORT:  
	Provide the top sales
	by quarter including total for each customer and the employee

	Add variables to create ad-hoc reporting query
*/
/* If the temp table exists, delete it */

IF OBJECT_ID('tempdb..#TMP') IS NOT NULL
    DROP TABLE #TMP;

--using variables
--declare the variables
DECLARE @all_sales AS BIT;
DECLARE @sales_quarter AS INT;
DECLARE @sales_year AS INT;
DECLARE @top AS INT;
DECLARE @company AS INT;
DECLARE @employee AS INT;
DECLARE @top_percent AS INT;
SET @all_sales = 0;
SET @sales_quarter = 1;
SET @sales_year = 2020;
IF @all_sales = 0
   AND @sales_quarter IS NULL
   AND @sales_year IS NULL
--this sets the most recent quarter and year
    BEGIN
        SELECT @sales_year = DATEPART(yy, MAX(orderdate))
        FROM Orders;
        SELECT @sales_quarter = MAX(DATEPART(q, orderdate))
        FROM orders
        WHERE DATEPART(yy, orderdate) = @sales_year;
    END;

SET @top = 100;
SET @top_percent = 100;
SET @employee = NULL; --8; -- When employee id = NULL, return all employees

SET @company = NULL; --When company id = NULL, return all companies
--uncomment this for testing what the variable values are
--SELECT @all_sales, 
--       @sales_quarter, 
--       @sales_year, 
--       @top, 
--       @company, 
--       @employee, 
--       @top_percent;

/*
	scratch pad testing.  
	Use this query to return values and check for accuracy.  
	Comment it out when you are ready to run the query 
*/

SELECT SUM((unitprice * Quantity) * (1 - Discount)) AS Sales_Volume, 
       COUNT(o.OrderID) AS Number_Sales, 
       c.CustomerID, 
       c.CompanyName, 
       e.EmployeeID, 
       CONCAT_WS(', ', ISNULL(TRIM(Lastname), 'unk'), ISNULL(TRIM(Firstname),'unk')) AS Employee, 
       DATEPART(q, o.OrderDate) AS Sales_Quarter, 
       DATEPART(yy, o.OrderDate) AS Sales_Year
INTO #TMP
FROM [Order Details] od
     JOIN Orders o ON o.OrderID = od.orderid
     JOIN customers c ON o.CustomerID = c.CustomerID
     JOIN Employees e ON o.EmployeeID = e.EmployeeID
GROUP BY DATEPART(yy, o.OrderDate), 
         DATEPART(q, o.OrderDate), 
         e.EmployeeID, 
         c.CustomerID, 
         e.LastName, 
         e.FirstName, 
         c.CompanyName
ORDER BY SUM((unitprice * Quantity) * (1 - Discount)) DESC, 
         DATEPART(yy, o.OrderDate), 
         DATEPART(q, o.OrderDate);

IF @all_sales = 0 --return based on parameters.
    BEGIN
        DELETE FROM #TMP
        WHERE Sales_Year != @sales_year
              AND Sales_Quarter != @sales_quarter;
    END;

IF @employee IS NOT NULL
    BEGIN
        DELETE FROM #TMP
        WHERE EmployeeID != @employee;
    END;

IF @top IS NOT NULL  --select the top X records
    BEGIN
        SELECT TOP (@top) FORMAT(Sales_Volume, 'C', 'en-us') AS Total_Sales, 
                          Number_Sales, 
                          CustomerID, 
                          CompanyName, 
                          EmployeeID, 
                          Employee, 
                          Sales_Quarter, 
                          Sales_Year
        FROM #TMP
        ORDER BY Sales_Volume DESC;
    END;
ELSE IF
     @top_percent IS NOT NULL  --select the top X percent of records
        BEGIN
            SELECT TOP (@top) PERCENT FORMAT(Sales_Volume, 'C', 'en-us') 
				AS Total_Sales, 
                                      Number_Sales, 
                                      CustomerID, 
                                      CompanyName, 
                                      EmployeeID, 
                                      Employee, 
                                      Sales_Quarter, 
                                      Sales_Year
            FROM #TMP
            ORDER BY Sales_Volume DESC;
        END;
ELSE
        BEGIN
            SELECT *
            FROM #TMP;
        END;