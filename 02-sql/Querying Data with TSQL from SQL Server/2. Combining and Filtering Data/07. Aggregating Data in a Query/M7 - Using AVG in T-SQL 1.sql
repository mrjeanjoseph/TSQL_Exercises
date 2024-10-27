USE Northwind

--SELECT * FROM Numbers ORDER BY Number

--SELECT SUM(Number) AS TotalOfFieldValues FROM Numbers --48
--SELECT COUNT(*) AS RecordCount FROM Numbers --10
--SELECT AVG(Number) FROM Numbers --4, returns ROUNDED value by default 48/10 should be 4.8
--SELECT AVG(CAST(Number AS DECIMAL(5,2))) AS Average from Numbers --as decimal 4.8


--SELECT SUM(DISTINCT Number) FROM Numbers
--SELECT COUNT(DISTINCT Number) FROM Numbers
--SELECT SUM(DISTINCT Number)/COUNT(DISTINCT Number) FROM Numbers
--SELECT AVG(DISTINCT Number) FROM Numbers
