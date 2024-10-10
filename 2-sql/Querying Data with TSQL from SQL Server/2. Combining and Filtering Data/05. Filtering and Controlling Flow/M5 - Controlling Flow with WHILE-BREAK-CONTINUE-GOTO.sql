USE Northwind
/* Add variables to create ad-hoc reporting query */
--declare the variables
DECLARE @num AS INT
--set value
SET @num = 0

WHILE @num < 10
    BEGIN
         SET @num = @num + 1
         PRINT CONCAT('@num = ', @num)
    END
PRINT 'Finished'


WHILE 1 = 1  --creates an infinite loop!
	BEGIN
		PRINT '1 will always equal 1'
	END

/*using BREAK stops execution*/
WHILE 1 = 1
	BEGIN
		PRINT '1 will always equal 1'
		BREAK
	END


SET @num = 1
WHILE @num < 1000
	BEGIN
		SET @num = @num + 1
		PRINT @num
		IF @num < 5
			BEGIN
				SET @num = @num + 1
				PRINT @num
				print 'continue'
				CONTINUE
				SET @num = @num + 5
				PRINT @num
			END
		ELSE
			BEGIN
				SET @num = @num + 1
				BREAK
			END
				END
PRINT @num