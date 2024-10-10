/* working with	
	CAST, TRY_CAST, CONVERT, and TRY_CONVERT
*/

--using CAST to convert the current date to a varchar
SELECT CAST(GETDATE() AS varchar(50))


--using CAST to convert the current date to a varchar and limiting the length to show only the date
SELECT CAST(GETDATE() AS varchar(11))

SELECT CAST(4 AS xml)--unsupported data type conversion.  Use a try_cast if you need to keep the conversion data types.

SELECT CAST('hello' AS int)

SELECT TRY_CAST('hello' AS int)

/*TRY_CAST takes the value passed to it and tries to convert it to the specified data_type. 
If the cast succeeds, TRY_CAST returns the value as the specified data_type; if an error occurs, null is returned. 
HOWEVER, if you request a conversion that is explicitly not permitted, then TRY_CAST fails with an error.*/
SELECT TRY_CAST(4 AS xml) AS Result;  -- cannot be converted
