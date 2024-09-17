USE Northwind
/* Add variables to create ad-hoc reporting query */
--declare the variables
DECLARE @num1 AS INT, @num2 AS INT, @numRows AS INT
--set values
SET @num1 = 5
SET @num2 = 10


IF @num1 < @num2 --if TRUE executes the statement block inside BEGIN/END
	BEGIN
		PRINT CONCAT('TRUE: ', @num1,  ' is less than ', @num2)
	END	

PRINT 'outside the if statement'





IF @num1 > @num2 OR @num1 = @num2 --if TRUE executes the statement block inside BEGIN/END
	BEGIN
		PRINT CONCAT('TRUE: ', @num1,  ' is greater than or equal to ', @num2)
	END	



DECLARE @order_id AS INT
SELECT * FROM Orders WHERE OrderID = @order_id

IF @@ROWCOUNT = 0
	BEGIN
		PRINT 'Record not found'
	END	


IF @num1 > @num2  --EXECUTES TRUE 
    BEGIN
		PRINT 'TRUE'
    END;
ELSE --EXECUTES when the statement is FALSE
	BEGIN
		PRINT 'FALSE'
    END;

SELECT CASE WHEN @num1 > @num2 THEN 'TRUE' ELSE 'FALSE ' END AS 'true'

SELECT IIF( @num1 > @num2, 'TRUE', 'FALSE' );

SELECT IIF( @num1 < @num2, 
					CONCAT(@num1, ' is greater than ',@num2) , 
					CONCAT(@num2, ' is not greater than ', @num1))

SET @num1 = 10
SET @num2 = 10
IF @num1 < @num2  --EXECUTES when TRUE
    BEGIN
		PRINT CONCAT_WS(' ',@num1, 'is less than',@num2)
    END;
ELSE IF @num1 > @num2 --EXECUTES when TRUE
	BEGIN
		PRINT CONCAT_WS(' ',@num1, 'is greater than',@num2)
    END;
ELSE --Executes when the IF and ELSE IF evaluate to FALSE
	BEGIN
		PRINT CONCAT_WS(' ',@num1, 'is equal to', @num2)
	END

PRINT CONCAT('Finished IF',CHAR(13))


IF @num1 < @num2  --EXECUTES when TRUE (@num = 15, @num2 = 10)
    BEGIN
		PRINT CONCAT_WS(' ',@num1, 'is less than',@num2)
    END;
ELSE IF @num1 > @num2 --EXECUTES when TRUE
	BEGIN
		PRINT CONCAT_WS(' ',@num1, 'is greater than',@num2)
    END;
ELSE IF @num1 >= @num2 --EXECUTES when TRUE
	BEGIN
		PRINT CONCAT_WS(' ',@num1, 'is greater than or equal to ',@num2)
    END;
ELSE --Executes when the IF and ELSE IF evaluate to FALSE
	BEGIN
		PRINT CONCAT_WS(' ',@num1, 'is equal to', @num2)
	END

PRINT CONCAT('Finished IF',CHAR(13))

/* using IIF */
DECLARE @int AS INT
SET @int = 5


SELECT IIF(@int > 5, 'not greater than 5', 'greater than 5')




DECLARE @includeNULLS AS BIT
DECLARE @searchTerm AS varchar(max)
SET @searchTerm = '10268'
IF @searchTerm IS NOT NULL
--this sets the most recent quarter and year
    BEGIN
        SELECT *
        FROM Orders
        WHERE OrderID = @searchTerm
    END;
ELSE 
    BEGIN
        SELECT *
        FROM Orders
    END;


