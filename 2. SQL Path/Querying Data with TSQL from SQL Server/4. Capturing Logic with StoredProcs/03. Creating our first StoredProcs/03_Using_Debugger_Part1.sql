USE [BonRepos];
GO

DECLARE @RandomNumber int;

SELECT @RandomNumber = FLOOR(RAND()*(30-1+1))+1;

EXECUTE Sales.GenerateRandomMessage @RandomNumber = @RandomNumber;
GO



-- Great article for more information on the debugger
-- https://docs.microsoft.com/en-us/sql/ssms/scripting/transact-sql-debugger?view=sql-server-2017





CREATE OR ALTER FUNCTION fn_sumtwonums(@p1 INT,@p2 INT)
RETURNS INT
AS
BEGIN
	DECLARE @result INT
	SET @result = @p1 + @p2
	RETURN @result
END


DECLARE @Counter INT 
SET @Counter=1
WHILE ( @Counter <= 10)
BEGIN
    PRINT 'The counter value is = ' + CONVERT(VARCHAR,@Counter)
    SET @Counter  = @Counter+1
END