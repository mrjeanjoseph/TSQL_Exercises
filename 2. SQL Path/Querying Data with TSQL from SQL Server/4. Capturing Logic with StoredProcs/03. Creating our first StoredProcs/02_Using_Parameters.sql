USE [BonRepos];
GO



-- Adding a flag to indicate if our sales person is active
ALTER TABLE Sales.SalesPerson ADD IsActive bit 
DEFAULT 1 WITH VALUES;
GO



-- Setting Tammy Smith to inactive
UPDATE Sales.SalesPerson SET IsActive = 0 WHERE Id = 10;
GO


-- Sproc with a default value
CREATE OR ALTER PROCEDURE Sales.GenerateSalesReport
  @ManagerEmail nvarchar(500),
  @IsActive bit = 1
AS
BEGIN
	SELECT CONCAT(sp.LastName, ', ',sp.FirstName) AS 'SalesPersonName'
		   ,sp.Email AS 'SalesPersonEmail'
		   ,spl.LevelName AS 'SalesPersonLevel'
		   ,SUM(so.SalesAmount) AS 'SalesAmount'
	FROM Sales.SalesPerson sp
	LEFT OUTER JOIN Sales.SalesOrder so ON so.SalesPerson = sp.Id
	INNER JOIN Sales.SalesPerson mgr ON mgr.Id = sp.ManagerId
	INNER JOIN Sales.SalesPersonLevel spl ON sp.LevelId = spl.Id
	WHERE mgr.Email = @ManagerEmail AND sp.IsActive = @IsActive
	GROUP BY sp.LastName, sp.FirstName, sp.Email, spl.LevelName;
END
GO



EXECUTE Sales.GenerateSalesReport @ManagerEmail = 'Sally.Smith@bonrepos.ht';
GO



EXECUTE Sales.GenerateSalesReport 'Tom.Jones@bonrepos.ht';
GO


-- Override the default
EXECUTE Sales.GenerateSalesReport @ManagerEmail = 'Sally.Smith@bonrepos.ht'
								  ,@IsActive = 0;
GO



-- Output parameter
CREATE OR ALTER PROCEDURE Sales.ReturnSalesPersonId
  @EmployeeEmail nvarchar(500),
  @EmployeeId int OUTPUT
AS
BEGIN
	SELECT @EmployeeId = Id 
	FROM Sales.SalesPerson sp
	WHERE Email = @EmployeeEmail;
END
GO



-- Selecting the output parameter
DECLARE @EmployeeId int; 

EXECUTE Sales.ReturnSalesPersonId @EmployeeEmail = 'Sally.Smith@bonrepos.ht'
								  ,@EmployeeId = @EmployeeId OUTPUT;

SELECT @EmployeeId;
GO