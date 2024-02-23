using EYE.Entidades;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class FamiliaCultivosController : Controller
    {
        private readonly EyeContext _context;
        public FamiliaCultivosController(EyeContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Listar()
        {

            var obj = await _context.FamiliaCultivos
                                    .Select(x => new { x.IdFamiliaCultivo, x.Nombre, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .ToListAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> Buscar([FromQuery] int id)
        {

            var obj = await _context.FamiliaCultivos
                                    .Where(x => x.IdFamiliaCultivo == id)
                                    .Select(x => new { x.IdFamiliaCultivo, x.Nombre, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] FamiliaCultivoEntity obj)
        {

            try
            {
                if (obj.IdFamiliaCultivo == 0) await _context.FamiliaCultivos.AddAsync(obj);
                else _context.FamiliaCultivos.Update(obj);

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
            var obj = await _context.FamiliaCultivos.Where(x => x.IdFamiliaCultivo == id).FirstOrDefaultAsync();
            obj.EstaActivo = !obj.EstaActivo;
            _context.FamiliaCultivos.Update(obj);
            await _context.SaveChangesAsync();
            return new JsonResult(obj);
        }


    }
}
