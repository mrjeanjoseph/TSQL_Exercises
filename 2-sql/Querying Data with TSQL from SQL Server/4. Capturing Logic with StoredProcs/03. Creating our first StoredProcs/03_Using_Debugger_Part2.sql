USE [BonRepos];
GO

CREATE OR ALTER PROCEDURE Sales.GenerateRandomMessage
  @RandomNumber int
AS
BEGIN

	DECLARE @PlaceHolder int;

	SET @PlaceHolder = (@RandomNumber-3);

	IF (@PlaceHolder < 3)
		BEGIN

			PRINT 'You are the lucky winner!';

		END

	IF (@PlaceHolder > 3 AND @PlaceHolder < 21)
		BEGIN

			PRINT 'Not bad but not great';

		END

	IF (@PlaceHolder > 21 AND @PlaceHolder < 31)
		BEGIN

			PRINT 'That was not good';

		END

END;
GO