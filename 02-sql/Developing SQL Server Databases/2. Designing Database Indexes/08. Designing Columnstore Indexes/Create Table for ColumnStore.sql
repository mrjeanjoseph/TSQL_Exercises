USE [InterstellarTransport]

DROP TABLE IF EXISTS ShipmentDetailsColumnStore
DROP INDEX IF EXISTS idx_ShipmentDetails ON dbo.ShipmentDetailsColumnStore

SELECT * 
INTO ShipmentDetailsColumnStore
FROM dbo.ShipmentDetails
GO

SELECT * FROM ShipmentDetailsColumnStore;


-- This will reinsert the same data 10 times
INSERT INTO dbo.ShipmentDetailsColumnStore(
    ShipmentID,
    CustomsCodeID,
    Mass,
    Volume,
    NumberOfContainers,
    IsTemperatureControlled,
    IsHazardous,
    IsLivestock)
SELECT ShipmentID,
       CustomsCodeID,
       Mass,
       Volume,
       NumberOfContainers,
       IsTemperatureControlled,
       IsHazardous,
       IsLivestock
FROM dbo.ShipmentDetails
GO 10

