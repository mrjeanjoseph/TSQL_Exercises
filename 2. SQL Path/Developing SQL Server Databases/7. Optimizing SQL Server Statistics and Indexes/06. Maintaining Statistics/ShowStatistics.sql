USE [InterstellarTransport];
GO

--Create this Index first
CREATE NONCLUSTERED INDEX [idx_Transactions_TransactionDate]
	ON [dbo].[Transactions] ([TransactionDate])
	INCLUDE ([ReferenceShipmentID],[TransactionType],[Amount],[InvoiceNumber])
GO

DBCC SHOW_STATISTICS(Transactions, 'idx_Transactions_TransactionDate');
GO

UPDATE STATISTICS dbo.Transactions idx_Transaction_TransactionDate WITH FULLSCAN;
GO