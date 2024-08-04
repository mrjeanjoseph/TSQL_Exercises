 USE Northwind

 SELECT
	pc.CompanyName AS ParentCompany,
	c.*
 FROM 
	Customers c 
LEFT JOIN Customers pc ON c.ParentCompanyID = pc.CustomerID
ORDER BY pc.CompanyName DESC