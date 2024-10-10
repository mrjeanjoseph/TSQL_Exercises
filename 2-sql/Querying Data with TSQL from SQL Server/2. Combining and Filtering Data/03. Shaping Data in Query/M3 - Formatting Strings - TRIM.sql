USE [Northwind]
--Step 1:  remove the leading and trailing spaces along with extra characters

--TRIM, RTRIM, LTRIM
SELECT TRIM('    hello    ')
SELECT RTRIM('    hello    ')
SELECT LTRIM('    hello    ')

--OPTIONAL use for TRIM
SELECT TRIM('* ' FROM  '*.*.*         hello')

/* Period(.) is used as a delimiter.  
If you want to remove everything after a period, 
you have to include it in the parameter of values to be removed. */
SELECT TRIM('* ' FROM  '*.*.*         hello')

