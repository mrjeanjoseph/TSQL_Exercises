CREATE DATABASE SQLAuthority 
	ON PRIMARY (
    NAME = [SQLAuthority_data]
    ,FILENAME = 'C:\devtrunk\sql-files\SQLAuthority.mdf'
    )
    ,FILEGROUP [SQLAuthority_FG] 
	CONTAINS MEMORY_OPTIMIZED_DATA (
    NAME = [SQLAuthority_dir]
    ,FILENAME = 'C:\devtrunk\sql-files\SQLAuthority_dir'
    ) 
	LOG ON (
    NAME = [SQLAuthority_log]
    ,Filename = 'C:\devtrunk\sql-files\SQLAuthority_log.ldf'
    )
GO



SELECT @@VERSION

