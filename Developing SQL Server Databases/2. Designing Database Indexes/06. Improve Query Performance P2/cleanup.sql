USE [InterstellarTransport]; 
GO

DECLARE @tableName NVARCHAR(MAX) = 'Transactions'; 
DECLARE @indexName NVARCHAR(MAX);

DECLARE DropIndexCursor CURSOR FOR
    SELECT name
    FROM SYS.INDEXES
    WHERE OBJECT_ID = OBJECT_ID(@tableName);

OPEN DropIndexCursor;
FETCH NEXT FROM DropIndexCursor INTO @indexName;

WHILE @@FETCH_STATUS = 0
BEGIN
    DECLARE @sql NVARCHAR(MAX);
    SET @sql = 'DROP INDEX ' + QUOTENAME(@tableName) + '.' + QUOTENAME(@indexName);
	PRINT @sql;
    --EXEC sp_executesql @sql;

    FETCH NEXT FROM DropIndexCursor INTO @indexName;
END

CLOSE DropIndexCursor;
DEALLOCATE DropIndexCursor;


--Script above would not run b/c of PK index
BEGIN
	DROP INDEX [Transactions].[idx_Transactions_TransactionTypeAmount]
	DROP INDEX [Transactions].[idx_Transactions_AmountTransactionDate]
	DROP INDEX [Transactions].[idx_Transactions_TransactionTypeClientID]
	DROP INDEX [Transactions].[idx_Transactions_AmountTransactionDate2]
	DROP INDEX [Transactions].[idx_Transactions_TransactionDateAmount]
	DROP INDEX [Transactions].[idx_Test2]
	DROP INDEX [Transactions].[idx_Test3]
	DROP INDEX [Transactions].[idx_Test4]
	DROP INDEX [Transactions].[idx_test6]
	DROP INDEX [Transactions].[idx_test7]
	DROP INDEX [Transactions].[idx_test9]
	DROP INDEX [Transactions].[idx_test61]
	DROP INDEX [Transactions].[idx_Test62]
END