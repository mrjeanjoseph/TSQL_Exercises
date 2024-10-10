USE Pluralsight
GO
-- Create NativeSP
CREATE OR ALTER PROCEDURE [NativeSP-Stream]
WITH NATIVE_COMPILATION
        ,SCHEMABINDING
        ,EXECUTE AS OWNER
AS
BEGIN ATOMIC
    WITH (
            TRANSACTION ISOLATION LEVEL = SNAPSHOT
			,LANGUAGE = 'us_english')
	SELECT mot1.ID, mot1.FName, mot2.LName
	FROM [dbo].[MemoryOptimizedTable] mot1
	INNER JOIN [dbo].[MemoryOptimizedTable] mot2 ON mot1.ID = mot2.ID
END
GO

-- Create Interpreted SP
CREATE OR ALTER PROCEDURE [InterpretedSP-Hash]
AS
	SELECT mot1.ID, mot1.FName, mot2.LName
	FROM [dbo].[DiskBasedTable] mot1
	INNER JOIN [dbo].[DiskBasedTable] mot2 ON mot1.ID = mot2.ID
GO

SET STATISTICS IO, TIME ON
GO
-- Execute SP
EXEC [NativeSP-Stream]
GO

EXEC [InterpretedSP-Hash]
GO

-- Execute SP
SET SHOWPLAN_XML ON  
GO

EXEC [NativeSP-Stream]
GO

SET SHOWPLAN_XML OFF  
GO

EXEC [InterpretedSP-Hash]
GO