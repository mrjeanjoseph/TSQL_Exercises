USE [InterstellarTransport]

--Don't do this in Production
SELECT ss.[Location], sh.ShipmentID
FROM dbo.Stations ss
INNER JOIN dbo.Shipments sh ON sh.OriginStationID = ss.StationID
WHERE ss.[Location] = 'Outer Transfer';

SELECT ss.[Location], sh.ShipmentID
FROM dbo.Stations ss
INNER MERGE JOIN dbo.Shipments sh ON sh.OriginStationID = ss.StationID
WHERE ss.[Location] = 'Outer Transfer';

SELECT ss.[Location], sh.ShipmentID
FROM dbo.Stations ss
INNER HASH JOIN dbo.Shipments sh ON sh.OriginStationID = ss.StationID
WHERE ss.[Location] = 'Outer Transfer';

--
USE [InterstellarTransport]
GO
CREATE NONCLUSTERED INDEX idx_test
ON [dbo].[Shipments] (OriginStationID)
