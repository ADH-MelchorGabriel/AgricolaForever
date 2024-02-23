using EYE.Entidades;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class AgricultoresController : Controller
    {

        private readonly EyeContext _context;
        public AgricultoresController (EyeContext context)
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

            var obj = await _context.Agricultores
                                    .Select(x => new { x.IdAgricultor, x.Nombre, x.Codigo, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .ToListAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> Buscar([FromQuery] int id)
        {

            var obj = await _context.Agricultores
                                    .Where(x => x.IdAgricultor == id)
                                    .Select(x => new { x.IdAgricultor, x.Nombre,x.Codigo, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] AgricultorEntity obj)
        {

            try
            {
                if (obj.IdAgricultor == 0) await _context.Agricultores.AddAsync(obj);
                else _context.Agricultores.Update(obj);

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
            var obj = await _context.Agricultores.Where(x => x.IdAgricultor == id).FirstOrDefaultAsync();
            obj.EstaActivo = !obj.EstaActivo;
            _context.Agricultores.Update(obj);
            await _context.SaveChangesAsync();
            return new JsonResult(obj);
        }
    }
}
