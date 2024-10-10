USE [InterstellarTransport];
GO

SELECT OBJECT_SCHEMA_NAME(rg.object_id) AS SchemaName,
       OBJECT_NAME(rg.object_id) AS TableName,
       i.name AS IndexName,
       i.type_desc AS IndexType,
       rg.partition_number,
       rg.row_group_id,
       rg.total_rows,
       rg.size_in_bytes,
       rg.deleted_rows,
       rg.[state],
       rg.state_description
FROM sys.column_store_row_groups AS rg
    INNER JOIN sys.indexes AS i ON i.object_id = rg.object_id AND i.index_id = rg.index_id
WHERE state_description != 'TOMBSTONE'
ORDER BY TableName,
         IndexName,
         rg.partition_number,
         rg.row_group_id;
GO

RETURN;


USE [InterstellarTransport];
GO
--Doing a few insert into this table
INSERT INTO DBO.ShipmentDetailsColumnStore(
	ShipmentID,
	CustomsCodeID,
	Mass,
	Volume,
	NumberOfContainers,
	IsTemperatureControlled,
	IsHazardous,
	IsLivestock
) SELECT
	ShipmentID,
	CustomsCodeID,
	Mass,
	Volume,
	NumberOfContainers,
	IsTemperatureControlled,
	IsHazardous,
	IsLivestock
FROM dbo.ShipmentDetailsColumnStore;
GO 10

SELECT COUNT(*) FROM dbo.ShipmentDetailsColumnStore;