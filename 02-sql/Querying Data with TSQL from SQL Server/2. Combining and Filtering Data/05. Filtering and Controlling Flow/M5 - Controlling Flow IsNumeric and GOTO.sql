USE Northwind
/* Add variables to create ad-hoc reporting query */
--declare the variables
DECLARE @num1 AS INT, @num2 AS INT, @numRows AS INT
--set values
SET @num1 = 10
SET @num2 = 5

IF ISNUMERIC(@num2) = 1 AND ISNUMERIC(@num2) = 1 AND @num2 > 0
	BEGIN
		GOTO CalcValue
	END
ELSE
	BEGIN
		GOTO PrintMessage
	END

CalcValue:
	PRINT CONCAT(@num1/@num2, CHAR(13))
	GOTO ContinueProcessing

PrintMessage:
	PRINT '@num2 = 0'

ContinueProcessing:
	PRINT 'Begin here'
	