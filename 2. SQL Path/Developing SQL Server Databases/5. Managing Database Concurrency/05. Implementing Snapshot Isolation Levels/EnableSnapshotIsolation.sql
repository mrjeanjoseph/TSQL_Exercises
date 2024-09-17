USE RHJsShoes;
GO

-- Enable RCSI
ALTER DATABASE RHJsShoes SET READ_COMMITTED_SNAPSHOT ON;
GO

-- Show snapshot settings

SELECT DB_NAME(database_id), 
    is_read_committed_snapshot_on,
    snapshot_isolation_state_desc 
    
FROM sys.databases
WHERE database_id = DB_ID();

-- Permit snapshot isolation 
ALTER DATABASE RHJsShoes SET ALLOW_SNAPSHOT_ISOLATION ON;
GO
 