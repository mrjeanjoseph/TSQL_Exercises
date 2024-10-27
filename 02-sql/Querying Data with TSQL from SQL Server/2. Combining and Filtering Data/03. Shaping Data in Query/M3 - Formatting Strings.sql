USE Northwind
/* the asterisk wildcard returns all fields*/
--SELECT * FROM EmployeesUppercase

/*	Business request: 
	1. Return the first and last name in the form of LastName, FirstName
	2. Apply proper casing.  For example Davolio, Nancy
	CHALLENGE
	1. There are extra characters in the name fields
	2. The values are upper and lower case and have additional characters that need to be removed.  
	For example _-CALLAHAN, *.laUrA needs to be returned as Callahan, Laura
*/	
	----BEFORE FORMATTING IS APPLIED
	--SELECT LastName, FirstName FROM EmployeesUppercase
	----AFTER FORMATTING IS APPLIED	
	--SELECT  
	--		CONCAT(
	--			dbo.FormatProperCasing(TRIM('*. ' FROM  FirstName)),
	--			', ',
	--			dbo.FormatProperCasing(TRIM('_- ' FROM  LastName))
	--		) AS FormattedName
	--FROM EmployeesUppercase

--STEP 1, remove trailing spaces from the name fields using TRIM

	--AFTER APPLYING TRIM()
	--SELECT  
	--	FirstName,
	--	TRIM(FirstName),
	--	LastName,
	--	TRIM(LastName)
	--FROM EmployeesUppercase
	
	--OPTIONAL Use for Trim.
	SELECT 
	FirstName,TRIM('*. ' FROM  FirstName),
	LastName,TRIM('_- ' FROM  LastName)
	FROM EmployeesUppercase

--STEP 2, remove all occurrences of the '*.' and '_-' characters from the fields using REPLACE
	--SELECT 
	--	FirstName, 
	--	REPLACE(FirstName,'*.','_'),
	--	LastName, 
	--	REPLACE(LastName, '_-','_') 
	--FROM EmployeesUppercase

	--SELECT 
	--	FirstName, 
	--	REPLACE(FirstName,'*.',''),
	--	LastName, 
	--	REPLACE(LastName, '_-','') 
	--FROM EmployeesUppercase
	
	
	--CAUTION!  Replace removes all occurances
	--SELECT
	--	LastName, 
	--	REPLACE(LastName, '-','') 
	--FROM EmployeesUppercase
		

--STEP 3, Get just the first character of the first and last names using SUBSTRING

	--SELECT SUBSTRING('hello',1,1) --returns h

	--SELECT 
	--	LastName, 		
	--	SUBSTRING(
	--		TRIM('_- ' FROM  LastName),
	--		1,1)
	--		AS LastNameBeginningCharacter,
	--	FirstName,
	--	SUBSTRING(
	--		TRIM('*. ' FROM  FirstName),
	--		1,1)
	--		AS FirstNameBeginningCharacter
	--FROM EmployeesUppercase	

--STEP 4, GET all BUT the first letter using SUBSTRING

	--SELECT SUBSTRING('hello', 1, 1) --returns all but the first character
	--SELECT SUBSTRING('hello', 2, 50) --returns all but the first character
	--SELECT SUBSTRING('hello', 2, 2) --returns all but the first character
	--SELECT LEN('hello') --returns an integer representing the length of the string
	--SELECT SUBSTRING('hello',2,LEN('hello'))
	--SELECT SUBSTRING('hello',2,LEN('hello')-1)

	
	--SELECT 
	--	LastName, 
	--	SUBSTRING(
	--		TRIM('_- ' FROM  LastName),	1,1)
	--		AS LastNameFirstCharacter,
	--	FirstName,
	--	SUBSTRING(
	--		TRIM('*. ' FROM  FirstName),1,1)
	--		AS FirstNameFirstCharacter
	--FROM EmployeesUppercase

	--SELECT 
	--	LastName, 
	--	SUBSTRING(
	--		TRIM('_- ' FROM  LastName),
	--		2, LEN(LastName))
	--		AS LastNameAllButFirstCharacter,
	--	FirstName,
	--	SUBSTRING(
	--		TRIM('*. ' FROM  FirstName),
	--		2,LEN(FirstName))
	--		AS FirstNameAllButFirstCharacter
	--FROM EmployeesUppercase

	--SELECT 
	--	SUBSTRING(TRIM('_- ' FROM  LastName),	1,1) AS LastNameFirstCharacter,
	--	SUBSTRING(TRIM('_- ' FROM  LastName),2, LEN(LastName))AS LastNameAllButFirstCharacter,
	--	SUBSTRING(TRIM('*. ' FROM  FirstName),1,1) AS FirstNameFirstCharacter,
	--	SUBSTRING(TRIM('*. ' FROM  FirstName),2,LEN(FirstName))	AS FirstNameAllButFirstCharacter
	--INTO #TMP 
	--FROM EmployeesUppercase

	--SELECT * FROM #TMP
	

