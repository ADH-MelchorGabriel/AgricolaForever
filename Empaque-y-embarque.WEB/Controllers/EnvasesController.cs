using EYE.Entidades;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class EnvasesController : Controller
    {

        private readonly EyeContext _context;
        public EnvasesController(EyeContext context)
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

            var obj = await _context.Envases
                                    .Select(x => new { x.IdEnvase, x.Nombre, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .ToListAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> Buscar([FromQuery] int id)
        {

            var obj = await _context.Envases
                                    .Where(x => x.IdEnvase == id)
                                    .Select(x => new { x.IdEnvase, x.Nombre, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] EnvaseEntity obj)
        {

            try
            {
                if (obj.IdEnvase == 0) await _context.Envases.AddAsync(obj);
                else _context.Envases.Update(obj);

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
            var obj = await _context.Envases.Where(x => x.IdEnvase == id).FirstOrDefaultAsync();
            obj.EstaActivo = !obj.EstaActivo;
            _context.Envases.Update(obj);
            await _context.SaveChangesAsync();
            return new JsonResult(obj);
        }
    }
}
