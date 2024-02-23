using EYE.Entidades;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class LineaTransporteController : Controller
    {
        private readonly EyeContext _context;
        public LineaTransporteController(EyeContext context)
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

            var obj = await _context.LineaTransportes
                                    .Select(x => new { x.IdLineaTransporte, x.Nombre,x.Telefono, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .ToListAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> Buscar([FromQuery] int id)
        {

            var obj = await _context.LineaTransportes
                                    .Where(x => x.IdLineaTransporte == id)
                                    .Select(x => new { x.IdLineaTransporte, x.Nombre, x.Telefono, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] LineaTransporteEntity obj)
        {

            try
            {
                if (obj.IdLineaTransporte == 0) await _context.LineaTransportes.AddAsync(obj);
                else _context.LineaTransportes.Update(obj);

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
            var obj = await _context.LineaTransportes.Where(x => x.IdLineaTransporte == id).FirstOrDefaultAsync();
            obj.EstaActivo = !obj.EstaActivo;
            _context.LineaTransportes.Update(obj);
            await _context.SaveChangesAsync();
            return new JsonResult(obj);
        }
    }


}
