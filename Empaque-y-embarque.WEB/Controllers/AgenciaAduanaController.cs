using EYE.Entidades;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class AgenciaAduanaController : Controller
    {

        private readonly EyeContext _context;
        public AgenciaAduanaController(EyeContext context)
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

            var obj = await _context.AgenciaAduanas
                                    .Select(x => new { x.IdAgenciaAduana, x.Nombre, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .ToListAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> Buscar([FromQuery] int id)
        {

            var obj = await _context.AgenciaAduanas
                                    .Where(x => x.IdAgenciaAduana == id)
                                    .Select(x => new { x.IdAgenciaAduana, x.Nombre, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] AgenciaAduanaEntity obj)
        {

            try
            {
                if (obj.IdAgenciaAduana == 0) await _context.AgenciaAduanas.AddAsync(obj);
                else _context.AgenciaAduanas.Update(obj);

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
            var obj = await _context.AgenciaAduanas.Where(x => x.IdAgenciaAduana == id).FirstOrDefaultAsync();
            obj.EstaActivo = !obj.EstaActivo;
            _context.AgenciaAduanas.Update(obj);
            await _context.SaveChangesAsync();
            return new JsonResult(obj);
        }
    }
}
