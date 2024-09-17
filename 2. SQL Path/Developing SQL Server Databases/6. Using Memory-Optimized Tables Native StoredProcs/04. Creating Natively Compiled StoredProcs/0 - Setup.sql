-- Set up - Load the Data
USE Pluralsight
GO
-- Inserting Data
INSERT INTO [dbo].[DiskBasedTable] (FName, LName)
SELECT TOP 500000
	'Bob',
	CASE WHEN ROW_NUMBER() OVER (ORDER BY a.name)%123456 = 1 THEN 'Baker' 
			WHEN ROW_NUMBER() OVER (ORDER BY a.name)%10 = 1 THEN 'Marley' 
		WHEN  ROW_NUMBER() OVER (ORDER BY a.name)%10 = 5 THEN 'Ross' 
		WHEN  ROW_NUMBER() OVER (ORDER BY a.name)%10 = 3 THEN 'Dylan' 
	ELSE 'Hope' END
FROM sys.all_objects a
CROSS JOIN sys.all_objects b
GO

INSERT INTO [dbo].[MemoryOptimizedTable] (FName, LName)
SELECT TOP 500000
	'Bob', 					
	CASE WHEN ROW_NUMBER() OVER (ORDER BY a.name)%123456 = 1 THEN 'Baker' 
			WHEN ROW_NUMBER() OVER (ORDER BY a.name)%10 = 1 THEN 'Marley' 
		WHEN  ROW_NUMBER() OVER (ORDER BY a.name)%10 = 5 THEN 'Ross' 
		WHEN  ROW_NUMBER() OVER (ORDER BY a.name)%10 = 3 THEN 'Dylan' 
	ELSE 'Hope' END
FROM sys.all_objects a
CROSS JOIN sys.all_objects b
GO


TRUNCATE TABLE [dbo].[DiskBasedTable];
GO

-- Inserting Data
INSERT INTO [dbo].[DiskBasedTable] (FName, LName)
SELECT TOP 500000
	CASE
		WHEN ROW_NUMBER() OVER (ORDER BY a.name)%40 = 1 THEN 'Frednel'
		WHEN ROW_NUMBER() OVER (ORDER BY a.name)%30 = 2 THEN 'Julie'
		WHEN  ROW_NUMBER() OVER (ORDER BY a.name)%20 = 3 THEN 'Kervens'
		WHEN  ROW_NUMBER() OVER (ORDER BY a.name)%10 = 4 THEN 'Elvila'
	ELSE 'Denzel' END,
	CASE
		WHEN ROW_NUMBER() OVER (ORDER BY a.name)%10 = 1 THEN 'Charles' 
		WHEN ROW_NUMBER() OVER (ORDER BY a.name)%20 = 2 THEN 'Flamant' 
		WHEN  ROW_NUMBER() OVER (ORDER BY a.name)%30 = 3 THEN 'Nerris' 
		WHEN  ROW_NUMBER() OVER (ORDER BY a.name)%40 = 4 THEN 'Thomas' 
	ELSE 'Jean-Joseph' END
FROM sys.all_objects a
CROSS JOIN sys.all_objects b;
GO

SELECT COUNT(*) FROM [dbo].[DiskBasedTable]
SELECT TOP 15 * FROM [dbo].[DiskBasedTable]
SELECT * FROM [dbo].[DiskBasedTable] WHERE FName = 'Kervens'