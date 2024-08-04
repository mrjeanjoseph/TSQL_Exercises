USE Northwind
/* Add variables to create ad-hoc reporting query */
--declare the variables
DECLARE @num AS INT, @num2 AS INT
--set values
SET @num = 15
SET @num2 = 10


--IF @num > @num2 --if TRUE executes the statement block inside BEGIN/END
--	BEGIN
--		PRINT CONCAT('TRUE: ', @num,  ' is greater than ', @num2)
--	END	

--IF @num < @num2 --if TRUE executes the statement block inside BEGIN/END
--	BEGIN
--		PRINT CONCAT('TRUE: ', @num, ' is less than ', @num2)
--	END	
--	PRINT 'outside the code block'

--IF @num > @num2  --EXECUTES TRUE 
--    BEGIN
--		PRINT 'TRUE'
--    END;
--ELSE --EXECUTES when the statement is FALSE
--	BEGIN
--		PRINT 'FALSE'
--    END;

--SELECT CASE WHEN @num > @num2 THEN 'TRUE' ELSE 'FALSE ' END AS 'true'

--SELECT IIF( @num > @num2, 'TRUE', 'FALSE' );

--SELECT IIF( @num < @num2, 
--					CONCAT(@num, ' is greater than ',@num2) , 
--					CONCAT(@num2, ' is not greater than ', @num))

--SET @num = 10
--SET @num2 = 10
--IF @num < @num2  --EXECUTES when TRUE
--    BEGIN
--		PRINT CONCAT_WS(' ',@num, 'is less than',@num2)
--    END;
--ELSE IF @num > @num2 --EXECUTES when TRUE
--	BEGIN
--		PRINT CONCAT_WS(' ',@num, 'is greater than',@num2)
--    END;
--ELSE --Executes when the IF and ELSE IF evaluate to FALSE
--	BEGIN
--		PRINT CONCAT_WS(' ',@num, 'is equal to', @num2)
--	END

--PRINT CONCAT('Finished IF',CHAR(13))


--IF @num < @num2  --EXECUTES when TRUE (@num = 15, @num2 = 10)
--    BEGIN
--		PRINT CONCAT_WS(' ',@num, 'is less than',@num2)
--    END;
--ELSE IF @num > @num2 --EXECUTES when TRUE
--	BEGIN
--		PRINT CONCAT_WS(' ',@num, 'is greater than',@num2)
--    END;
--ELSE IF @num >= @num2 --EXECUTES when TRUE
--	BEGIN
--		PRINT CONCAT_WS(' ',@num, 'is greater than or equal to ',@num2)
--    END;
--ELSE --Executes when the IF and ELSE IF evaluate to FALSE
--	BEGIN
--		PRINT CONCAT_WS(' ',@num, 'is equal to', @num2)
--	END

--PRINT CONCAT('Finished IF',CHAR(13))



--DECLARE @firstNum AS INT
--SET @firstNum = 0

--WHILE @firstNum < 10
--    BEGIN
--         SET @firstNum = @firstNum + 1
--         PRINT CONCAT('@firstNum = ', @firstNum)
--    END
--PRINT 'Finished WHILE'


--WHILE @firstNum <= 3
--         SET @firstNum = @firstNum + 1
--         PRINT @firstNum
--PRINT 'Finished WHILE'


--WHILE 1 = 1  --creates an infinite loop!
--	BEGIN
--		PRINT '1 will always equal 1'
--	END

--using BREAK stops execution
--WHILE 1 = 1
--	BEGIN
--		PRINT '1 will always equal 1'
--		BREAK
--	END

--DECLARE @numTimes AS INT
--SET @numTimes = 0

--WHILE 1 = 1
--	BEGIN		
--		PRINT '1 will always equal 1'
--		BREAK
--		PRINT 'I won''t print'
--	END

--PRINT 'exited while using BREAK'

--WHILE 1 = 1
--	BEGIN
--		SET @numTimes = @numTimes + 1
--		PRINT '1 will always equal 1'
--		IF @numTimes > 5
--			BREAK		
--		ELSE IF @numTimes < 10
--			CONTINUE
--	END
--PRINT @numTimes


--WHILE 1 = 1
--	BEGIN
--		SET @numTimes = @numTimes + 1
--		IF @numTimes > 5
--			GOTO GoToStartsHere		
--		ELSE IF @numTimes < 10
--			CONTINUE
--	END
--PRINT @numTimes
--GoToStartsHere:
--	PRINT 'GO TO skipped to here'


--SET @firstNum = 51
--WHILE (@firstNum <= 3)
--BEGIN
--	SET @firstNum = @firstNum - 1
--	IF @firstNum < 0
--		BEGIN
--			PRINT CONCAT(@firstNum, ' is less than 0')
--			BREAK
--		END   
--	PRINT CONCAT('The variable @firstNum equals ', @firstNum)
--END


--WHILE (1 = 1)
--BEGIN
--	PRINT 'still running loop'
--	WAITFOR DELAY '00:00:02'
--		PRINT 'time''s up!'
--		BREAK
--END

--BEGIN
--   PRINT 'I''m counting...';  
--   WAITFOR DELAY '00:00:02' --starting now!
--   PRINT '2 seconds is up'
--   WAITFOR DELAY '00:00:03';  -- Sleep for 3 seconds.   
--   PRINT '3 seconds is up'
--   PRINT 'This took 5 seconds to run!'
--END

--BEGIN
--   PRINT 'I''m counting...';  
--   WAITFOR DELAY '00:00:02' --starting now!
--   PRINT '2 seconds is up'
--   WAITFOR DELAY '00:00:03';  -- Sleep for 3 seconds.   
--   PRINT '3 seconds is up'
--   PRINT 'This took 5 seconds to run!'
--   RETURN
--END

--PRINT 'will not execute'


--DECLARE @includeNULLS AS BIT
--DECLARE @searchTerm AS varchar(max)
--SET @searchTerm = '10268'
--IF @searchTerm IS NOT NULL
----this sets the most recent quarter and year
--    BEGIN
--        SELECT *
--        FROM Orders
--        WHERE OrderID = @searchTerm
--    END;
--ELSE 
--    BEGIN
--        SELECT *
--        FROM Orders
--    END;


