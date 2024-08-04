USE BossBaeBoutique;
GO

DROP PROCEDURE IF EXISTS dbo.InsertContactRole;
GO

CREATE PROCEDURE dbo.InsertContactRole (
 @ContactId	INT,
 @RoleTitle	VARCHAR(200) )
AS
BEGIN;

	DECLARE @RoleId INT;
		
	BEGIN TRANSACTION;
		INSERT INTO dbo.Roles (RoleTitle)
		VALUES (@RoleTitle);

		SELECT @RoleId = SCOPE_IDENTITY();

		INSERT INTO dbo.ContactRoles (ContactId, RoleId)
		VALUES (@ContactId, @RoleId);

		SELECT	C.ContactId, C.FirstName, C.LastName, R.RoleTitle
		FROM dbo.Contacts C
			INNER JOIN dbo.ContactRoles CR
				ON C.ContactId = CR.ContactId
			INNER JOIN dbo.Roles R
				ON CR.RoleId = R.RoleId
		WHERE C.ContactId = @ContactId
			AND R.RoleId = @RoleId;

	COMMIT TRANSACTION;
END;
GO
RETURN;


--Testing the StoredProc
EXEC dbo.InsertContactRole
	@ContactId = 22,
	@RoleTitle = 'Comedian';

SELECT * FROM dbo.Roles ORDER BY RoleId DESC;
SELECT * FROM dbo.ContactRoles cr
INNER JOIN dbo.Roles r 
	ON cr.RoleId = r.RoleId
WHERE cr.ContactId = 22


DELETE FROM dbo.Roles WHERE RoleTitle = 'Comedian';