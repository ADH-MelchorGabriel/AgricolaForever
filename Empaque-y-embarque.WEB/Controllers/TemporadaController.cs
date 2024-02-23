using EYE.Entidades;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class TemporadaController : Controller
    {
        private readonly EyeContext _context;
        public TemporadaController(EyeContext context)
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

            var obj = await _context.Temporadas
                                    .Select(x => new { x.IdTemporada, x.Descripcion,FechaInicio=x.FechaInicio.ToShortDateString(),FechaFinal= x.FechaFinal.ToShortDateString(), x.EstaActivo })
                                    .OrderBy(x => x.IdTemporada)
                                    .ToListAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> Buscar([FromQuery] int id)
        {

            var obj = await _context.Temporadas
                                    .Where(x => x.IdTemporada == id)
                                    .Select(x => new { x.IdTemporada, x.Descripcion,FechaInicio= x.FechaInicio.ToString("yyyy-MM-dd"),FechaFinal= x.FechaFinal.ToString("yyyy-MM-dd"), x.EstaActivo })
                                    .OrderBy(x => x.IdTemporada)
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] TemporadaEntity obj)
        {

            try
            {
                if (obj.IdTemporada == 0) await _context.Temporadas.AddAsync(obj);
                else _context.Temporadas.Update(obj);

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
            var obj = await _context.Temporadas.Where(x => x.IdTemporada == id).FirstOrDefaultAsync();
            obj.EstaActivo = !obj.EstaActivo;
            _context.Temporadas.Update(obj);
            await _context.SaveChangesAsync();
            return new JsonResult(obj);
        }

    }
}
