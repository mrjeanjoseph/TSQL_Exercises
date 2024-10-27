:CONNECT JeanPC


--System Config
SELECT 
	SERVERPROPERTY('InstanceName') [myinstance]
FROM sys.configurations
WHERE [name] IN ('max server memory (MB)','min server memory (MB)');
GO


--Total Memory
SELECT physical_memory_kb
FROM sys.dm_os_sys_info

--
sp_configure 'show advanced options', 1;
GO
RECONFIGURE
GO
sp_configure 'max server memory (MB)', 12288;
GO
RECONFIGURE
GO


----
sp_configure 'show advanced options', 1;
GO
RECONFIGURE
GO
sp_configure 'max server memory (MB)', 10488;
GO
RECONFIGURE
GO


--

:CONNECT JeanPC
--System Config
SELECT 
	SERVERPROPERTY('InstanceName') [myinstance]
FROM sys.configurations
WHERE [name] IN ('max server memory (MB)','min server memory (MB)');
GO

--System Config
SELECT 
	SERVERPROPERTY('InstanceName') [myinstance]
FROM sys.configurations
WHERE [name] IN ('max server memory (MB)','min server memory (MB)');
GO


--
sp_configure 'show advanced options', 1;
GO
RECONFIGURE
GO
sp_configure 'max server memory (MB)', 40288;
GO
RECONFIGURE
GO


--
--System Config
SELECT *,
	SERVERPROPERTY('InstanceName') [myinstance]
FROM sys.configurations
WHERE [name] IN ('optimize for ad hoc workloads');
GO

--Get plan cache stats focusing on Ad-Hoc plan usage
SELECT
	objtype [CacheType],
	COUNT_BIG(*) [Total Plans],
	SUM(CAST(size_in_bytes AS DECIMAL(18,2))) / 1024 /1024 AS [Total MBs],
	AVG(usecounts) [Avg Use Count],
	SUM(CAST((CASE WHEN usecounts = 1 THEN size_in_bytes
		ELSE 0
		END) AS DECIMAL(18,2))) / 1024 /1024 AS [Total MBs - USE Count 1],
	SUM(CASE WHEN usecounts = 1 THEN 1
		ELSE 0
		END) [Total Plans - USE Count 1]
FROM sys.dm_exec_cached_plans
GROUP BY objtype
ORDER BY [Total MBs - USE Count 1] DESC
GO

--Parallelism
SELECT * FROM sys.configurations 
WHERE [name] IN ('max degree of parallelism');
GO

--
sp_configure 'show advanced options', 1;
GO
RECONFIGURE
GO
sp_configure 'max degree of parallelism', 4;
GO
RECONFIGURE
GO

USE [WideWorldImporters];
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 2;

--Query scoped configurations for current database - verify MAXDOP
SELECT * FROM sys.database_scoped_configurations

SELECT * FROM sys.dm_os_schedulers

--Generate a parallel plan
SELECT * FROM Warehouse.ColdRoomTemperatures_Archive
WHERE ValidFrom > '2016-04-01'


--Parallelism
SELECT * FROM sys.configurations 
WHERE [name] IN ('max degree of parallelism');
GO

--Parallelism
SELECT * FROM sys.configurations 
WHERE [name] IN ('cost threshold for parallelism');
GO