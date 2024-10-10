/*
Author: <Please enter a name>

Description: <Please enter a detailed description of the stored procedure>

Update: <Please enter a name and description of the update>
*/

CREATE OR ALTER PROCEDURE <Schema_Name, sysname, Sales>.<Procedure_Name, sysname, [Update]>
<@param1, sysname, @p1> <datatype_for_param1, , int>
AS
BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		BEGIN TRANSACTION;

		/*Insert our code here*/

		COMMIT TRANSACTION;
	
	END TRY

	BEGIN CATCH

		IF (@@TRANCOUNT > 0)
		
			ROLLBACK TRANSACTION;

			THROW;

	END CATCH

END




-- Microsoft article on template explorer
-- https://docs.microsoft.com/en-us/sql/ssms/template/template-explorer?view=sql-server-2017

-- Nice article from SQLShack
-- https://www.sqlshack.com/how-to-create-and-customize-sql-server-templates/