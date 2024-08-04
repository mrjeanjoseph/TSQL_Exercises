-- Run this script to follow along with the demo
USE [master];
GO

CREATE LOGIN ReportingSales WITH PASSWORD = 'RememberThisIsATest';
GO

USE [ABCCompany];
GO

CREATE USER ReportingSales FOR LOGIN ReportingSales;
GO

GRANT EXECUTE ON Sales.GenerateSalesReport TO ReportingSales;
GO

-- Now change my connection to user ReportingSales
USE [ABCCompany];
GO

UPDATE Sales.SalesOrder SET SalesAmount = NULL;
GO

SELECT * FROM Sales.SalesOrder;
GO

EXECUTE Sales.GenerateSalesReport;
GO

-- Switch the connection back to the admin and clean up
USE [master];
GO

DROP LOGIN ReportingSales;
GO

USE [ABCCompany];
GO

DROP USER ReportingSales;
GO