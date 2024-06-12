using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class ReportesController : Controller
    {

        private readonly EyeContext _contexto;

        public ReportesController(EyeContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Inventario()
        {
            return View();
        }

        public IActionResult ReporteProductosEmbarcados()
        {
            return View();
        }

        public IActionResult ReporteOrdenEnvio()
        {
            return View();
        }

        public IActionResult ReporteProductosAgricultor()
        {
            return View();
        }



        [HttpGet]
        public async Task<JsonResult> GetEnvios([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFinal, [FromQuery] int idAgricultor)
        {

            var resultado = await _contexto.EnviosRpt
                                           .Where(x => x.FechaEnvio.Date >= fechaInicio.Date && x.FechaEnvio.Date <= fechaFinal.Date)
                                           .Select(x => new
                                           {
                                               x.Manifiesto,
                                               x.IdAgricultor,
                                               x.Agricultor,
                                               x.Destino,
                                               FechaEnvio = x.FechaEnvio.ToString("dd/MM/yyyy"),
                                               x.Producto,
                                               x.Cantidad,
                                               x.Precio,
                                               x.Importe
                                           })
                                           .ToListAsync();


            if (idAgricultor != 0)
                resultado = resultado.Where(x => x.IdAgricultor == idAgricultor).ToList();


            return new JsonResult(resultado);
        }



        [HttpGet]
        public async Task<JsonResult> GetInventario()
        {

            var resultado = await _contexto.Palet
                                           .Include(x=> x.PaletDetalle) 
                                           .ThenInclude(x=> x.Agricultor)
                                           .Include(x => x.PaletDetalle)
                                           .ThenInclude(x=> x.Producto)
                                           .Where(x=> x.EstadoPalet==EYE.Enumeradores.EstadoPaletEnum.Empacado)
                                           .Select(x => new
                                           {
                                               Fecha=x.Fecha.ToString("dd/MM/yyyy"),
                                               x.Folio,
                                               Agricultor = x.PaletDetalle[0].Agricultor.Nombre,
                                               Producto = x.PaletDetalle[0].Producto.Nombre,
                                               Cajas=x.PaletDetalle[0].Cantidad
                                           })
                                           .ToListAsync();


            return new JsonResult(resultado);
        }



        [HttpGet]
        public async Task<JsonResult> GetGuias([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFinal)
        {

            var resultado = await _contexto.GuiasRpt.Where(x => x.Fecha.Date >= fechaInicio.Date && x.Fecha.Date <= fechaFinal.Date)
                                                     .Select(x => new
                                                     {
                                                         Fecha = x.Fecha.ToString("dd/MM/yyyy"),
                                                         x.Guia,
                                                         x.Producto,
                                                         x.Cajas,
                                                         x.PesoCaja,
                                                         PesoTotal = Math.Round(x.PesoTotal, 2)
                                                     })
                                                    .ToListAsync();



            return new JsonResult(resultado);
        }

        //[HttpGet]
        //public async Task<JsonResult> GetProductoAgricutor([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFinal, [FromQuery] int idAgricultor)
        //{

        //}



        [HttpGet]
        public async Task<JsonResult> GetAgricultor()
        {
            var lista = await _contexto.Agricultores.Where(x => x.EstaActivo == true).Select(x => new { x.IdAgricultor, x.Nombre, }).ToListAsync();

            return new JsonResult(lista);
        }
    }
}
