select Country from Address

select C.CategoryId, P.ProductID, P.Name, C.Name  
from Category C
inner join Product P on (P.CategoryId=C.CategoryId)
order by C.Name

select * from Category

select * from Supplier