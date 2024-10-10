USE [Northwind]
--STEP 3 - Apply UPPER and LOWER 
	SELECT
		UPPER('aBcDefGH'),
		LOWER('aBcDefGH')
	

	/*Capitalize the first character, format all remaining characters to lower case*/
	SELECT 		
			SUBSTRING(TRIM('_- ' FROM  UPPER(LastName)),1,1),
			SUBSTRING(TRIM('_- ' FROM  LOWER(LastName)),2, LEN(LastName)),
			SUBSTRING(TRIM('*. ' FROM  UPPER(FirstName)),1,1),
			SUBSTRING(TRIM('*. ' FROM  LOWER(FirstName)),2,LEN(FirstName))
	FROM EmployeesUppercase

