
USE WideWorldImporters

SELECT 
	editedBy.FullName AS LastEditedBy,
	people.*
FROM 
	Application.People people
	LEFT JOIN Application.People editedBy 
	ON people.LastEditedBy = editedBy.PersonID



	
