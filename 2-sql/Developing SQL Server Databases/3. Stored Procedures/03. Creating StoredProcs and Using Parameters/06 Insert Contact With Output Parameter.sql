USE Contacts;
GO

DROP PROCEDURE IF EXISTS dbo.InsertContact;
GO

CREATE PROCEDURE dbo.InsertContact (
 @FirstName				VARCHAR(40),
 @LastName				VARCHAR(40),
 @DateOfBirth			DATE = NULL,
 @AllowContactByPhone	BIT,
 @ContactId				INT OUTPUT )
AS
BEGIN;
	INSERT INTO dbo.Contacts (FirstName, LastName, DateOfBirth, AllowContactByPhone)
	VALUES (@FirstName, @LastName, @DateOfBirth, @AllowContactByPhone);

	SELECT @ContactId = SCOPE_IDENTITY();
	SELECT ContactId, FirstName, LastName, DateOfBirth, AllowContactByPhone
	FROM dbo.Contacts
	WHERE ContactId = @ContactId;
END;
GO

DECLARE @ContactIdOut INT;
--Inserting Values
EXEC dbo.InsertContact 
	@firstName = 'Denzel', 
	@LastName = 'Jean-Joseph', 
	@AllowContactByPhone = 0,
	@ContactId = @ContactIdOut OUTPUT;

SELECT @ContactIdOut AS [ContactIdOut];
SELECT * FROM dbo.Contacts WHERE ContactId = @ContactIdOut ORDER BY ContactId DESC;