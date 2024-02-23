using EYE.Dtos;
using EYE.Entidades;
using EYE.Enumeradores;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class PaletController : Controller
    {
        private readonly EyeContext _context;
        public PaletController(EyeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Nuevo()
        {
            return View();
        }
        public async Task<JsonResult> Listar()
        {

            try
            {
                var obj = await _context.Palet
                                   .Where(x => x.EstaActivo == true && x.EstadoPalet == EstadoPaletEnum.Empacado)
                                   .Include(x => x.PaletDetalle)
                                   .ThenInclude(x => x.Agricultor)
                                   .Include(x => x.PaletDetalle)
                                   .ThenInclude(x => x.Producto)
                                   .Select(x => new { x.IdPalet, x.Folio, x.IdTemporada, TipoPalet = x.TipoPalet.ToString(), Fecha = x.Fecha.ToString("yyyy-MM-dd"), Detalle = x.PaletDetalle.Select(x => new { Agricultor = x.Agricultor.Nombre, Producto = x.Producto.Nombre, x.Cantidad }) })
                                   .OrderBy(x => x.IdPalet)
                                   .ToListAsync();

                return new JsonResult(obj);
            }
            catch (Exception ex)
            {
                var c = ex.Message;
                return new JsonResult(null);
            }


        }
        [HttpGet]
        public async Task<JsonResult> BuscarPaletCompleto([FromQuery] int id)
        {

            var obj = await _context.Palet
                                    .Include(x => x.PaletDetalle)
                                    .Where(x => x.IdPalet == id)
                                    .Select(x => new { x.IdPalet, x.Folio, x.IdEmpaque, x.PaletDetalle.FirstOrDefault().IdPaletDetalle, x.IdTemporada, x.EsGaseado, x.EsPaletChep, x.PaletDetalle.FirstOrDefault().IdAgricultor, x.PaletDetalle.FirstOrDefault().IdLote, x.PaletDetalle.FirstOrDefault().IdProducto, x.PaletDetalle.FirstOrDefault().Cantidad })
                                    .OrderBy(x => x.IdPalet)
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> BorrarPallet([FromQuery] int id)
        {

            try
            {
                var borrar = await _context.Palet.Where(x => x.IdPalet == id).FirstOrDefaultAsync();

                var borrarDetalle = await _context.PaletDetalle.Where(x => x.IdPalet == id).ToListAsync();

                _context.PaletDetalle.RemoveRange(borrarDetalle);
                _context.Palet.Remove(borrar);
                await _context.SaveChangesAsync();

                return new JsonResult(new { borrar.IdPalet });
            }
            catch (Exception ex)
            {

                var a = ex.Message;
                return new JsonResult(null);
            }
           

        }
        [HttpPost]
        public async Task<JsonResult> GuardarPaletCompleto([FromBody] PaletCompletoDto newObj)
        {
            try
            {
                _context.Database.BeginTransaction();

                var temporada = await _context.Temporadas.Where(x => x.FechaFinal.Date >= DateTime.Now && x.FechaInicio.Date <= DateTime.Now).FirstOrDefaultAsync();
                PaletEntity palet = new PaletEntity(newObj);

                if (newObj.IdPaletDetalle == 0)
                {



                    palet.IdTemporada = temporada.IdTemporada;
                    await _context.Palet.AddAsync(palet);
                    await _context.SaveChangesAsync();

                    var detalle = new PaletDetalleEntity
                    {
                        IdPaletDetalle = 0,
                        IdPalet = palet.IdPalet,
                        IdAgricultor = newObj.IdAgricultor,
                        IdLote = newObj.IdLote,
                        IdProducto = newObj.IdProducto,
                        Cantidad = newObj.Cantidad,
                        EstaAcivo = true
                    };




                    var x = await _context.PaletDetalle.AddAsync(detalle);
                    await _context.SaveChangesAsync();




                    palet.Folio = await GenerarFolio(palet.IdPalet);

                    _context.Palet.Update(palet);
                    await _context.SaveChangesAsync();
                }
                else
                {



                    palet.IdTemporada = temporada.IdTemporada;
                    _context.Palet.Update(palet);
                    await _context.SaveChangesAsync();

                    var detalle = new PaletDetalleEntity
                    {
                        IdPaletDetalle = palet.IdPalet,
                        IdPalet = palet.IdPalet,
                        IdAgricultor = newObj.IdAgricultor,
                        IdLote = newObj.IdLote,
                        IdProducto = newObj.IdProducto,
                        Cantidad = newObj.Cantidad,
                        EstaAcivo = true
                    };




                    var x = await _context.PaletDetalle.AddAsync(detalle);
                    await _context.SaveChangesAsync();




                    palet.Folio = await GenerarFolio(palet.IdPalet);

                    _context.Palet.Update(palet);
                    await _context.SaveChangesAsync();
                }

                _context.Database.CommitTransaction();

                return new JsonResult(new { palet.IdPalet });

            }
            catch (System.Exception)
            {
                _context.Database.RollbackTransaction();
                return new JsonResult(null);
            }
        }


        private async Task<string> GenerarFolio(int idPalet)
        {
            var folio = "";

            var palet = await _context.Palet
                                      .Include(x => x.PaletDetalle)
                                      .ThenInclude(x => x.Agricultor)
                                      .Include(x => x.PaletDetalle)
                                      .ThenInclude(x => x.Producto)
                                      .Where(x => x.IdPalet == idPalet)
                                      .FirstOrDefaultAsync();

            if (palet.TipoPalet == TipoPaletEnum.Normal)
            {
                folio = palet.IdTemporada.ToString() + (int)palet.TipoPalet + palet.Fecha.ToString("ddMMyyy") + palet.PaletDetalle[0].Agricultor.Codigo + palet.PaletDetalle[0].Producto.Codigo + '-' + palet.IdPalet.ToString();
            }
            else
            {
                folio = "";
            }


            return folio;
        }
        [HttpGet]
        public async Task<JsonResult> BuscarProducto(int id)
        {
            var obj = await _context.Productos.Where(x => x.EstaActivo == true && x.IdProducto == id).Select(x => new { x.IdProducto, x.Nombre, x.Cantidad }).FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> GetAgricultor()
        {
            var lista = await _context.Agricultores.Where(x => x.EstaActivo == true).Select(x => new { x.IdAgricultor, x.Nombre, }).ToListAsync();

            return new JsonResult(lista);
        }
        [HttpGet]
        public async Task<JsonResult> GetTemporada()
        {
            var lista = await _context.Temporadas.Where(x => x.EstaActivo == true).Select(x => new { x.IdTemporada, x.Descripcion }).ToListAsync();

            return new JsonResult(lista);
        }
        [HttpGet]
        public async Task<JsonResult> GetLote()
        {
            var lista = await _context.Lotes.Where(x => x.EstaActivo == true).Select(x => new { x.IdLote, x.Nombre, }).ToListAsync();

            return new JsonResult(lista.OrderBy(x => x.Nombre).ToList());
        }
        [HttpGet]
        public async Task<JsonResult> GetProducto()
        {
            var lista = await _context.Productos.Where(x => x.EstaActivo == true).Select(x => new { x.IdProducto, x.Nombre, }).ToListAsync();

            return new JsonResult(lista.OrderBy(x => x.Nombre).ToList());
        }
        [HttpGet]
        public async Task<JsonResult> GetEmpaques()
        {
            var lista = await _context.Empaques.Where(x => x.EstaActivo == true).Select(x => new { x.IdEmpaque, x.Nombre, }).ToListAsync();

            return new JsonResult(lista.OrderBy(x => x.Nombre).ToList());
        }
        [HttpGet]
        public async Task<JsonResult> PaletImprimir([FromQuery] int id)
        {

            var obj = await _context.Palet
                                    .Include(x => x.PaletDetalle)
                                    .ThenInclude(x => x.Producto)
                                     .Include(x => x.PaletDetalle)
                                    .ThenInclude(x => x.Agricultor)
                                    .Where(x => x.IdPalet == id)
                                    .Select(x => new
                                    {
                                        x.IdPalet,
                                        x.Folio,
                                        Producto = x.PaletDetalle.FirstOrDefault().Producto.Nombre,
                                        Agricultor = x.PaletDetalle.FirstOrDefault().Agricultor.Nombre,
                                        x.PaletDetalle.FirstOrDefault().Cantidad
                                    })
                                    .OrderBy(x => x.IdPalet)
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
    }
}
