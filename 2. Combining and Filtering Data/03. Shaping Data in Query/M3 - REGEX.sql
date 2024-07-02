

DECLARE @str AS VARCHAR(MAX)
DECLARE @firstCharacter AS VARCHAR(1)

SET @str = '_-LEV123ERLING'
SET @str = TRIM('-_' FROM @str)

DECLARE @pattern AS VARCHAR(MAX)
SET @pattern = '%[^ A-z\''''\-]%'  --REGEX pattern.  The caret (^) means ignore these values.
SET @str = TRIM(' -' FROM @str)
	----remove all characters not alpha
	WHILE PATINDEX(@pattern, @str) > 0
		BEGIN
			SET @str = STUFF(@str, PATINDEX(@pattern, @str), 1, '')
		END

	SET @firstCharacter =  		
		SUBSTRING(UPPER(@str), 1,1) --result is first letter
		

	SET @str = CONCAT(@firstCharacter,LOWER(SUBSTRING(@str,2,LEN(@str))))

SELECT @str
