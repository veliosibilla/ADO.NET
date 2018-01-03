select P.CategoryId, P.ProductId, P.Name, P.UnitPrice, P.UnitsInStock
from Product P
inner join Category C on (C.CategoryId=P.CategoryId)
where C.CategoryId='E71DB81C-D2B8-42F0-8F2C-1A901BDE824F'
order by P.ProductId