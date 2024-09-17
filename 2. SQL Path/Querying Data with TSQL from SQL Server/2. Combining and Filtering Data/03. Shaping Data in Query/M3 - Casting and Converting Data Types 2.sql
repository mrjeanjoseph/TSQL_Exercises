/* working with	
	CAST, TRY_CAST, CONVERT, and TRY_CONVERT
*/

--using CAST to convert the current date to a varchar
SELECT CAST(GETDATE() AS varchar(50))

--using CAST to convert the current date to a varchar and limiting the length to show only the date
SELECT CAST(GETDATE() AS varchar(11))

--using CONVERT to add formatting with the pre-defined formatting options
SELECT CONVERT(varchar, GETDATE(), 0)
SELECT CONVERT(varchar, GETDATE(), 1)

--using CAST to convert to another data type can have unexpected results even if there isn't an error.
SELECT CAST(GETDATE() AS money)
--using CAST to convert to another data type can have unexpected results even if there isn't an error.
SELECT CONVERT(money, GETDATE( ))

/*unsupported data type conversions.  Use either try_cast or try_convert if you need to keep the conversion data types. */
SELECT CAST('hello' AS int)
SELECT CONVERT(int,'hello')


SELECT TRY_CAST('yellow' AS int)--returns null if the data type cannot be converted
SELECT TRY_CONVERT(int,'yellow')--returns null if the data type cannot be converted

/*TRY_CAST takes the value passed to it and tries to convert it to the specified data_type. 
If the cast succeeds, TRY_CAST returns the value as the specified data_type; if an error occurs, null is returned. 
HOWEVER, if you request a conversion that is explicitly not permitted, then TRY_CAST fails with an error.*/
SELECT TRY_CAST(GETDATE() AS text) -- cannot be converted


