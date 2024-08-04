USE [Northwind]
/*Final step:
	concatenating the formatted results using CAST and CONVERT
*/


	SELECT 		
		CONCAT(
			SUBSTRING(TRIM('_- ' FROM  UPPER(LastName)),1,1),
			SUBSTRING(TRIM('_- ' FROM  LOWER(LastName)),2, LEN(LastName)),
			', ',
			SUBSTRING(TRIM('*. ' FROM  UPPER(FirstName)),1,1),
			SUBSTRING(TRIM('*. ' FROM  LOWER(FirstName)),2,LEN(FirstName))
			) AS EmployeeNameFormatted
	FROM EmployeesUppercase

	/*cannot use concat_ws*/
	SELECT 		
		CONCAT_WS(', ',
			SUBSTRING(TRIM('_- ' FROM  UPPER(LastName)),1,1),
			SUBSTRING(TRIM('_- ' FROM  LOWER(LastName)),2, LEN(LastName)),
			SUBSTRING(TRIM('*. ' FROM  UPPER(FirstName)),1,1),
			SUBSTRING(TRIM('*. ' FROM  LOWER(FirstName)),2,LEN(FirstName))
			) AS EmployeeNameFormatted
	FROM EmployeesUppercase

