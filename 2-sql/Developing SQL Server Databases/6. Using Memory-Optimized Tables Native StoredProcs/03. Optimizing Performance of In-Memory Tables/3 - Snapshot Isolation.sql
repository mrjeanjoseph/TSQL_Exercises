USE [Pluralsight]
GO
-- Check current isolation level
DBCC useroptions
GO

-- Selects with Auto Commit
SELECT *
FROM [dbo].[MemoryOptimizedTable]
GO
SELECT *
FROM [dbo].[DiskBasedTable]
GO

-- Selects with Auto Commit
SELECT *
FROM [dbo].[MemoryOptimizedTable] mt 
INNER JOIN [dbo].[DiskBasedTable] dt ON mt.ID = dt.ID
GO

-- Selects with Explicit Commit
-- will generate error
BEGIN TRANSACTION 

SELECT *
FROM [dbo].[MemoryOptimizedTable] mt 
INNER JOIN [dbo].[DiskBasedTable] dt ON mt.ID = dt.ID
GO

COMMIT TRANSACTION

GO

-- Change isolation to MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT
-- for Cross Container Transactions
ALTER DATABASE CURRENT  
    SET MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = ON
GO

-- Check isolation level
SELECT 
	[name], 
	[is_read_committed_snapshot_on], 
	[is_memory_optimized_elevate_to_snapshot_on]
FROM sys.databases

-- Selects with Explicit Commit
BEGIN TRANSACTION 
SELECT *
FROM [dbo].[MemoryOptimizedTable] mt 
INNER JOIN [dbo].[DiskBasedTable] dt ON mt.ID = dt.ID
GO
COMMIT TRANSACTION
GO