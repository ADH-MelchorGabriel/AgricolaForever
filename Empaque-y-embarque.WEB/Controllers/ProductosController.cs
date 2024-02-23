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

    public class ProductosController : Controller
    {
        private readonly EyeContext _context;
        public ProductosController(EyeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> Listar()
        {

            var obj = await _context.Productos
                                    .Include(x =>x.Cultivo)
                                    .Include(x => x.Envase)
                                    .Include(x => x.Tamaño)
									.Select(x => new { x.IdProducto, x.IdEnvase, envase = x.Envase.Nombre, x.IdCultivo, cultivo = x.Cultivo.Nombre, x.IdTamaño, tamaño = x.Tamaño.Nombre, x.Nombre, x.PesoKg, x.CveFraccionArancelaria, x.CveProductoServicio, x.CveUnidadMedida, x.Cantidad, x.Codigo, calidad = x.Calidad.ToString(), x.FolioGuia, x.EstaActivo })
									.OrderBy(x => x.Nombre)
                                    .ToListAsync();

            return new JsonResult(obj);
        }
   
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] ProductoEntity obj)
        {

            try
            {
                if (obj.IdProducto == 0) await _context.Productos.AddAsync(obj);
                else _context.Productos.Update(obj);

                await _context.SaveChangesAsync();
                return new JsonResult(obj);
            }
            catch (System.Exception)
            {
                return new JsonResult(null);

            }
        }
        public async Task<JsonResult> Buscar([FromQuery] int id)
        {

            var obj = await _context.Productos                                   
                                    .Where(x => x.IdProducto == id)
                                    .Select(x => new { x.IdProducto, x.IdEnvase, x.IdCultivo, x.IdTamaño, x.Nombre, x.PesoKg,x.Libras, x.CveFraccionArancelaria, x.CveProductoServicio, x.CveUnidadMedida, x.Cantidad, x.Codigo,calidad=x.Calidad, x.FolioGuia, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> CambiarEstado([FromQuery] int id)
        {
            var obj = await _context.Productos.Where(x => x.IdProducto == id).FirstOrDefaultAsync();
            obj.EstaActivo = !obj.EstaActivo;
            _context.Productos.Update(obj);
            await _context.SaveChangesAsync();
            return new JsonResult(obj);
        }


        public async Task<JsonResult> GetEnvase()
        {
            var lista = await _context.Envases.Where(x => x.EstaActivo == true).Select(x => new { x.IdEnvase, x.Nombre }).ToListAsync();

            return new JsonResult(lista.OrderBy(x=>x.Nombre).ToList());
        }
        public async Task<JsonResult> GetTamaño()
        {
            var lista = await _context.Tamaño.Where(x => x.EstaActivo == true).Select(x => new { x.IdTamaño, x.Nombre }).ToListAsync();

            return new JsonResult(lista);
        }
        public async Task<JsonResult> GetCultivo()
        {
            var lista = await _context.Cultivos.Where(x => x.EstaActivo == true).Select(x => new { x.IdCultivo, x.Nombre }).ToListAsync();

            return new JsonResult(lista.OrderBy(x=> x.Nombre).ToList());
        }
        public async Task<JsonResult> GetFamiliaCultivo()
        {
            var lista = await _context.FamiliaCultivos.Where(x => x.EstaActivo == true).Select(x => new { x.IdFamiliaCultivo, x.Nombre, }).ToListAsync();

            return new JsonResult(lista);
        }
	
		public JsonResult GetCalidad()
        {
            var lista = Enum.GetValues(typeof(CalidadEnum))
                   .Cast<CalidadEnum>()
                   .Select(d => new { display = d.ToString(), value = (int)d })
                   .ToList();
            return new JsonResult(lista);
        }

    }
}
