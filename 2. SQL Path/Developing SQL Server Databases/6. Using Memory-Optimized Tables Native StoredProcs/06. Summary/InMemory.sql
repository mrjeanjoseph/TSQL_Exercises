USE [master];
GO
-- ------------------------------------------------------
-- How to get started with OLTP In-Memory Table?
-- Subscribe to newsletter at https://go.sqlauthority.com 
-- Questions: pinal@sqlauthority.com 
-- ------------------------------------------------------

/*
Simple demo to showcase Memory Optimized Data with SQL Server
*/

SET STATISTICS IO ON
GO

CREATE DATABASE InMemory
ON PRIMARY(NAME = InMemoryData, 
FILENAME = 'C:\devtrunk\sql-files\InMemoryData.mdf', size=200MB), 
-- Memory Optimized Data
FILEGROUP [InMem_FG] CONTAINS MEMORY_OPTIMIZED_DATA(
NAME = [InMemory_InMem_dir], 
FILENAME = 'C:\devtrunk\sql-files\InMemory_InMem_dir') 
--
LOG ON (name = [InMem_demo_log], Filename='C:\devtrunk\sql-files\InMemory.ldf', size=100MB)
GO

USE InMemory
GO
-- Create a Simple Table
CREATE TABLE DummyTable (ID INT NOT NULL PRIMARY KEY, 
Name VARCHAR(100) NOT NULL)

-- Create a Memeory Optimized Table
CREATE TABLE DummyTable_Mem (ID INT NOT NULL, 
Name VARCHAR(100) NOT NULL
CONSTRAINT ID_Clust_DummyTable_Mem PRIMARY KEY NONCLUSTERED HASH (ID) WITH (BUCKET_COUNT=1000000))
WITH (MEMORY_OPTIMIZED=ON)
GO

-- Simple table to insert 100,000 Rows
CREATE PROCEDURE Simple_Insert_test
AS
BEGIN
SET NOCOUNT ON
DECLARE @counter AS INT = 1
DECLARE @start DATETIME
SELECT @start = GETDATE()
 
    WHILE (@counter <= 100000)
        BEGIN
            INSERT INTO DummyTable VALUES(@counter, 'SQLAuthority')
            SET @counter = @counter + 1
         END
SELECT DATEDIFF(SECOND, @start, GETDATE() ) [Simple_Insert in sec]
END
GO

-- Inserting same 100,000 rows using InMemory Table
CREATE PROCEDURE ImMemory_Insert_test
WITH NATIVE_COMPILATION, SCHEMABINDING,EXECUTE AS OWNER
AS 
BEGIN ATOMIC WITH (TRANSACTION ISOLATION LEVEL=SNAPSHOT, LANGUAGE='english')
DECLARE @counter AS INT = 1
DECLARE @start DATETIME
SELECT @start = GETDATE()
 
    WHILE (@counter <= 100000)
        BEGIN
            INSERT INTO dbo.DummyTable_Mem VALUES(@counter, 'SQLAuthority')
            SET @counter = @counter + 1
         END
SELECT DATEDIFF(SECOND, @start, GETDATE() ) [InMemory_Insert in sec]
END
GO

-- Making sure there are no rows
SELECT COUNT(*) FROM dbo.DummyTable
GO
SELECT COUNT(*) FROM dbo.DummyTable_Mem
GO

-- Running the test for Insert
EXEC Simple_Insert_test
GO
EXEC ImMemory_Insert_test
GO

-- Check if rows got inserted
SELECT COUNT(*) FROM dbo.DummyTable
GO
SELECT COUNT(*) FROM dbo.DummyTable_Mem
GO

-- Clean up
USE [master]
GO
ALTER DATABASE InMemory
SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE InMemory
GO
