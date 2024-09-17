USE Pluralsight
GO

-- Create first Native Compiled Stored Procedure
CREATE OR ALTER PROCEDURE [dbo].[NativeSP1] @iID INT, @jID INT    
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

-- Create first Native Compiled Stored Procedure
CREATE OR ALTER PROCEDURE [dbo].[NativeSP2] @iID INT, @jID INT    
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

-- Create first Native Compiled Stored Procedure
CREATE OR ALTER PROCEDURE [dbo].[NativeSP3] @iID INT, @jID INT    
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

-- Execute Stored Procedures for Test
EXEC [dbo].[NativeSP1] 555, 555
GO 6
EXEC [dbo].[NativeSP2] 1000, 100000
GO 4
EXEC [dbo].[NativeSP3] 1234, 4321
GO 2

-- Collecting Proc Level Statistics
SELECT  OBJECT_ID,
        OBJECT_NAME(OBJECT_ID) AS [object name],
        cached_time, last_execution_time, execution_count,
        total_worker_time, last_worker_time,
        min_worker_time, max_worker_time,
        total_elapsed_time, last_elapsed_time,
        min_elapsed_time, max_elapsed_time
FROM sys.dm_exec_procedure_stats
WHERE database_id = DB_ID() AND
        OBJECT_ID IN
            (   SELECT OBJECT_ID
                FROM sys.sql_modules
                WHERE uses_native_compilation=1)
ORDER BY total_worker_time DESC;
GO

-- Collecting Query Level Statistics
SELECT st.objectid,
       OBJECT_NAME(st.objectid) AS [object name],
       SUBSTRING(st.text,
            (qs.statement_start_offset/2) + 1,
            ((qs.statement_end_offset-qs.statement_start_offset)/2) + 1
            ) AS [query text],
       qs.creation_time, qs.last_execution_time, qs.execution_count,
       qs.total_worker_time, qs.last_worker_time,
       qs.min_worker_time, qs.max_worker_time,
       qs.total_elapsed_time, qs.last_elapsed_time,
       qs.min_elapsed_time, qs.max_elapsed_time
FROM sys.dm_exec_query_stats qs
		 CROSS APPLY sys.dm_exec_sql_text(sql_handle) st
WHERE st.dbid = DB_ID() AND
        st.objectid IN
            (	SELECT OBJECT_ID
                FROM sys.sql_modules
                WHERE uses_native_compilation=1)
ORDER BY qs.total_worker_time DESC;
GO


-- Execution Plan
SET SHOWPLAN_XML ON  
GO  
EXEC [dbo].[NativeSP1] 555, 555
GO 
SET SHOWPLAN_XML OFF  
GO  