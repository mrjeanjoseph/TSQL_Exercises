USE Northwind
/* NULL is not included in comparison operators when ANSI_NULL = ON */

SET ANSI_NULLS OFF
SELECT * FROM Orders WHERE OrderDate = NULL --only works when the system setting ANSI_NULLS = OFF
SELECT * FROM Orders WHERE OrderDate != NULL --only works when the system setting ANSI_NULLS = OFF

SET ANSI_NULLS ON
SELECT * FROM Orders WHERE OrderDate = NULL --will not work if ANSI_NULLS = ON
SELECT * FROM Orders WHERE OrderDate != NULL --will not work when the system setting ANSI_NULLS = OFF

/* best practice.  Ignores the ANSI_NULL setting */
SELECT * FROM Orders WHERE OrderDate IS NULL --22
SELECT * FROM Orders WHERE OrderDate IS NOT NULL  -- 810

SET ANSI_NULLS ON
/* ANSI_NULL ignores NULL on all values when set to ON */
SELECT * FROM Orders WHERE DATEPART(year, OrderDate) < 2019 -- 0 records because there are nulls

/* Use a logical operator with comparison operator to include values of null */
SELECT * FROM Orders WHERE DATEPART(year, OrderDate) < 2019 OR OrderDate IS NULL -- 0 records

