USE [Northwind]	

--STEP 2, Get just the first character of the first and last names using SUBSTRING

	SELECT SUBSTRING('hello',1,1) --returns h

	SELECT  		
		SUBSTRING(TRIM('* ' FROM  '********* hello'),1,1),
		SUBSTRING('********* hello',1,1)
		

	SELECT SUBSTRING('hello', 1, 1) --returns all but the first character
	SELECT SUBSTRING('hello', 2, 50) --returns all but the first character
	SELECT SUBSTRING('hello', 2, 2) --returns all but the first character
	SELECT LEN('hello') --returns an integer representing the length of the string
	SELECT SUBSTRING('hello',2,LEN('hello'))
	SELECT SUBSTRING('hello',2,LEN('hello')-1)

	

	SELECT 
		SUBSTRING(TRIM('_- ' FROM  LastName),	1,1) AS LastNameFirstCharacter,
		SUBSTRING(TRIM('_- ' FROM  LastName),2, LEN(LastName))AS LastNameAllButFirstCharacter,
		SUBSTRING(TRIM('*. ' FROM  FirstName),1,1) AS FirstNameFirstCharacter,
		SUBSTRING(TRIM('*. ' FROM  FirstName),2,LEN(FirstName))	AS FirstNameAllButFirstCharacter
	FROM EmployeesUppercase
	
