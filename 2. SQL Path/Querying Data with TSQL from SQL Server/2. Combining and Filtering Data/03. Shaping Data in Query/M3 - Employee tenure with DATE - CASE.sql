USE Northwind


/*simple CASE expression example*/

--SELECT 
--	CASE WHEN 1 = 5 THEN
--		'1 equals 5'
--	ELSE
--		'1 does not equal 5'
--	END AS result 

--SELECT 
--	CASE WHEN 1 > 0 THEN
--		'1 is greater than 0'
--	WHEN 1 = 1 THEN
--		 '1 equals 1'	
--	END AS result 

--SELECT GETDATE()

/* FORMAT( value, format [, culture ] )  */

/* using the 3rd optional [, culture ] paramenter */
--SELECT FORMAT( GETDATE(), 'd', 'en-US' ) 'US English'  
--      ,FORMAT( GETDATE(), 'd', 'en-gb' ) 'Great Britain English'  
--      ,FORMAT( GETDATE(), 'd', 'de-de' ) 'German'  
--      ,FORMAT( GETDATE(), 'd', 'zh-cn' ) 'Simplified Chinese (PRC)';  
  
--SELECT FORMAT( GETDATE(), 'D', 'en-US' ) 'US English'  
--      ,FORMAT( GETDATE(), 'D', 'en-gb' ) 'Great Britain English'  
--      ,FORMAT( GETDATE(), 'D', 'de-de' ) 'German'  
--      ,FORMAT( GETDATE(), 'D', 'zh-cn' ) 'Chinese (Simplified PRC)';  

	 
--SELECT FORMAT(GETDATE(), 'MM/d/yy')

--SELECT FORMAT(GETDATE(), 'MMM d yyyy')

--SELECT FORMAT(123456789, '###-##-####')

--SELECT CONVERT(VARCHAR, GETDATE(), 101)

--DECLARE @num AS INT
--SET @num = 012345678

--SELECT 
--	CASE WHEN LEN(@num) = 9 THEN
--		FORMAT(@num, '###-##-####')
--	ELSE 
--		'formatting not supported'
--	END

--SELECT 
--	CASE WHEN LEN(@num) = 9 THEN
--		FORMAT(@num, '###-##-####')
--	ELSE 
--		CONCAT(0,FORMAT(@num, '##-##-####'))
--	END

--SELECT FORMAT(8015551212, '(###) ###-####')

/* simple ISDATE expression example
  When true equals 1
  When false equals 0 */

--SELECT ISDATE(GETDATE())
--SELECT ISDATE('hello')

--SELECT ISNUMERIC(25)
--SELECT ISNUMERIC('hello')



/* How long have the employees worked for the company? 
	USE ISDATE and ISNUMERIC */
--SELECT 
--	CONCAT(dbo.Proper(LastName) , ', ' , dbo.Proper(FirstName)),
--	CASE WHEN  ISDATE(HireDate) = 1 THEN
--		'Hire date is available'
--	ELSE
--		'No hire date'
--	END AS ShipTime
--FROM Employees
 

--/* if there is a hire date, return the hire date formatted, otherwise, return 'No hire date' */
--SELECT 
--	CONCAT(dbo.Proper(LastName) , ', ' , dbo.Proper(FirstName)),
--	CASE WHEN  ISDATE(HireDate) = 1 THEN
--		FORMAT(HireDate, 'MMM dd yyyy')
--	ELSE
--		'No hire date'
--	END AS ShipTime
--FROM Employees
--ORDER BY 
--	DATEDIFF( YEAR,GETDATE(), HireDate ) DESC;



/*	 if there is a hire date, return the hire date formatted, otherwise, 
	return the number of years an employee has worked for the company */
SELECT 
	CONCAT(dbo.Proper(LastName) , ', ' , dbo.Proper(FirstName)),
	CASE WHEN  ISDATE(HireDate ) = 0 THEN
		'No hire date'
	WHEN DATEDIFF( YEAR, HireDate, GETDATE()  ) = 0 THEN
		'Less than 1 year'
	ELSE
		CAST(DATEDIFF( YEAR, HireDate, GETDATE()  )AS VARCHAR(50))
	END AS YearsWithCompany,
	CASE WHEN ISDATE(HireDate) = 1 THEN
		FORMAT(HireDate, 'MMM dd yyyy')
	ELSE		
		'Unknown' END AS HireDate
FROM Employees
ORDER BY 
	DATEDIFF( YEAR, HireDate, GETDATE() ) DESC;

--/* DATEDIFF */
--SELECT DATEDIFF( d, '01/01/2025', '02/01/2025' ); --calculating returns 31 as an integer

--SELECT CONCAT('There are ',DATEDIFF( d,GETDATE() ,'01/01/2025' ) , ' days between 1/1/25 and '
--	, FORMAT(GETDATE(), 'MMM/dd/yyyy)')) -- won't work unless you concat with string and int must convert int first

/*DATEPART*/
