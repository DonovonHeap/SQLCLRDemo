-- Intro, which one is SQL, which one is C# 
set statistics time on
  select top 100 c.CustomerID, 
  AccountNumber = (isnull('AW'+[dbo].[ufnLeadingZeros]([CustomerID]),''))
   from sales.Customer c

   select top 100 c.CustomerID, 
  Accountnumber = (isnull('AW'+[dbo].[ufnLeadingZerosUser]([CustomerID]),''))
   from sales.Customer c











   select test = [dbo].[ufnRegEx]('make massive maize into zero bread for me', '\bm\S*e\b');

   select test = [dbo].[ufnRegEx2]('The the quick brown fox  fox jumps over the lazy dog dog.','\b(?<word>\w+)\s+(\k<word>)\b');

   select 
   c.BusinessEntityID, 
   c.FirstName, 
   c.LastName, 
   c.EmailAddress,
   validEmail = [dbo].[ufnValidateEmail](c.EmailAddress)  
   from [Sales].[vIndividualCustomer] c 
   where dbo.ufnValidateEmail(c.emailaddress) = 1
   order by validEmail

   exec dbo.spgetcustomer @name = 'robert'');drop table person.person--'