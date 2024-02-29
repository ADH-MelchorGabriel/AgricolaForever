--vista creada para el detalle de la carta responsiva
create view EmbarqueDetalleAgrupadoView
as
select 
e.IdEmbarque,
pr.Nombre as Producto,
sum(pd.Cantidad) as cantidad
from EmbarqueDetalle e
inner join Palet p on e.IdPalet=p.IdPalet
inner join PaletDetalle pd on p.IdPalet=pd.IdPalet
inner join Productos pr on pd.IdProducto=pr.IdProducto
group by 
e.IdEmbarque,
pr.Nombre 
go

create View EmbarqueDetalleFacturacionView
as
select 
ed.IdEmbarque,
RIGHT('00000000' + LTRIM(RTRIM(CONVERT(varchar, p.IdCultivo) + CONVERT(varchar,p.IdTamaño) + CONVERT(varchar, p.IdEnvase))), 8) AS CodigoProducto,
c.Nombre+' '+t.Nombre+' '+e.Nombre as Producto,
p.CveFraccionArancelaria,
p.CveUnidadMedida,
p.CveProductoServicio,
sum(pd.Cantidad) as Cantidad,
ed.Precio,
round(sum(pd.Cantidad*ed.Precio),2) as Importe,
round(sum(pd.Cantidad*p.PesoKg),3) as Kilogramos

from 
EmbarqueDetalle ed
inner join PaletDetalle pd on ed.IdPalet=pd.IdPalet
inner join Productos p on pd.IdProducto=p.IdProducto	
inner join Cultivo c on p.IdCultivo=c.IdCultivo
inner join Tamaño t on p.IdTamaño=t.IdTamaño
inner join Envase e on p.IdEnvase=e.IdEnvase
group by
ed.idEmbarque,
p.IdCultivo,
p.IdTamaño,
p.IdEnvase,
c.Nombre,
t.Nombre,
e.Nombre,
p.CveFraccionArancelaria,
p.CveUnidadMedida,
p.CveProductoServicio,
ed.Precio

go

create view EmbarqueDetalleGuiaView
as
select 
ed.IdEmbarque,
FolioGuia,
c.Nombre+ ' ' +e.Nombre as Producto,
sum(pd.Cantidad) as Cantidad,
sum(pd.Cantidad*p.PesoKg)/1000 as Toneladas
from EmbarqueDetalle ed
inner join PaletDetalle pd on ed.IdPalet=pd.IdPalet
inner join Productos p on pd.IdProducto=p.IdProducto
inner join Cultivo c on p.IdCultivo=c.IdCultivo
inner join Envase e on p.IdEnvase=e.IdEnvase
group by
ed.IdEmbarque,
FolioGuia,
c.Nombre,
e.Nombre

 

 go
 alter view EmbarqueDetalleManifiestoView
 as
select 
e.IdEmbarque,
c.Nombre as Producto,
t.Nombre as Tamaño,
ev.Nombre as Envase,
pr.Calidad,
sum(pd.Cantidad) as cantidad,
round(sum(pd.Cantidad*pr.PesoKg),2) as Kilos
from EmbarqueDetalle e
inner join PaletDetalle pd on e.IdPalet=pd.IdPalet
inner join Productos pr on pd.IdProducto=pr.IdProducto
inner join Cultivo c on pr.IdCultivo=c.IdCultivo
inner join Tamaño t on pr.IdTamaño=t.IdTamaño
inner join Envase ev on pr.IdEnvase=ev.IdEnvase
group by 
e.IdEmbarque
,c.Nombre 
,t.Nombre
,ev.Nombre
,pr.Calidad




SELECT        ed.IdEmbarque, ed.Posicion, p.Nombre AS Producto, a.Codigo AS Agricultor,t.Nombre as Tamaño, pd.Cantidad, ROUND(pd.Cantidad * p.PesoKg, 2) AS Kilogramos, ROUND(pd.Cantidad * p.Libras, 2) AS Libras
FROM            dbo.EmbarqueDetalle AS ed INNER JOIN
                         dbo.PaletDetalle AS pd ON ed.IdPalet = pd.IdPalet INNER JOIN
                         dbo.Agricultor AS a ON pd.IdAgricultor = a.IdAgricultor INNER JOIN
                         dbo.Productos AS p ON pd.IdProducto = p.IdProducto
						 inner join Tamaño t on p.IdTamaño=t.IdTamaño