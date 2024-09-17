USE Contacts;
GO

DROP PROCEDURE IF EXISTS dbo.InsertContact;
GO

CREATE PROCEDURE dbo.InsertContact(
 @FirstName VARCHAR(40),
 @LastName VARCHAR(40),
 @DateOfBirth DATE = NULL,
 @AllowContactByPhone BIT )
AS
BEGIN;
	DECLARE @ContactId	INT;

	INSERT INTO dbo.Contacts (FirstName, LastName, DateOfBirth, AllowContactByPhone)
	VALUES (@FirstName, @LastName, @DateOfBirth, @AllowContactByPhone);

	SELECT @ContactId = SCOPE_IDENTITY();
	SELECT ContactId, FirstName, LastName, DateOfBirth, AllowContactByPhone
		FROM dbo.Contacts
	WHERE ContactId = @ContactId;
END;

GO
--Inserting Values
EXEC dbo.InsertContact 
	@firstName = 'Julie', 
	@LastName = 'Jean-Joseph', 
	@AllowContactByPhone = 0;