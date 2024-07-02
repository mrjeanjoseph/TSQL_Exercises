USE [BonRepos];
GO


-- Please do not run this in production
DBCC FREEPROCCACHE;
GO


-- Using sp_executesql
DECLARE @SqlCmd AS nvarchar(1000);
DECLARE @SalesPersonEmailInput AS nvarchar(500);
SET @SalesPersonEmailInput = 'CalKienl@bonrepos.ht';

SET @SqlCmd = N'SELECT sp.LastName,
					   sp.FirstName,
					   sp.StartDate,
					   spl.LevelName
				FROM Sales.SalesPerson sp
				INNER JOIN Sales.SalesPersonLevel spl ON spl.Id = sp.LevelId
				WHERE Email = @SalesPersonEmail';

EXECUTE dbo.sp_executesql @SqlCmd, N'@SalesPersonEmail nvarchar(500)',
						  @SalesPersonEmail = @SalesPersonEmailInput;
GO


-- Different email
DECLARE @SqlCmd AS nvarchar(1000);
DECLARE @SalesPersonEmailInput AS nvarchar(500);
SET @SalesPersonEmailInput = 'ShandiePoetz@bonrepos.ht';

SET @SqlCmd = N'SELECT sp.LastName,
					   sp.FirstName,
					   sp.StartDate,
					   spl.LevelName
				FROM Sales.SalesPerson sp
				INNER JOIN Sales.SalesPersonLevel spl ON spl.Id = sp.LevelId
				WHERE Email = @SalesPersonEmail';

EXECUTE dbo.sp_executesql @SqlCmd, N'@SalesPersonEmail nvarchar(500)',
						  @SalesPersonEmail = @SalesPersonEmailInput;
GO


-- Let’s check our cache
SELECT cp.usecounts 'Execution Counts'
	   ,cp.size_in_bytes 'Size in Bytes'
	   ,cp.objtype 'Type'
	   ,st.text 'SQL Text'
 FROM [sys].[dm_exec_cached_plans] cp
CROSS APPLY [sys].[dm_exec_sql_text](cp.plan_handle) st
WHERE st.text like '%Sales.SalesPersonLevel%';
GO



-- Using exec
DECLARE @SqlCmd AS nvarchar(1000);
DECLARE @SalesPersonEmail AS nvarchar(500);
SET @SalesPersonEmail = 'denzelpaniague@bonrepos.ht';

SET @SqlCmd = N'SELECT sp.LastName,
					   sp.FirstName,
					   sp.StartDate,
					   spl.LevelName
				FROM Sales.SalesPerson sp
				INNER JOIN Sales.SalesPersonLevel spl ON spl.Id = sp.LevelId
				WHERE Email = '''+@SalesPersonEmail+'''';

EXECUTE (@SqlCmd);
GO



-- Different Email
DECLARE @SqlCmd AS nvarchar(1000);
DECLARE @SalesPersonEmail AS nvarchar(500);
SET @SalesPersonEmail = 'calvinjouthe@bonrepos.ht';

SET @SqlCmd = N'SELECT sp.LastName,
					   sp.FirstName,
					   sp.StartDate,
					   spl.LevelName
				FROM Sales.SalesPerson sp
				INNER JOIN Sales.SalesPersonLevel spl ON spl.Id = sp.LevelId
				WHERE Email = '''+@SalesPersonEmail+'''';

EXECUTE (@SqlCmd);
GO



-- Let’s check our cache
SELECT cp.usecounts 'Execution Counts'
	   ,cp.size_in_bytes 'Size in Bytes'
	   ,cp.objtype 'Type'
	   ,st.text 'SQL Text'
 FROM [sys].[dm_exec_cached_plans] cp
CROSS APPLY [sys].[dm_exec_sql_text](cp.plan_handle) st
WHERE st.text like '%Sales.SalesPersonLevel%';
GO



-- Microsoft article on sql injection
-- https://docs.microsoft.com/en-us/sql/relational-databases/security/sql-injection?view=sql-server-2017

-- Pluralsight course | Ethical Hacking: SQL Injection by Troy Hunt