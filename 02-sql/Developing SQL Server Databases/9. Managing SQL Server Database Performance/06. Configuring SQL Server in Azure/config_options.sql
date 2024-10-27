sp_configure 'max degree of parallelism', 4;
RECONFIGURE; 

USE[WideWorldImporters];
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 2;

SELECT ColdRoomSensorNumber, COUNT(ColdRoomTemperatureID)
FROM Warehouse.ColdRoomTemperatures_Archive
GROUP BY ColdRoomSensorNumber OPTION(MAXDOP 8);

---
SELECT ColdRoomSensorNumber, COUNT(ColdRoomTemperatureID)
FROM Warehouse.ColdRoomTemperatures_Archive
GROUP BY ColdRoomSensorNumber 
OPTION(USE HINT ('FORCE_LEGACY_CARDINALITY_ESTIMATION'));
