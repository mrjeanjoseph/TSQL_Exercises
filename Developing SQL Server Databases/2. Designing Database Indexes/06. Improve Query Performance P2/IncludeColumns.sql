-- include columns

SELECT TransactionID, ClientID, TransactionType, Amount, TransactionDate FROM dbo.Transactions
	WHERE ClientID = 3014 AND TransactionType = 'D'


USE [InterstellarTransport]
GO
CREATE NONCLUSTERED INDEX idx_test6
ON [dbo].[Transactions] (ClientID, TransactionType)

CREATE NONCLUSTERED INDEX idx_test7
ON [dbo].[Transactions] (ClientID, TransactionType)
INCLUDE (Amount, TransactionDate, TransactionID)

SELECT TransactionID, ClientID, TransactionType, Amount, TransactionDate FROM dbo.Transactions
	WHERE TransactionType = 'W'

CREATE NONCLUSTERED INDEX idx_test9
ON [dbo].[Transactions] (TransactionType)

SELECT * FROM dbo.Transactions

--Always try to get index seek option
CREATE NONCLUSTERED INDEX idx_test61
ON [dbo].[Transactions] (TransactionType)
INCLUDE(ClientID, Amount, TransactionDate, TransactionID)