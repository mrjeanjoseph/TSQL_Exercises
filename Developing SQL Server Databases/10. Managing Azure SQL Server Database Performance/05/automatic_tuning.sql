--View current automatic tuning configuration
SELECT * FROM sys.database_automatic_tuning_options

--View tuning recommendations and history
SELECT * FROM sys.dm_db_tuning_recommendations

--Enable Automatic tuning
ALTER DATABASE CURRENT
SET AUTOMATIC_TUNING = AUTO;
--(Possbile values: AUTO, INHERIT and CUSTOM)

--Configure Automatic Tuning Options
ALTER DATABASE CURRENT 
SET AUTOMATIC_TUNING(
	FORCE_LAST_GOOD_PLAN = [ON | OFF | DEFAULT], 
	CREATE_INDEX = [ON | OFF | DEFAULT],
	DROP_INDEX = [ON | OFF | DEFAULT] )