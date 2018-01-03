select A.Country, S.CompanyName, S.SupplierID
from Supplier S
inner join Address A on (A.AddressID=S.AddressID)
where A.Country= 'Canada'
order by A.Country, S.CompanyName, S.SupplierID