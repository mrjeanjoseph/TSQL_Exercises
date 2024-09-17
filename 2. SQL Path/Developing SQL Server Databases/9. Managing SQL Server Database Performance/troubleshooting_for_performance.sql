--Virtual Stats
SELECT
	[readLatency] = 
		CASE WHEN [num_of_reads] = 0 THEN 0
			ELSE ([io_stall_read_ms] / [num_of_reads]) END,
	[writeLatency] = 
		CASE WHEN [num_of_writes] = 0 THEN 0
			ELSE ([io_stall_write_ms] / [num_of_writes]) END,
	[Latency] = 
		CASE WHEN ([num_of_reads] = 0 AND [num_of_writes] = 0) THEN 0
			ELSE ([io_stall] / ([num_of_reads] + [num_of_writes])) END,
	[avgBPerRead] = 
		CASE WHEN ([num_of_reads] = 0 AND [num_of_writes] = 0) THEN 0
			ELSE ([io_stall] / ([num_of_reads] + [num_of_writes])) END,
	[avgBPerWrite] = 
		CASE WHEN [num_of_writes] = 0 THEN 0
			ELSE [num_of_bytes_written] / [num_of_writes] END,
	[avgBPerTransfer] = 
		CASE WHEN ([num_of_reads] = 0 AND [num_of_writes] = 0) THEN 0
			ELSE (([num_of_bytes_read] + [num_of_bytes_written]) /
			([num_of_reads] + [num_of_writes])) END,
	LEFT ([mf].[physical_name], 2) [Drive],
	--DB_NAME ([vfs.[database_id]) [DB],
	[mf].[physical_name]

FROM sys.dm_io_virtual_file_stats (null, null) AS [vfs]
JOIN sys.database_files AS [mf]
	ON [vfs].[database_id] = DB_ID()
	AND [vfs].[file_id] = [mf].[file_id]
--WHERE [vfs].[file_id] = 2 -- log files
--ORDER BY [latency] DESC
--ORDER BY [readLatency] DESC
ORDER BY [writeLatency] DESC;



--Query Store
SELECT
	@@SERVERNAME [ServerName],
	SYSDATETIMEOFFSET() [Collect DateTime],
	DB_NAME() [DB Name],
	qsq.[object_id],
	OBJECT_NAME(qsq.[object_id]) [ObjName],
	*
FROM sys.query_store_plan qsp
INNER JOIN sys.query_store_query qsq
	ON qsq.query_id = qsp.query_id
INNER JOIN sys.query_store_runtime_stats qsr
	ON qsp.plan_id = qsr.plan_id
INNER JOIN sys.query_store_query_text qst
	ON qsq.query_text_id = qst.query_text_id
INNER JOIN sys.query_store_runtime_stats_interval qsi 
	ON qsi.runtime_stats_interval_id = qsr.runtime_stats_interval_id
WHERE
	qsr.last_execution_time >= '2019-07-05 08:00:00:000'
	AND 
	qsr.last_execution_time >= '2019-07-05 21:00:00:000'
	AND qsr.execution_type = 0 -- 3 = aborted, 4 = exection, 0 = regular (successful)
	AND qsq.[object_id] = OBJECT_ID(N'WideWorldImporters.Website.SearchForPeople',N'P')
ORDER BY qsr.avg_duration DESC


--
EXEC sp_server_diagnostics;
GO

--
SELECT * FROM sys.dm_os_performance_counters
WHERE counter_name LIKE N'page life%';