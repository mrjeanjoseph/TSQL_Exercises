USE Northwind

SELECT 
	emps.EmployeeID,
	CONCAT_WS(', ',emps.LastName,emps.FirstName) AS Employee,
	CASE WHEN emps.ReportsTo IS NULL THEN
		'no manager assigned'
	ELSE
		CONCAT_WS(', ',mgrs.LastName, mgrs.FirstName)
	END AS Manager
 FROM Employees emps
LEFT JOIN Employees mgrs on emps.ReportsTo = mgrs.EmployeeID


 


