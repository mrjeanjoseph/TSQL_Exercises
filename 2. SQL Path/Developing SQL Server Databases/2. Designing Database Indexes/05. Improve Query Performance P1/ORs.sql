-- OR predicates


SELECT TransactionID, ReferenceShipmentID, InvoiceNumber FROM dbo.Transactions 
	WHERE ReferenceShipmentID = 452 OR InvoiceNumber = 'BBBC20425'

CREATE NONCLUSTERED INDEX idx_Test ON dbo.Transactions (ReferenceShipmentID, InvoiceNumber)
DROP INDEX IF EXISTS Transactions.idx_Test,Transactions.idx_Test1,Transactions.idx_Test2

CREATE NONCLUSTERED INDEX idx_Test1 ON dbo.Transactions (ReferenceShipmentID)
CREATE NONCLUSTERED INDEX idx_Test2 ON dbo.Transactions (InvoiceNumber)

SELECT TransactionID, ClientID, Amount, TransactionType FROM dbo.Transactions 
	WHERE ClientID = 2875 AND (Amount > 2500 OR TransactionType = 'S')

SELECT TransactionID
FROM dbo.Transactions
WHERE ClientID = 2875
	AND (Amount > 2500 OR TransactionType = 'S');

SELECT TransactionID
FROM dbo.Transactions
WHERE (ClientID = 2875 AND Amount > 2500)
	OR (ClientID = 2875 AND TransactionType = 'S');

CREATE NONCLUSTERED INDEX idx_Test3 ON dbo.Transactions (ClientID,Amount)
CREATE NONCLUSTERED INDEX idx_Test4 ON dbo.Transactions (TransactionType,ClientID)
