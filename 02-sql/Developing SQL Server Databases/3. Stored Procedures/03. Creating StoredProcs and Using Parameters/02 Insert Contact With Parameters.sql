USE Contacts;
GO

DROP PROCEDURE IF EXISTS dbo.InsertContact;
GO

CREATE PROCEDURE dbo.InsertContact (
	@FirstName				VARCHAR(40),
	@LastName				VARCHAR(40),
	@DateOfBirth			DATE,
	@AllowContactByPhone	BIT )
AS
BEGIN;

	INSERT INTO dbo.Contacts (FirstName, LastName, DateOfBirth, AllowContactByPhone)
	VALUES (@FirstName, @LastName, @DateOfBirth, @AllowContactByPhone);

END;
GO
RETURN;


USE [Contacts]
GO

--EXEC dbo.InsertContact 'Moise', 'Charles', '09/09/1971',1;
EXEC dbo.InsertContact
	@FirstName = 'Tiery',
	@LastName = 'Henry',
	@DateOfBirth = '04/15/2001',
	@AllowContactByPhone = 1;

SELECT * FROM dbo.Contacts ORDER BY ContactId DESC;