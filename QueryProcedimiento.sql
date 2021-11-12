use Northwind
go

-------------------------------------------
-- Procedimiento
alter procedure ProcEmpleadosRec @Anio int
as
DECLARE @Total float
SET @Total = (
Select ROUND(sum(od.UnitPrice * od.Quantity * (1 - od.Discount)), 2)
from [Order Details] od
inner join Orders o
on o.OrderID = od.OrderID
where year(o.OrderDate) = @Anio
)
Select a.IDEmpleado, 
a.NombreEmpleado as [Nombre del empleado],
count(distinct a.OrderID) as [Cantidad de Ordenes],
(Select count(distinct b.OrderID) from (
Select distinct e.EmployeeID, 
o.OrderID, 
od.Discount,
o.OrderDate
From Employees e
inner join Orders o
on o.EmployeeID = e.EmployeeID
inner join [Order Details] od
on od.OrderID = o.OrderID
) b
where b.EmployeeID = a.IDEmpleado AND b.Discount > 0.0 and YEAR(b.OrderDate) = @Anio) as [Cantidad Ordenes con Descuento],
CAST((ROUND(sum(a.Recaudacion)/@Total, 4) * 100) as varchar(10)) + '%' as Porcentaje
from (
Select e.EmployeeID as IDEmpleado, e.FirstName + ' ' + e.LastName as NombreEmpleado, 
o.OrderID, 
od.Discount, 
od.UnitPrice * od.Quantity * (1 - od.Discount) as Recaudacion,
o.OrderDate
From Employees e
inner join Orders o
on o.EmployeeID = e.EmployeeID
inner join [Order Details] od
on od.OrderID = o.OrderID
) a
where year(a.OrderDate) = @Anio
group by a.IDEmpleado, a.NombreEmpleado
go

exec dbo.ProcEmpleadosRec 1997
go