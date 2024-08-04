DROP TABLE IF EXISTS 
	dbo.TransactionClusteredAll,
	dbo.TransactionClusteredAmount,
	dbo.TransactionClusteredDate

DROP INDEX IF EXISTS
	dbo.TransactionClusteredAll.idx_TransactionClusteredAll,
	dbo.TransactionClusteredAmount.idx_TransactionClusteredAmount,
	dbo.TransactionClusteredDate.idx_TransactionClusteredDate
GO

SELECT * INTO TransactionsClusteredAll FROM dbo.Transactions
CREATE CLUSTERED INDEX idx_TransactionsClusteredAll
	ON dbo.TransactionsClusteredAll(
		ReferenceShipmentID, 
		ClientID,
		TransactionDate,
		TransactionType,
		Amount,
		InvoiceNumber)
GO 

SELECT * INTO TransactionsClusteredAmount FROM dbo.Transactions
CREATE CLUSTERED INDEX idx_TransactionsClusteredAmount
	ON dbo.TransactionsClusteredAmount (Amount)
GO

SELECT * INTO TransactionsClusteredDate FROM dbo.Transactions
CREATE CLUSTERED INDEX idx_TransactionsClusteredDate
	ON dbo.TransactionsClusteredDate (Amount)
GO


SELECT
	OBJECT_NAME(OBJECT_ID) AS [Table Name],
	used_page_count,
	reserved_page_count,
	row_count
FROM SYS.DM_DB_PARTITION_STATS
WHERE OBJECT_NAME(OBJECT_ID) IN (
		'TransactionsClusteredAll',
		'TransactionsClusteredAmount',
		'TransactionsClusteredDate')