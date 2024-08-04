USE [Pluralsight]
GO
-- Memory Optimized Index
CREATE TABLE [MemoryOptimizedTable_I_Mem] (
    ID INT IDENTITY NOT NULL 
		PRIMARY KEY NONCLUSTERED 
    ,FName VARCHAR(20) NOT NULL
    ,LName VARCHAR(20) NOT NULL
    )
    WITH ( MEMORY_OPTIMIZED = ON, DURABILITY = SCHEMA_AND_DATA )
GO

-- Hash Index
CREATE TABLE [MemoryOptimizedTable_I_Hash] (
    ID INT IDENTITY NOT NULL 
		PRIMARY KEY NONCLUSTERED HASH WITH (BUCKET_COUNT = 1000000)
    ,FName VARCHAR(20) NOT NULL
    ,LName VARCHAR(20) NOT NULL
    )
    WITH ( MEMORY_OPTIMIZED = ON, DURABILITY = SCHEMA_AND_DATA )
GO

-- Inserting Data
INSERT INTO [MemoryOptimizedTable_I_Mem] (FName, LName)
SELECT TOP 500000
	'Bob',				
	CASE
		WHEN ROW_NUMBER() OVER (ORDER BY a.name)%123456 = 1 THEN 'Baker' 
		WHEN ROW_NUMBER() OVER (ORDER BY a.name)%10 = 1 THEN 'Marley' 
		WHEN  ROW_NUMBER() OVER (ORDER BY a.name)%10 = 5 THEN 'Ross' 
		WHEN  ROW_NUMBER() OVER (ORDER BY a.name)%10 = 3 THEN 'Dylan' 
	ELSE 'Hope' END
FROM sys.all_objects a
CROSS JOIN sys.all_objects b
GO

INSERT INTO [MemoryOptimizedTable_I_Hash] (FName, LName)
SELECT TOP 500000
	'Bob', 					
	CASE
		WHEN ROW_NUMBER() OVER (ORDER BY a.name)%123456 = 1 THEN 'Baker' 
		WHEN ROW_NUMBER() OVER (ORDER BY a.name)%10 = 1 THEN 'Marley' 
		WHEN  ROW_NUMBER() OVER (ORDER BY a.name)%10 = 5 THEN 'Ross' 
		WHEN  ROW_NUMBER() OVER (ORDER BY a.name)%10 = 3 THEN 'Dylan' 
	ELSE 'Hope' END
FROM sys.all_objects a
CROSS JOIN sys.all_objects b
GO

SET STATISTICS IO, TIME ON
-- Test 1
-- Index on Identity Only
SELECT *
FROM [MemoryOptimizedTable_I_Mem]
WHERE LName BETWEEN 'A' AND 'E'
GO

SELECT *
FROM [MemoryOptimizedTable_I_Hash]
WHERE LName BETWEEN 'A' AND 'E'
GO

-- ---------------------------------------------
-- Creating Index on LName
-- Memory Optimized Index
ALTER TABLE [MemoryOptimizedTable_I_Mem]  
     ADD INDEX  IX_MOT_I_Mem  
     NONCLUSTERED (LName);  
GO

-- Hash Index
ALTER TABLE [MemoryOptimizedTable_I_Hash]  
    ADD INDEX IX_MOT_I_Hash  
    HASH (LName) WITH (BUCKET_COUNT = 128);  
GO


-- Test 2
-- Index on LastName Only RANGE
SELECT *
FROM [MemoryOptimizedTable_I_Mem]
WHERE LName BETWEEN 'A' AND 'E'
GO

SELECT *
FROM [MemoryOptimizedTable_I_Hash]
WHERE LName BETWEEN 'A' AND 'E'
GO

-- Test 2
-- Index on LastName Equality
SELECT *
FROM [MemoryOptimizedTable_I_Mem]
WHERE LName = 'Baker'
GO

SELECT *
FROM [MemoryOptimizedTable_I_Hash]
WHERE LName = 'Baker'
GO
