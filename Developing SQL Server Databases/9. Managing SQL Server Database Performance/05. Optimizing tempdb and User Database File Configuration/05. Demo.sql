SELECT 
	servicename
	startup_type_desc,
	status_desc,
	last_startup_time,
	service_account,
	is_clustered,
	instant_file_initialization_enabled
FROM 
	sys.dm_server_services


SELECT 
	database_id,
	[file_id],
	[type_desc],
	[name],
	physical_name,
	state_desc,
	size,
	max_size,
	growth,
	is_percent_growth
FROM sys.master_files


SELECT *
FROM
	sys.dm_os_schedulers