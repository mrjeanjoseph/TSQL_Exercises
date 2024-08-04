--Trace Flag Configuration ON

USE [WideWorldImporters];
GO


DBCC TRACEON (9481); -- Set TF for the current session
DBCC TRACEON (9481, -1) -- set TF globally for the server

--Set TF at query level
SELECT CustomerID, CustomerName, PostalCityID
FROM Sales.Customers
WHERE CustomerName LIKE N'Wing%' OPTION (QUERYTRACEON 9481);


--SQL2016+ Trace Flag Alternatives
--Set TF at query level with USE HINT
SELECT CustomerID, CustomerName, PostalCityID
FROM Sales.Customers
WHERE CustomerName LIKE N'Wing%' 
OPTION (USE HINT ('FORCE_LEGACY_CARDINALITY_ESTIMATION'));


--Trace Flag Configuration OFF
DBCC TRACESTATUS(-1); --Check all configured TFs globally
DBCC TRACEOFF (9481); -- turn off TF in the session
DBCC TRACEOFF (9481, 1); --turn off TF globally