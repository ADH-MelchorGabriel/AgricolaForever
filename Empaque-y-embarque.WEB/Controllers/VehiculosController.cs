using EYE.Entidades;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class VehiculosController : Controller
    {
        private readonly EyeContext _context;
        public VehiculosController(EyeContext context)
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

            var obj = await _context.Vehiculos
                                    .Include(x=> x.LineaTransporte)
                                    .Select(x => new { x.IdVehiculo, x.Descripcion,x.Año,x.Placas,x.IdLineaTransporte, lineaTransporte = x.LineaTransporte.Nombre, x.EstaActivo,x.Apodo })
                                    .OrderBy(x => x.IdVehiculo)
                                    .ToListAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> Buscar([FromQuery] int id)
        {

            var obj = await _context.Vehiculos
                                    .Include(x => x.LineaTransporte)
                                    .Where(x => x.IdVehiculo == id)
                                    .Select(x => new { x.IdVehiculo, x.Descripcion, x.Año, x.Placas, x.IdLineaTransporte, lineaTransporte = x.LineaTransporte.Nombre, x.EstaActivo, x.Apodo })
                                    .OrderBy(x => x.IdVehiculo)
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] VehiculoEntity obj)
        {

            try
            {
                if (obj.IdVehiculo == 0) await _context.Vehiculos.AddAsync(obj);
                else _context.Vehiculos.Update(obj);

                await _context.SaveChangesAsync();
                return new JsonResult(obj);
            }
            catch (System.Exception)
            {
                return new JsonResult(null);

            }
        }

        [HttpGet]
        public async Task<JsonResult> CambiarEstado([FromQuery] int id)
        {
            var obj = await _context.Vehiculos.Where(x => x.IdVehiculo == id).FirstOrDefaultAsync();
            obj.EstaActivo = !obj.EstaActivo;
            _context.Vehiculos.Update(obj);
            await _context.SaveChangesAsync();
            return new JsonResult(obj);
        }
        public async Task<JsonResult> GetLineaTransporte()
        {
            var articulo = await _context.LineaTransportes.Where(x => x.EstaActivo == true).Select(x => new { x.IdLineaTransporte, x.Nombre }).ToListAsync();

            return new JsonResult(articulo);
        }
    }

}
