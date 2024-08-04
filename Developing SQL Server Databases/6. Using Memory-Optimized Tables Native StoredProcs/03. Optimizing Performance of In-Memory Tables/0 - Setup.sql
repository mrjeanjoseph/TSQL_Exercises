-- Create Database Pluralsight
CREATE DATABASE Pluralsight
	ON PRIMARY (
    NAME = [Pluralsight_data]
    ,FILENAME = 'C:\devtrunk\sql-files\Pluralsight.mdf'
    )
  	LOG ON (
    NAME = [Pluralsight_log]
    ,Filename = 'C:\devtrunk\sql-files\Pluralsight_log.ldf'
    )
GO
-- Change Compatibility Level to 110 of SQL Server 2012
ALTER DATABASE Pluralsight 
SET COMPATIBILITY_LEVEL = 110
GO
