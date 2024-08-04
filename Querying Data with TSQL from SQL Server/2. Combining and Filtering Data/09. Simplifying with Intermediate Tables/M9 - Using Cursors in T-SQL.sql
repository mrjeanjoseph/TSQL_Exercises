
DECLARE @empId AS Int
DECLARE @lastName AS VARCHAR(100)
DECLARE @firstName AS VARCHAR(50)

DECLARE employee_cursor CURSOR FOR

SELECT EmployeeId, FirstName, LastName FROM Employees

OPEN employee_cursor

FETCH NEXT FROM employee_cursor
INTO @empId, @firstName, @lastName

WHILE @@FETCH_STATUS = 0
BEGIN
	PRINT CAST(@empId AS VARCHAR(20)) + ': ' + CONCAT_WS(', ', TRIM(@lastName), TRIM(@firstName))
	
	FETCH NEXT FROM employee_cursor
	INTO @empId, @firstName, @lastName
END

CLOSE employee_cursor
DEALLOCATE employee_cursor