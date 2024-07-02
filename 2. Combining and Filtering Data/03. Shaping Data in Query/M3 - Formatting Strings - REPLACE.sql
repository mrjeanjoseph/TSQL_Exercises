USE Northwind

--removing all occurrences of the '*.' and '_-' characters from the fields using REPLACE
	SELECT 
		FirstName, 
		REPLACE(FirstName,'*.','_'),
		LastName, 
		REPLACE(LastName, '_-','_') 
	FROM EmployeesUppercase

	SELECT 
		FirstName, 
		REPLACE(FirstName,'*.',''),
		LastName, 
		REPLACE(LastName, '_-','') 
	FROM EmployeesUppercase
	
	
	--CAUTION!  Replace removes all occurances
	SELECT
		LastName, 
		REPLACE(LastName, '-','') 
	FROM EmployeesUppercase
	