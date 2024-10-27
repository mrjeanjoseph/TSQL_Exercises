USE Contacts;
GO

CREATE OR ALTER PROCEDURE dbo.InsertContact
AS
BEGIN;
	DECLARE @FirstName				VARCHAR(40),
			@LastName				VARCHAR(40),
			@DateOfBirth			DATE,
			@AllowContactByPhone	BIT;

	-- Don't do it
	SELECT	@FirstName = 'Jovenel',
			@LastName = 'Moise',
			@DateOfBirth = '1970-06-16',
			@AllowContactByPhone = 0;

	INSERT INTO dbo.Contacts (FirstName, LastName, DateOfBirth, AllowContactByPhone)
	VALUES (@FirstName, @LastName, @DateOfBirth, @AllowContactByPhone);

END;
GO
RETURN;


USE [Contacts]
GO

EXEC dbo.InsertContact;
SELECT * FROM dbo.Contacts ORDER BY ContactId DESC;