--STEP 5 - Apply UPPER and LOWER to the #TMP table values
	--SELECT
	--	UPPER(LastNameFirstCharacter),
	--	LOWER(LastNameAllButFirstCharacter),
	--	UPPER(FirstNameFirstCharacter),
	--	LOWER(FirstNameAllButFirstCharacter)
	--FROM #TMP

--STEP 6 - use CONCAT to combine upper and lower characters of names
	--SELECT
	--	CONCAT(UPPER(LastNameFirstCharacter), LOWER(LastNameAllButFirstCharacter)) AS FormattedLastName,
	--	CONCAT(UPPER(FirstNameFirstCharacter), LOWER(FirstNameAllButFirstCharacter)) AS FormattedFirstName
	--FROM #TMP

--STEP 7 - use CONCAT_WS to combine values as lastname, firstname for the final results
	--SELECT
	--	CONCAT_WS(', ',
	--		CONCAT(UPPER(LastNameFirstCharacter), LOWER(LastNameAllButFirstCharacter)),
	--		CONCAT(UPPER(FirstNameFirstCharacter), LOWER(FirstNameAllButFirstCharacter))
	--		)
	--		AS FormattedName
	--FROM #TMP
	--DROP TABLE #TMP
--You can simplify this process by using a user defined function that will format proper casing


	--SELECT 		
	--	SUBSTRING(
	--		TRIM('_- ' FROM  UPPER(LastName)),	1,1)
	--		AS LastNameFirstCharacter,		
	--	SUBSTRING(
	--		TRIM('_- ' FROM  LOWER(LastName)),
	--		2, LEN(LastName))
	--		AS LastNameAllButFirstCharacter,
	--	SUBSTRING(
	--		TRIM('*. ' FROM  UPPER(FirstName)),1,1)
	--		AS FirstNameFirstCharacter,
	--	SUBSTRING(
	--		TRIM('*. ' FROM  LOWER(FirstName)),
	--		2,LEN(FirstName))
	--		AS FirstNameAllButFirstCharacter
	--INTO #TMP
	--FROM EmployeesUppercase

	--SELECT * FROM #TMP
	
	/*using #TMP*/
	--SELECT 		
	--	CONCAT(LastNameFirstCharacter,LastNameAllButFirstCharacter,', ',FirstNameFirstCharacter,FirstNameAllButFirstCharacter)
	--	AS EmployeeNameFormatted
	--FROM #TMP

	/*without using #TMP*/
	--SELECT 		
	--	CONCAT(
	--		SUBSTRING(
	--			TRIM('_- ' FROM  UPPER(LastName)),	1,1),
	--		SUBSTRING(
	--			TRIM('_- ' FROM  LOWER(LastName)),
	--			2, LEN(LastName)),
	--			', ',
	--		SUBSTRING(
	--			TRIM('*. ' FROM  UPPER(FirstName)),1,1),
	--		SUBSTRING(
	--			TRIM('*. ' FROM  LOWER(FirstName)),
	--			2,LEN(FirstName))
	--		) AS EmployeeNameFormatted
	--FROM EmployeesUppercase


/*adding funcationality to a user defined function*/

--SELECT 
--	dbo.FormatProperCasing('SunDAy'), 
--	dbo.FormatProperCasing('MONday'), 
--	dbo.FormatProperCasing('TUEsday')

--SELECT  
--		CONCAT(dbo.FormatProperCasing(TRIM('*. ' FROM  FirstName)),
--			', ',
--			dbo.FormatProperCasing(TRIM('_- ' FROM  LastName))
--		) AS FormattedName
--FROM EmployeesUppercase

--SELECT  
--		CONCAT_WS(', ',
--			dbo.FormatProperCasing(TRIM('*. ' FROM  FirstName)),
--			dbo.FormatProperCasing(TRIM('_- ' FROM  LastName))
--		) AS FormattedName
--FROM EmployeesUppercase






