USE Northwind

DECLARE @str AS VARCHAR(100)

SET @str = '**  . **.NA&&&NCY.****  _   '
--PRINT @str


SET @str = TRIM('* . 0 _' FROM @str)

--PRINT @str


/*  REPLACE ( string_expression , string_pattern , string_replacement ) */
SET @str = REPLACE(@str, '&', '')
PRINT @str

SET @str = CONCAT(SUBSTRING(UPPER(@str),1,1), SUBSTRING(LOWER(@str),2,LEN(@str)))

PRINT @str


/* CHARINDEX ( expressionToFind , expressionToSearch [ , start_location ] )  */

DECLARE @pos AS BIGINT
--SET @pos = CHARINDEX('&', @str)

--PRINT @pos

/* PATINDEX ( '%pattern%' , expression ) */  

SET @pos = PATINDEX('%[^ A-z ]%', @str)

PRINT @pos






