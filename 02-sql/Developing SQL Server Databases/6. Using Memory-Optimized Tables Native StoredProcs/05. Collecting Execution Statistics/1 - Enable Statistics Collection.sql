USE Pluralsight
GO
-- -----------------------------------------------------
-- Procecure Level Statisitcs Collection
-- -----------------------------------------------------
-- Current Status of Statistics Collection
DECLARE @Status BIT;
EXEC sys.sp_xtp_control_proc_exec_stats @old_collection_value=@Status output
SELECT @Status AS 'Current Status of Statistics Collection (SP Level)'
GO

-- Enable Statistics Collection for Natively Compiled SP at SP Level
EXEC sys.sp_xtp_control_proc_exec_stats @new_collection_value = 0
GO

-- Current Status of Statistics Collection
DECLARE @Status BIT;
EXEC sys.sp_xtp_control_proc_exec_stats @old_collection_value=@Status output
SELECT @Status AS 'Current Status of Statistics Collection (SP Level)'
GO

-- Azure 
ALTER DATABASE
    SCOPED CONFIGURATION
    SET XTP_PROCEDURE_EXECUTION_STATISTICS = ON
GO

-- -----------------------------------------------------
-- Query Level Statisitcs Collection
-- -----------------------------------------------------

DECLARE @Status BIT;
EXEC sys.sp_xtp_control_query_exec_stats @old_collection_value=@Status output
SELECT @Status AS 'Current Status of Statistics Collection (Query Level)'
GO

-- Enable Statistics Collection for Natively Compiled SP at SP Level
EXEC sys.sp_xtp_control_query_exec_stats @new_collection_value = 0
GO

-- Current Status of Statistics Collection
DECLARE @Status BIT;
EXEC sys.sp_xtp_control_query_exec_stats @old_collection_value=@Status output
SELECT @Status AS 'Current Status of Statistics Collection (Query Level)'
GO

-- Azure 
ALTER DATABASE
    SCOPED CONFIGURATION
    SET XTP_QUERY_EXECUTION_STATISTICS = ON
GO