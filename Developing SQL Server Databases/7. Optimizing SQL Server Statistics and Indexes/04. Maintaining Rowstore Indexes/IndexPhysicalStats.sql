USE [InterstellarTransport];
GO

SELECT OBJECT_SCHEMA_NAME(i.object_id) AS SchemaName, OBJECT_NAME(i.object_id) TableName, 
	i.[name],
	ips.partition_number, 
	ips.index_type_desc, 
	ips.index_level,
	ips.avg_fragmentation_in_percent,
	ips.page_count,
	ips.avg_page_space_used_in_percent
	FROM sys.indexes i 
		INNER JOIN sys.dm_db_index_physical_stats(DB_ID(), NULL, NULL, NULL, 'Detailed') ips 
			ON ips.object_id = i.object_id AND ips.index_id = i.index_id
	--WHERE ips.avg_fragmentation_in_percent > 30 AND ips.page_count > 1000;
	WHERE i.name = 'idx_ShipmentDetails_ShipmentID';
GO

RETURN;

/*
	ALTER INDEX [ALL | <index name>]
	ON TableName
	REBUILD
	WITH
	PAD_INDEX = {ON | OFF}
	FILLFACTOR = fillfactor
	SORT_IN_TEMPDB = {ON | OFF}
	ONLINE = {ON [ ( <low_priority_lock_wait> ) ] | OFF }
	RESUMABLE = {ON | OFF }
	MAX_DURATION = <time> [MINUTES]
	MAXDOP = max_degree_of_parallelism
*/


--Follow standard format and choose one.
ALTER INDEX idx_ShipmentDetails_ShipmentID ON DBO.ShipmentDetails REBUILD;
GO

ALTER INDEX idx_ShipmentDetails_ShipmentID ON DBO.ShipmentDetails REORGANIZE;
GO

/*
	--Recommendation on script already created to REBUILD or REORGANIZE Indexes
	GitHub: https://github.com/olahallengren/sql-server-maintenance-solution

	Backup: https://ola.hallengren.com/sql-server-backup.html
	Integrity Check: https://ola.hallengren.com/sql-server-integrity-check.html
	Index and Statistics Maintenance: https://ola.hallengren.com/sql-server-index-and-statistics-maintenance.html
*/


USE [InterstellarTransport];
GO

ALTER DATABASE InterstellarTransport SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
RESTORE DATABASE InterstellarTransport FROM DISK = 'Path of the .bak file' WITH REPLACE, NOUNLOAD, STATS = 5;
GO