USE Northwind

SELECT 		
	CONCAT(
		UPPER(
		SUBSTRING(
		TRIM(LastName),1,1)
		),
		LOWER(
		SUBSTRING(
		TRIM(LastName),
		2, LEN(LastName))),
		', ',
		UPPER(
		SUBSTRING(
		TRIM(FirstName),1,1)
		),
		LOWER(
		SUBSTRING(
		TRIM(FirstName),
		2, LEN(FirstName)))
		)
		AS FormattedName
FROM EmployeesUppercase

/* this query will call the proper user defined function and replace the need for
most of the functionality in the query above. */

SELECT CONCAT_WS(', ', dbo.Proper(LastName), dbo.Proper(FirstName)) 
AS FormattedName FROM EmployeesUppercase

