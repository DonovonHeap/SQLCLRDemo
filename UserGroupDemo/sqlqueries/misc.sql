ALTER DATABASE AdventureWorks2016CTP3 SET TRUSTWORTHY ON;

CREATE ASSEMBLY UserGroupLib   
FROM 'C:\temp\UserGroupLib.dll'  
WITH PERMISSION_SET = Safe;



sp_configure 'clr enabled', 1  
GO  
RECONFIGURE  
GO 

ALTER ASSEMBLY usergroupdemo WITH permission_set = External_ACCESS

SELECT *
FROM sys.assemblies AS a
INNER JOIN sys.assembly_files AS f
ON a.assembly_id = f.assembly_id
WHERE a.is_user_defined = 1;

select * from sys.dm_clr_properties

select latlng = dbo.GetLatLong('123' +'+'+ '84601')
