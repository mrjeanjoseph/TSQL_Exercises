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
GO 

RETURN;
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
	--AND qsq.[object_id] = OBJECT_ID(N'WideWorldImporters.Website.SearchForPeople',N'P')
ORDER BY qsr.avg_duration DESC;
GO

RETURN;
WITH [Waits] AS
	(SELECT
		[wait_type],
		[wait_time_ms] / 1000.0 [Waits],
		([wait_time_ms] - [signal_wait_time_ms]) / 1000.0 [Resources],
		[signal_wait_time_ms] / 1000.0 [Signals],
		[waiting_tasks_count] [WaitCount],
		100.0 * [wait_time_ms] / SUM ([wait_time_ms]) OVER() [percentage],
		ROW_NUMBER() OVER(ORDER BY [wait_time_ms] DESC) [RowNum]
	FROM sys.dm_os_wait_stats
	WHERE [wait_type] NOT IN (
		N'BROKER_EVENTHANDLER',
		N'BROKER_RECEIVE_WAITFOR',
		N'BROKER_TASK_STOP',
		N'BROKER_TO_FLUSH',
		N'BROKER_TRANSMITTER',
		N'CHECKPOINT_QUEUE',
		N'CHKPT',
		N'CLR_AUTO_EVENT',
		N'CLR_MANUAL_EVENT',
		N'CLR_SEMAPHORE',
		N'CSCONSUMER',
		N'DBMIRROR_DBM_EVENT',
		N'DBMIRROR_EVENTS_QUEUE',
		N'DBMIRROR_WORKER_QUEUE',
		N'DBMIRRORING_CMD',

		N'DIRTY_PAGE_POLL',
		N'DISPATCHER_QUEUE_SEMAPHORE',
		N'EXECSYNC',
		N'FSAGENT',
		N'FT_IFTS_SCHEDULER_IDLE_WAIT',
		N'FT_IFTSHC_MUTEX',

		N'HADR_CLUSAPI_CALL',
		N'HADR_FILESTREAM_IOMGR_IOCOMPLETION',
		N'HADR_LOGCAPTURE_WAIT',
		N'HADR_NOTIFICATION_DEQUEUE',
		N'HADR_TIMER_TASK',
		N'HADR_WORK_QUEUE',

		N'KSOURCE_WAKEUP',
		N'LAZYWRITER_SLEEP',
		N'LGOMGR_QUEUE',
		N'MEMORY_ALLOCATION_EXT',
		N'ONDEMAND_TASK_QUEUE',
		N'PARALLEL_REDO_DRAIN_WORKER',
		N'PARALLEL_REDO_LOG_CACHE',
		N'PARALLEL_REDO_TRAN_LIST',
		N'PARALLEL_REDO_WORKER_SYNC',
		N'PARALLEL_REDO_WORKER_WAIT_WORK',

		N'PREEMPTIVE_OS_FLUSHFILEBUFFERS',
		N'PREEMPTIVE_XE_GETTARGETSTATE',
		N'PWAIT_ALL_COMPONENTS_INITIALIZED',
		N'PWAIT_DIRECTLOGCONSUMER_GETNEXT',
		N'QDS_PERSIST_TASK_MAIN_LOOP_SLEEP',
		N'QDS_ASYNC_QUEUE',

		N'QDS_CLEANUP_STALE_QUERIES_TASK_MAIN_LOOP_SLEEP',
		N'QDS_SHUTDOWN_QUEUE',
		N'REDO_THREAD_PENDING_WORK',
		N'REQUEST_FOR_DEADLOCK_SEARCH',
		N'RESOURCE_QUEUE',
		N'SERVER_IDLE_CHECK',

		N'VDI_CLIENT_OTHER',
		N'WAIT_FOR_RESULTS',
		N'WAITFOR',
		N'WAITFOR_TASKSHUTDOWN',
		N'WAIT_XTP_RECOVERY',
		N'WAIT_XTP_HOST_WAIT',
		N'WAIT_XTP_OFFLINE_CKPT_NEW_LOG',
		N'WAIT_XTP_CKPT_CLOSE',
		N'XE_DISPATCHER_JOIN',
		N'XE_DISPATCHER_WAIT',
		N'XE_TIMER_EVENT'
	)
	AND [waiting_tasks_count] > 0)
SELECT 
	MAX(w1.wait_type) [WaitTypes],
	CAST(MAX(w1.Waits) AS DECIMAL(16,2)) [Wait_S],
	CAST(MAX(w1.Resources) AS DECIMAL(16,2)) [Resources_S],
	CAST(MAX(w1.Signals) AS DECIMAL(16,2)) [Signals_S],
	MAX(w1.WaitCount) [WaitCounts],
	CAST(MAX(w1.[percentage]) AS DECIMAL(5,2)) [Percentage],
	CAST((MAX(w1.Waits) / MAX(w1.WaitCount)) AS DECIMAL (16,4)) [AvgWait_S],
	CAST((MAX(w1.Resources) / MAX(w1.WaitCount)) AS DECIMAL (16,4)) [AvgRes_S],
	CAST((MAX(w1.Signals) / MAX(w1.WaitCount)) AS DECIMAL (16,4)) [AvgSig_S]	
FROM [Waits] [w1]
INNER JOIN [Waits] [w2]
	ON w2.RowNum <= w1.RowNum
GROUP BY w1.RowNum
HAVING SUM(w2.[percentage]) - MAX(w1.[percentage]) < 95;
GO