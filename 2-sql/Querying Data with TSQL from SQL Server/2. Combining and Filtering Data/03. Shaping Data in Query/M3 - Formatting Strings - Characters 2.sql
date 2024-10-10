Use Northwind


DECLARE @pos int, @isDelimiter char(1), @delimiters VARCHAR(MAX), @firstCharacter VARCHAR(1),@str AS VARCHAR(MAX)
 
	SET @isDelimiter = 'Y'			-- 'Y' indicates that current character is a delimiter
	SET @pos = 1		
	SET @delimiters =  '%[^ A-z\''''\-]%'

--PRINT and CHAR()


--TRIM
SELECT TRIM('*-_ ^' from '****.*hi*.-*_ ^')

SELECT TRIM('*.-_ ^' from '****.*hi-*_ ^') --must include period(.) to remove ALL characters

--REPLACE
SELECT REPLACE('****.*','****.*hi-*_ ^','') --removes patterns only

--CHARINDEX
SELECT CHARINDEX('.', '****.*hi-*_ ^') --returns the placement of the character expression as an integer.

--REGEX


--PATINDEX & STUFF
WHILE PATINDEX(@Delimiters, @str) > 0
		BEGIN
			SET @str = STUFF(@str, PATINDEX(@Delimiters, @str), 1, '')
		END
