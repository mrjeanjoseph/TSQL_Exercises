-- Run this script to follow along with the demo
USE [master];
GO

-- Checking to see if our database exists and if it does drop it
IF DATABASEPROPERTYEX ('BonRepos','Version') IS NOT NULL
BEGIN
	ALTER DATABASE [BonRepos] SET SINGLE_USER
	WITH ROLLBACK IMMEDIATE;
	DROP DATABASE [BonRepos];
END
GO

CREATE DATABASE [BonRepos];
GO

ALTER DATABASE [BonRepos] SET RECOVERY SIMPLE;
GO

USE [BonRepos];
GO

CREATE SCHEMA [Sales];
GO

CREATE TABLE [Sales].[SalesPersonLevel] (
	[Id] int identity(1,1) NOT NULL,
	[LevelName] nvarchar(500) NOT NULL,
	[CreateDate] datetime NOT NULL DEFAULT GETDATE(),
	[ModifyDate] datetime NULL
	CONSTRAINT [PK_SalesPersonLevel] PRIMARY KEY CLUSTERED ([Id]));
GO

INSERT INTO [Sales].[SalesPersonLevel] ([LevelName])
	VALUES	('President'),
			('Manager'),
			('Staff');
GO
	
CREATE TABLE [Sales].[SalesPerson] (
	[Id] int identity(1,1) NOT NULL,
	[FirstName] nvarchar(500) NOT NULL,
	[LastName] nvarchar(500) NOT NULL,
	[SalaryHr] decimal(32,2) NULL,
	[ManagerId] int NULL,
	[LevelId] int NOT NULL,
	[Email] nvarchar(500) NULL,
	[StartDate] date NOT NULL,
	[CreateDate] datetime NOT NULL DEFAULT GETDATE(),
	[ModifyDate] datetime NULL
	CONSTRAINT [PK_SalesPerson] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_SalesPersonLevel] FOREIGN KEY ([LevelId]) REFERENCES [Sales].[SalesPersonLevel] ([Id]),
	CONSTRAINT [FK_SalesPersonManagerId] FOREIGN KEY ([ManagerId]) REFERENCES [Sales].[SalesPerson] ([Id]));
GO

INSERT INTO [Sales].[SalesPerson] ([FirstName],[LastName],[SalaryHr],[ManagerId],[LevelId],[Email],[StartDate]) 
	VALUES	('Tom','Jones',300,1,1,'Tom.Jones@bonrepos.ht','1/5/2016'),
			('Sally','Smith',175,1,2,'Sally.Smith@bonrepos.ht','1/7/2018'),
			('Bill','House',100,2,3,'Bill.House@bonrepos.ht','1/8/2018'),
			('Karen','Knocks',100,2,3,'Karen.Knocks@bonrepos.ht','1/15/2017'),
			('Lisa','James',75,2,3,'Lisa.James@bonrepos.ht','6/1/2018'),
			('Kerrie','Friend',125,2,3,'Kerrie.Friend@bonrepos.ht','8/14/2018'),
			('Jason','Henderson',55,2,3,'Jason.Henderson@bonrepos.ht','1/14/2017'),
			('Wanda','Jones',55,2,3,'Tom.Jones@bonrepos.ht','9/1/2017'),
			('Jared','Lee',65,2,3,'Jared.Lee@bonrepos.ht','9/8/2018'),
			('Tammy','Smith',75,2,3,NULL,'2/5/2018');
GO

ALTER INDEX ALL ON [Sales].[SalesPerson] REBUILD;
GO

CREATE TABLE [Sales].[SalesTerritoryStatus] (
	[Id] int identity(1,1) NOT NULL,
	[StatusName] nvarchar(500) NOT NULL,
	[CreateDate] datetime NOT NULL DEFAULT GETDATE(),
	[ModifyDate] datetime NULL
	CONSTRAINT [PK_SalesTerritoryStatus] PRIMARY KEY CLUSTERED ([Id]));
