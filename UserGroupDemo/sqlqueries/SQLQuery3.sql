SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [Person].[trAddresses1] ON [Person].[Addressbackup2]
   AFTER INSERT,UPDATE,DELETE
AS 
	SET NOCOUNT ON;

	UPDATE a SET 
		 lat	= g.lat
		,lng	= g.lng
	from Person.Addressbackup2 a 
	    join inserted i on i.AddressID = a.AddressID
	    left join deleted d on d.AddressID = a.AddressID
	    cross apply ( select lat, lng from dbo.tfnGeoCoordinates(a.AddressLine1, a.PostalCode) g where g.lat <> 0 ) g
	--WHERE a.lat = 0 OR a.AddressLine1 <> d.AddressLine1 OR a.PostalCode <> d.PostalCode


	


