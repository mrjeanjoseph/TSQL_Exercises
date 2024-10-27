USE Pluralsight
GO
-- Create first Native Compiled Stored Procedure
CREATE OR ALTER PROCEDURE [dbo].[NativeSP] @iID INT, @jID INT    
    WITH NATIVE_COMPILATION
        ,SCHEMABINDING
        ,EXECUTE AS OWNER
AS
BEGIN ATOMIC
    WITH (
    TRANSACTION ISOLATION LEVEL = SNAPSHOT
	,LANGUAGE = 'us_english')
	SELECT ID, FName, LName
	FROM [dbo].[MemoryOptimizedTable]
	WHERE ID >= @iID AND ID <= @jID
END
GO

SET STATISTICS IO, TIME ON
GO
-- Test 1 
EXEC [dbo].[NativeSP] 555, 555
GO

-- Test 2
EXEC [dbo].[NativeSP] 1000, 100000
GO

-- Test 3
EXEC [dbo].[NativeSP] 1234, 4321
GO


-- Create Interpreted T-SQL Stored Procedure
CREATE OR ALTER PROCEDURE [dbo].[InterpretedSP] @iID INT, @jID INT    
AS
BEGIN 
	SELECT ID, FName, LName
	FROM [dbo].[DiskBasedTable]
	WHERE ID >= @iID AND ID <= @jID
END
GO

-- Running SP
EXEC [dbo].[InterpretedSP] 555, 555
GO
EXEC [dbo].[InterpretedSP] 1000, 100000
GO
EXEC [dbo].[InterpretedSP] 1234, 4321
GO


