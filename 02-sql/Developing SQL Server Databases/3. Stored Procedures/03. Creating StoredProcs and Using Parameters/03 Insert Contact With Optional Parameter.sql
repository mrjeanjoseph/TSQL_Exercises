USE Contacts;
GO

DROP PROCEDURE IF EXISTS dbo.InsertContact;
GO

CREATE PROCEDURE dbo.InsertContact (
	@FirstName				VARCHAR(40),
	@LastName				VARCHAR(40),
	@DateOfBirth			DATE = NULL,
	@AllowContactByPhone	BIT )
AS
BEGIN;
	INSERT INTO dbo.Contacts (FirstName, LastName, DateOfBirth, AllowContactByPhone)
	VALUES (@FirstName, @LastName, @DateOfBirth, @AllowContactByPhone);
END;
GO 
RETURN

USE [Contacts]

--EXEC dbo.InsertContact 'Moise', 'Charles', '09/09/1971',1;
EXEC dbo.InsertContact
	@FirstName = 'Tonton',
	@LastName = 'Bicha',
	@AllowContactByPhone = 1;

SELECT * FROM dbo.Contacts ORDER BY ContactId DESC;