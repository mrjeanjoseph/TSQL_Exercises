USE [WideWorldImporters];
GO

exec sp_trace_setstatus 12, 1 -- Start the Trace
GO
exec sp_trace_setstatus 12, 0 -- Stop the Trace
GO
exec sp_trace_setstatus 12, 2 -- Delete the Trace
GO

---------------------------------
-- Query to find active traces
SELECT 
    --trace_id,
    path,
    max_size,
    max_files,
    stop_time,
    status,
    start_time,
    --login_name,
    event_count
FROM 
    sys.traces
WHERE 
    status = 1; -- 1 indicates an active trace
