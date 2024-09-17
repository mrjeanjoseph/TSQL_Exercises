USE RHJsShoes;
GO

BEGIN TRAN;

INSERT INTO Orders.Orders (
  OrderYear, OrderDate, OrderRequestedDate, CustID)
    VALUES 
		(2019, '20190701', '20190808', 2),
		(2019, '20190701', '20190808', 2),
		(2019, '20190701', '20190808', 2);

ROLLBACK;    
