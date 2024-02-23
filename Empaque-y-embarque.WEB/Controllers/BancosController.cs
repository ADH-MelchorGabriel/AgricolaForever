using EYE.Entidades;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class BancosController : Controller
    {
        private readonly EyeContext _context;
        public BancosController(EyeContext context)
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

            var obj = await _context.Bancos
                                    .Select(x => new { x.IdBanco, x.Nombre, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .ToListAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> Buscar([FromQuery] int id)
        {

            var obj = await _context.Bancos
                                    .Where(x => x.IdBanco == id)
                                    .Select(x => new { x.IdBanco, x.Nombre, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] BancoEntity obj)
        {

            try
            {
                if (obj.IdBanco == 0) await _context.Bancos.AddAsync(obj);
                else _context.Bancos.Update(obj);

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
            var obj = await _context.Bancos.Where(x => x.IdBanco == id).FirstOrDefaultAsync();
            obj.EstaActivo = !obj.EstaActivo;
            _context.Bancos.Update(obj);
            await _context.SaveChangesAsync();
            return new JsonResult(obj);
        }
    }
}
