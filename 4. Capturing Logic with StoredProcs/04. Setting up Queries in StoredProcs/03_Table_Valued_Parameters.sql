USE [ABCCompany];
GO




-- Creating the table type
CREATE TYPE SalesPersonId AS TABLE (SalesPersonId int);
GO



-- Creating stored procedure with a table type
CREATE OR ALTER PROCEDURE Sales.SalesPersonDetail
@SalesPersonInput SalesPersonId READONLY
AS
BEGIN

	SELECT CONCAT(LastName,', ',FirstName) AS 'FullName'
		   ,SalaryHr AS 'SalaryPerHour'
		   ,StartDate AS 'StartDate'
	FROM Sales.SalesPerson sp
	INNER JOIN @SalesPersonInput spi ON sp.Id = spi.SalesPersonId; 

END
GO



-- Declare an instance of our table type
DECLARE @SalesPersonInput SalesPersonId;

-- Insert some sales people
INSERT INTO @SalesPersonInput VALUES (1001);
INSERT INTO @SalesPersonInput VALUES (85);
INSERT INTO @SalesPersonInput VALUES (32);
INSERT INTO @SalesPersonInput VALUES (45);
INSERT INTO @SalesPersonInput VALUES (987);

-- Pass in as a table-valued parameter
EXECUTE Sales.SalesPersonDetail @SalesPersonInput;
GO



-- Remove a table type
DROP TYPE SalesPersonId;
GO