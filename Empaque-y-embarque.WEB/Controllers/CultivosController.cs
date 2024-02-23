using EYE.Entidades;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class CultivosController : Controller
    {
        private readonly EyeContext _context;
        public CultivosController(EyeContext context)
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

            var obj = await _context.Cultivos
                                    .Include(x=> x.FamiliaCultivos)
                                    .Select(x => new { x.IdCultivo,x.IdFamiliaCultivo,Familia=x.FamiliaCultivos.Nombre, x.Nombre, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .ToListAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> Buscar([FromQuery] int id)
        {

            var obj = await _context.Cultivos
                                    .Where(x => x.IdCultivo == id)
                                    .Select(x => new { x.IdCultivo, x.Nombre, x.IdFamiliaCultivo, Familia = x.FamiliaCultivos.Nombre, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] CultivoEntity obj)
        {

            try
            {
                if (obj.IdCultivo == 0) await _context.Cultivos.AddAsync(obj);
                else _context.Cultivos.Update(obj);

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
            var obj = await _context.Cultivos.Where(x => x.IdCultivo == id).FirstOrDefaultAsync();
            obj.EstaActivo = !obj.EstaActivo;
            _context.Cultivos.Update(obj);
            await _context.SaveChangesAsync();
            return new JsonResult(obj);
        }

        public async Task<JsonResult> GetFamiliaCultivo()
        {
            var articulo = await _context.FamiliaCultivos.Where(x => x.EstaActivo == true).Select(x => new { x.IdFamiliaCultivo, x.Nombre, }).ToListAsync();

            return new JsonResult(articulo);
        }
    }
}
