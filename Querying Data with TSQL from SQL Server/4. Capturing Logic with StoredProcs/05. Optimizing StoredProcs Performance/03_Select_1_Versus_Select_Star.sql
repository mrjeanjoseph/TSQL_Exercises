USE [BonRepos];
GO



-- Insert a new sales people or update the salary
CREATE OR ALTER PROCEDURE Sales.InsertUpdateSalesPerson
	@FirstName nvarchar(500),
	@LastName nvarchar(500),
	@SalaryHr decimal(32,2),
	@ManagerId int,
	@LevelId int = 3,
	@StartDate date
AS
BEGIN

	SET NOCOUNT ON;		
		
		BEGIN TRANSACTION;

			DECLARE @SalesPersonEmail nvarchar(500);
			DECLARE @SalesPersonStart date;

			SELECT @SalesPersonEmail = CONCAT(@FirstName,@LastName,'@bonrepos.ht');
			SELECT @SalesPersonStart = ISNULL(@StartDate,GETDATE());

			IF NOT EXISTS (SELECT 1 FROM Sales.SalesPerson WHERE Email = @SalesPersonEmail)
				
				BEGIN
			
					INSERT INTO Sales.SalesPerson (FirstName, LastName, SalaryHr, ManagerId, LevelId, Email, StartDate)
					VALUES (@FirstName, @LastName, @SalaryHr, @ManagerId, @LevelId, @SalesPersonEmail, @SalesPersonStart);

				END
			
			ELSE
			
				BEGIN

					UPDATE Sales.SalesPerson SET SalaryHr = @SalaryHr;

						PRINT 'Salary Updated';

				END

		COMMIT TRANSACTION;

END
GO





-- Bruce already exists
EXECUTE Sales.InsertUpdateSalesPerson @FirstName = 'Veleenah', 
								      @LastName = 'Jean-Joseph', 
								      @SalaryHr = 545, 
								      @ManagerId = 1, 
								      @StartDate = NULL;
GO



-- How can we determine if select * and select 1 are the same
-- Checking statistics and the execution plan
SET STATISTICS IO ON;

IF EXISTS (SELECT 1 FROM Sales.SalesPerson WHERE Email = 'veleenahjeanjoseph@bonrepos.ht')
	BEGIN
		PRINT 'Veleenah is already here!';
	END

SET STATISTICS IO OFF;
GO



-- Checking statistics and the execution plan
SET STATISTICS IO ON;

IF EXISTS (SELECT * FROM Sales.SalesPerson WHERE Email = 'veleenahjeanjoseph@bonrepos.ht')
	BEGIN
		PRINT 'Veleenah is already here!';
	END

SET STATISTICS IO OFF;
GO




-- How can we determine if select * and select 1 are the same
-- Checking statistics and the execution plan
SET STATISTICS IO ON;

IF EXISTS (SELECT 1 FROM Sales.SalesOrder WHERE Id = 1)
	BEGIN
		PRINT 'This is Select 1';
	END

SET STATISTICS IO OFF;
GO



-- Checking statistics and the execution plan
SET STATISTICS IO ON;

IF EXISTS (SELECT * FROM Sales.SalesOrder WHERE Id = 1)
	BEGIN
		PRINT 'This is Select *';
	END

SET STATISTICS IO OFF;
GO