using EYE.Entidades;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class RemolqueController : Controller
    {
        private readonly EyeContext _context;
        public RemolqueController(EyeContext context)
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

            var obj = await _context.Remolques
                                    .Include(x=> x.LineaTransportes)
                                    .Select(x => new { x.IdRemolque,lineaTransporte=x.LineaTransportes.Nombre, x.IdLineaTransporte,x.Descripcion,x.Año,x.Placas, x.EstaActivo })
                                    .OrderBy(x => x.IdRemolque)
                                    .ToListAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> Buscar([FromQuery] int id)
        {

            var obj = await _context.Remolques
                                    .Where(x => x.IdRemolque == id)
                                    .Select(x => new { x.IdRemolque, lineaTransporte = x.LineaTransportes.Nombre,x.IdLineaTransporte, x.Descripcion, x.Año, x.Placas, x.EstaActivo })
                                    .OrderBy(x => x.IdRemolque)
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] RemolqueEntity obj)
        {

            try
            {
                if (obj.IdRemolque == 0) await _context.Remolques.AddAsync(obj);
                else _context.Remolques.Update(obj);

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
            var obj = await _context.Remolques.Where(x => x.IdRemolque == id).FirstOrDefaultAsync();
            obj.EstaActivo = !obj.EstaActivo;
            _context.Remolques.Update(obj);
            await _context.SaveChangesAsync();
            return new JsonResult(obj);
        }
        public async Task<JsonResult> GetLinea()
        {
            var articulo = await _context.LineaTransportes.Where(x => x.EstaActivo == true).Select(x => new { x.IdLineaTransporte, x.Nombre }).ToListAsync();

            return new JsonResult(articulo);
        }

    }
}
