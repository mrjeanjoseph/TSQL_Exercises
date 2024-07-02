USE [Northwind]
/*SIMPLIFY using TEMP tables and User Defined Functions*/	
	SELECT 		
		CONCAT(
			SUBSTRING(TRIM('_- ' FROM  UPPER(LastName)),1,1),
			SUBSTRING(TRIM('_- ' FROM  LOWER(LastName)),2, LEN(LastName)),
			', ',
			SUBSTRING(TRIM('*. ' FROM  UPPER(FirstName)),1,1),
			SUBSTRING(TRIM('*. ' FROM  LOWER(FirstName)),2,LEN(FirstName))
			) AS EmployeeNameFormatted
	FROM EmployeesUppercase
	
	SELECT 
		SUBSTRING(TRIM('_- ' FROM  LastName),	1,1) AS LastNameFirstCharacter,
		SUBSTRING(TRIM('_- ' FROM  LastName),2, LEN(LastName))AS LastNameAllButFirstCharacter,
		SUBSTRING(TRIM('*. ' FROM  FirstName),1,1) AS FirstNameFirstCharacter,
		SUBSTRING(TRIM('*. ' FROM  FirstName),2,LEN(FirstName))	AS FirstNameAllButFirstCharacter
	INTO #TMP 
	FROM EmployeesUppercase

	SELECT * FROM #TMP
	
	SELECT 
		CONCAT(UPPER(LastNameFirstCharacter),LOWER(LastNameAllButFirstCharacter),
			', ',
			UPPER(FirstNameFirstCharacter),LOWER(FirstNameAllButFirstCharacter)
		) AS FormattedName
	FROM #TMP	
	DROP TABLE #TMP

/*adding funcationality to a user defined function*/

SELECT 
	dbo.Proper('SunDAy'), 
	dbo.Proper('MONday'), 
	dbo.Proper('TUEsday')

SELECT  
		CONCAT(
			dbo.Proper(TRIM('*. ' FROM  FirstName)),
			', ',
			dbo.Proper(TRIM('_- ' FROM  LastName))
		) AS FormattedName
FROM EmployeesUppercase

SELECT  
		CONCAT_WS(', ',
			dbo.Proper(TRIM('*. ' FROM  FirstName)),
			dbo.Proper(TRIM('_- ' FROM  LastName))
		) AS FormattedName
FROM EmployeesUppercase







