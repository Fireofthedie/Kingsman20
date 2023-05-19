create or alter view Report
as
select (LastName + ' ' + Left(FirstName,1) + '. ' + left(Patronymic,1) +'.') AS 'FLP', s.Title, (os.Quantity*s.Cost) as 'Sum', o.[DateTime], sum(os.Quantity) as 'TotalQuantity',sum(os.Quantity*s.Cost) as 'TotalSum'
from Emploers e 
join [Order] o ON e.ID = o.EmploersID 
join OrderService os on o.ID = os.OrderID
join [Service] s on s.ID = os.ServiceID
group by (LastName + ' ' + Left(FirstName,1) + '. ' + left(Patronymic,1) +'.'), Title, Quantity, Cost, DateTime