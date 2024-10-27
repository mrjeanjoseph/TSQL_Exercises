USE RHJsShoes;
GO

SET LOCK_TIMEOUT -1 -- Wait forever
BEGIN TRAN;
    UPDATE Orders.Orders 
    SET OrderRequestedDate = '30000101'
    WHERE OrderID = 1;
COMMIT;

-- Restore previous order requested date

BEGIN TRAN;
    UPDATE Orders.Orders 
    SET OrderRequestedDate = '20190601'
    WHERE OrderID = 1;
COMMIT;


--Not recommended, reserved for DBA
SELECT * FROM Orders.Orders
	WITH(READUNCOMMITTED)