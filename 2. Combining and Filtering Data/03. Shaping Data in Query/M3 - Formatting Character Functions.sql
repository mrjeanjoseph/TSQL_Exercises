USE Northwind

DECLARE	@str AS VARCHAR(MAX)
DECLARE @startPosition AS INT
DECLARE @pos AS INT

	SET @str = '-  _ ()  1234***()o%%%^''con?|{}|nor lisa-a_____N\ne janet li._'	

	SET @str = TRIM('- () _ .' FROM LOWER(@str))		

	SET @pos = 1	

	PRINT @str
	----remove all characters not alpha
	WHILE PATINDEX('%[^ A-z '''' -]%', @str) > 0
		BEGIN			
			SET @pos = PATINDEX('%[^ A-z '''' -]%', @str)
			SET @str = CONCAT(SUBSTRING(@str,1, @pos - 1),
					   SUBSTRING(@str,@pos + 1, LEN(@str)))
		END
					
	--PRINT @str
	   	 
	/* Capitalize the first letter of the string */
	SET @str = CONCAT(SUBSTRING(UPPER(@str),1,1), SUBSTRING(LOWER(@str),2,LEN(@str)))
	
	--PRINT @str
	
	
	
	
	--/*
	--  Capitalize the first letter after a single quote (IE:  O'Connor)
	--  Capitalize the first letter after any space in a name	
	--  Capitalize the first letter after any hyphen in a name
	--*/			
	
	SET @startPosition = 1
	SET @pos = 0

	WHILE CHARINDEX('''', @str, @startPosition) > 0	
		OR CHARINDEX('-', @str, @startPosition) > 0	
		OR CHARINDEX(' ', @str, @startPosition) > 0
		BEGIN
			IF CHARINDEX('''', SUBSTRING(@str, @startPosition,1)) > 0
				BEGIN
					SET @pos = CHARINDEX('''', @str, @startPosition)
				END
			ELSE IF CHARINDEX('-', SUBSTRING(@str, @startPosition,1)) > 0
				BEGIN
					SET @pos = CHARINDEX('-', @str, @startPosition)
				END
			ELSE IF CHARINDEX(' ', SUBSTRING(@str, @startPosition,1)) > 0
				BEGIN
					SET @pos = CHARINDEX(' ', @str, @startPosition)
				END

			SET @str = CONCAT(SUBSTRING(@str, 1, @pos), 
				SUBSTRING(UPPER(@str),@pos + 1, 1),
				SUBSTRING(@str,@pos + 2, LEN(@str)))

			SET @startPosition = @startPosition + 1
		END


	
	PRINT TRIM(@str)

