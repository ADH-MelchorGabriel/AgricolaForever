using EYE.Entidades;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class ArticulosController : Controller
    {

        private readonly EyeContext _context;
        public ArticulosController(EyeContext context)
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
            var obj = await _context.Articulos
                                    .Select(x => new { x.IdArticulo, x.Nombre, TipoArticulo=x.TipoArticulo.ToString(),x.Existencia,x.CostoPromedio, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .ToListAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> Buscar([FromQuery] int id)
        {

            var obj = await _context.Articulos
                                    .Where(x => x.IdArticulo == id)
                                    .Select(x => new { x.IdArticulo, x.Nombre, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] ArticuloEntity obj)
        {

            try
            {
                if (obj.IdArticulo == 0) await _context.Articulos.AddAsync(obj);
                else _context.Articulos.Update(obj);

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
            var obj = await _context.Articulos.Where(x => x.IdArticulo == id).FirstOrDefaultAsync();
            obj.EstaActivo = !obj.EstaActivo;
            _context.Articulos.Update(obj);
            await _context.SaveChangesAsync();
            return new JsonResult(obj);
        }
    }
}
