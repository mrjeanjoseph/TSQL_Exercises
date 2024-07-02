USE Northwind
/*return everything from employeesuppercase*/

/* the asterisk wildcard returns all fields*/
SELECT * FROM EmployeesUppercase

SELECT CONCAT_WS(', ',LastName, FirstName) FROM EmployeesUppercase