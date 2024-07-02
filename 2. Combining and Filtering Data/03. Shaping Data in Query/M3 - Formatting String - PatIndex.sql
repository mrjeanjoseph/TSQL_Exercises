
use northwind


declare @str as varchar(8000)
set @str = '---PaTtInSon--HeINZ*&^$-'
declare @newstr as varchar(8000)
declare @len as int

--SELECT EmployeeId, Lastname, FirstName INTO #TMP2 FROM EmployeesExtraCharacters

SELECT * FROM #TMP2

SELECT value INTO #TMP FROM STRING_SPLIT(@str, '-');

DELETE FROM #TMP WHERE LEN(value) = 0 OR value IS NULL -- remove empty 


WHILE @len > 0
BEGIN


DELETE FROM #TMP WHERE LEN(value) = 0 OR value IS NULL -- remove empty 

	SELECT TOP 1 @str = value FROM #TMP

	WHILE PatIndex('%[^ 0-9A-z]%', @str) > 0
        SET @str = Stuff(@str, PatIndex('%[^ 0-9A-z]%', @str), 1, '')
	 
	WHILE PatIndex('%[0-9]%', @str) > 0
        SET @str = Stuff(@str, PatIndex('%[0-9]%', @str), 1, '')
		SELECT @str


	--UPDATE #TMP SET value = @newstr WHERE value = @str 

	SELECT * FROM #TMP
	DELETE TOP(1) FROM #TMP
	SET @len = @len - 1
END

SELECT * FROM #TMP



--WHILE @len > 0
--BEGIN  
	
----  SELECT SUBSTRING(@str, 1,1)
----  SET @newstr = SUBSTRING(@str, 2, LEN(@str))
----  SET @len = @len - 1
  
------SELECT @newstr
--END  

DROP TABLE #TMP



