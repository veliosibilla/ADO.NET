select A.Country, S.SupplierID, count(ProductID)
from Product P
inner join Supplier S on (P.SupplierID=S.SupplierID)
inner join Address A on (A.AddressID=S.AddressID)
group by A.Country, S.SupplierID