GO

INSERT INTO [Sales].[SalesTerritoryStatus] ([StatusName])
	VALUES	('On Hold'),
			('In Progress'),
			('Closed');
GO

CREATE TABLE [Sales].[SalesTerritory] (
	[Id] int identity(1,1) NOT NULL,
	[TerritoryName] nvarchar(500) NOT NULL,
	[Group] nvarchar(500) NULL,
	[StatusId] int NOT NULL,
	[CreateDate] datetime NOT NULL DEFAULT GETDATE(),
	[ModifyDate] datetime NULL
	CONSTRAINT [PK_SalesTerritory] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [Sales].[SalesTerritoryStatus] ([Id]));
GO

INSERT INTO [Sales].[SalesTerritory] ([TerritoryName],[Group],[StatusId]) 
	VALUES	('Northwest','North America',2),
			('Northeast','North America',2),
			('Southwest','North America',2),
			('Southeast','North America',1),
			('Canada','North America',3),
			('France','Europe',1),
			('Germany','Europe',2),
			('Australia','Pacific',2),
			('United Kingdom','Europe',3),
			('Spain','Europe',1);

ALTER INDEX ALL ON [Sales].[SalesTerritory] REBUILD;
GO

CREATE TABLE [Sales].[SalesOrder] (
	[Id] int identity(1,1) NOT NULL,
	[SalesPerson] int NOT NULL,
	[SalesAmount] decimal(36,2) NOT NULL,
	[SalesDate] datetime NOT NULL,
	[SalesTerritory] int NOT NULL,
	[OrderDescription] nvarchar(MAX) NULL,
	[CreateDate] datetime NOT NULL DEFAULT GETDATE(),
	[ModifyDate] datetime NULL
	CONSTRAINT [PK_SalesOrder] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_SalesPerson] FOREIGN KEY ([SalesPerson]) REFERENCES [Sales].[SalesPerson] ([Id]),
	CONSTRAINT [FK_SalesTerritory] FOREIGN KEY ([SalesTerritory]) REFERENCES [Sales].[SalesTerritory] ([Id]));
GO

INSERT INTO [Sales].[SalesOrder] ([SalesPerson],[SalesAmount],[SalesDate],[SalesTerritory],[OrderDescription]) 
	VALUES (1,2500,'04/05/2019',1,REPLICATE('Sales Description ',10)),
		   (2,3000,'03/02/2019',4,REPLICATE('Sales Description ',10)),
		   (3,4200,'06/02/2019',3,REPLICATE('Sales Description ',10)),
		   (4,1900,'07/01/2019',7,REPLICATE('Sales Description ',10)),
		   (7,2200,'05/15/2019',6,REPLICATE('Sales Description ',10)),
		   (9,5200,'06/03/2019',5,REPLICATE('Sales Description ',10)),
		   (10,7800,'04/13/2019',4,REPLICATE('Sales Description ',10)),
		   (3,4400,'03/23/2019',3,REPLICATE('Sales Description ',10)),
		   (5,1900,'02/15/2019',2,REPLICATE('Sales Description ',10)),
		   (5,7000,'6/09/2019',1,REPLICATE('Sales Description ',10));
GO

ALTER INDEX ALL ON [Sales].[SalesOrder] REBUILD;
GO

CREATE OR ALTER PROCEDURE [Sales].[GenerateSalesReport]
AS
SELECT SUM(so.SalesAmount) AS 'SalesAmount'
	   ,spl.LevelName AS 'Level'
	   ,CONCAT(sp.LastName,', ',sp.FirstName) AS 'FullName' 
FROM Sales.SalesPerson sp
LEFT OUTER JOIN Sales.SalesOrder so ON so.SalesPerson = sp.Id
LEFT OUTER JOIN Sales.SalesPersonLevel spl ON spl.Id = sp.LevelId
GROUP BY spl.LevelName, sp.LastName, sp.FirstName;
GO