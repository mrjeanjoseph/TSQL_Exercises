USE [InterstellarTransport];
GO

SELECT OBJECT_NAME(i.object_id) AS TableName,
       i.index_id,
       ISNULL(user_seeks, 0) AS UserSeeks,
       ISNULL(user_scans, 0) AS UserScans,
       ISNULL(user_lookups, 0) AS UserLookups,
       ISNULL(user_updates, 0) AS UserUpdates
FROM sys.indexes i
    LEFT OUTER JOIN sys.dm_db_index_usage_stats ius
        ON ius.object_id = i.object_id AND ius.index_id = i.index_id
WHERE OBJECTPROPERTY(i.object_id, 'IsMSShipped') = 0;



-----------------------------------
SELECT
	OBJECT_NAME(i.object_id) [TableName],
	i.index_id,
	i.is_unique,
	ISNULL(user_seeks, 0) [UserSeeks],
	ISNULL(user_scans, 0) [UserScans],
	ISNULL(user_lookups, 0) [UserLookups],
	ISNULL(user_updates, 0) [UserUpdates]
FROM SYS.INDEXES i
LEFT OUTER JOIN SYS.DM_DB_INDEX_USAGE_STATS ius
	ON ius.object_id = i.object_id
	AND ius.index_id = i.index_id
WHERE OBJECTPROPERTY(i.object_id, 'IsMSShipped') = 0;



-----------------------------------------
SELECT * FROM SYS.QUERY_STORE_PLAN
WHERE query_plan LIKE '%%'