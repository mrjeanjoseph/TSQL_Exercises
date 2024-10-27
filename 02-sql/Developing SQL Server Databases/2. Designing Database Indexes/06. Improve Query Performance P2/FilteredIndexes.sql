-- filtered indexes
USE InterstellarTransport

SELECT TransactionID, ClientID, TransactionType FROM dbo.Transactions
	WHERE ClientID = 3014 AND TransactionType = 'D'

GO
--We can filter indexes
CREATE NONCLUSTERED INDEX idx_Test62 ON dbo.Transactions (ClientID)
WHERE TransactionType = 'D'

DECLARE @ClientID INT = 3014, @TransactionType CHAR(1) = 'D'

SELECT TransactionID, ClientID, TransactionType FROM dbo.Transactions
	WHERE ClientID = @ClientID AND TransactionType = @TransactionType

