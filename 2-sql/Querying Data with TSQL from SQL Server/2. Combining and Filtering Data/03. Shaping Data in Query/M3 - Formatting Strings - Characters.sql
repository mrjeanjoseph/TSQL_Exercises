USE Northwind

/*CHARINDEX is case sensitive!*/
SELECT 
	CHARINDEX('TEST',  
	'This is a Test'
	COLLATE Latin1_General_CS_AS); 
	

SELECT 
	CHARINDEX ( LOWER('TEST'),  
	LOWER('This is a Test') 
	COLLATE Latin1_General_CS_AS); 
	   
SELECT	
		ASCII('A') AS A, ASCII('B') AS B,   
		ASCII('a') AS a, ASCII('b') AS b,  
		ASCII(1) AS [1], ASCII(2) AS [2];  


SELECT dbo.Proper('hellen li')

SELECT CONCAT('Tamara Pattinson', CHAR(13), 'tamara-pattinson@pluralsight.com'   )

SELECT CONCAT(
		dbo.Proper(FirstName) , ' ' +
		dbo.Proper(LastName)
		)
		FROM EmployeesExtraCharacters

