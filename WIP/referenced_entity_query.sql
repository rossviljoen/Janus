USE LocalTest
GO

DECLARE @sp_name varchar(50) = 'dbo.update_test_table_2'
SELECT DISTINCT
referenced_entity_name
FROM sys.dm_sql_referenced_entities(@sp_name, 'OBJECT')
WHERE CHARINDEX(referenced_entity_name , @sp_name) = 0