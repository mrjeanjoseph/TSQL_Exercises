SELECT GETDATE()

SELECT CAST(GETDATE() AS varchar)

SELECT CAST(GETDATE() AS varchar(11)) AS CurrentDate

SELECT 
	CONVERT(varchar(50), GETDATE(), 101) AS CurrentDate,
	CONVERT(varchar,GETDATE(),1),
	CONVERT(varchar, GETDATE(), 2)

SELECT 
	CAST(GETDATE() AS money),
	CONVERT(money, GETDATE())

SELECT TRY_CAST('hello world' AS int)

SELECT TRY_CONVERT(int, 'hello world')

SELECT 
	TRY_CAST(GETDATE() AS image),
	TRY_CONVERT(image, GETDATE())















