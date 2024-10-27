USE [BonRepos];
GO

/*
Notes from Alani
A script for adding a new sales person
1) Remember we no longer use a period between first name and last name on the email
2) If we don't know their start date just use today
3) If we don't know the levelId use 3 for staff
*/
INSERT INTO Sales.SalesPerson (FirstName, LastName, SalaryHr, ManagerId, LevelId, Email, StartDate)
VALUES ('Tony','Stark',500,1,3,'TonyStark@bonrepos.ht','8/17/2019');
GO
    


CREATE OR ALTER PROCEDURE Sales.InsertSalesPerson
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

			INSERT INTO Sales.SalesPerson (FirstName, LastName, SalaryHr, ManagerId, LevelId, Email, StartDate)
			VALUES (@FirstName, @LastName, @SalaryHr, @ManagerId, @LevelId, @SalesPersonEmail, @SalesPersonStart)

		COMMIT TRANSACTION;

END
GO



-- Now let's run this procedure
EXECUTE Sales.InsertSalesPerson @FirstName = 'Kervens', 
								@LastName = 'Jean-Joseph', 
								@SalaryHr = 600, 
								@ManagerId = 1, 
								@StartDate = NULL;
GO


SELECT * FROM Sales.SalesPerson
WHERE Email = 'kervenjean-joseph@bonrepos.ht';
GO