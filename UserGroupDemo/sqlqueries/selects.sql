/****** Script for SelectTopNRows command from SSMS  ******/
as32
SELECT TOP (1000) [AddressID]
      ,[AddressLine1]
      ,[AddressLine2]
      ,[City]
      ,[StateProvinceID]
      ,[PostalCode]
      ,[SpatialLocation]
      ,[rowguid]
      ,[ModifiedDate]
      ,[lat]
      ,[lng]
  FROM [AdventureWorks2016CTP3].[Person].[Address]

  update person.Addressbackup2 set AddressLine1 = '120' where AddressID = 1

  update person.Addressbackup2 set addressline1 = b.addressline1
  from person.addressbackup2 b where addressid = b.addressid and addressid < 5000

  update person.addressbackup2 set lat = null, lng = null where addressid < 50

  --select * into person.addressbackup2 from person.Address
  select top 1000 * from person.addressbackup2 order by AddressID 
  update person.addressbackup2 set lat = null, lng = null where AddressID < 1000

   ALTER TABLE [Person].[addressbackup2] enable trigger [trAddresses1] 



