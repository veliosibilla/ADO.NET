select distinct A.Country   
from Address A
inner join Supplier S on (A.AddressID=S.AddressID)
