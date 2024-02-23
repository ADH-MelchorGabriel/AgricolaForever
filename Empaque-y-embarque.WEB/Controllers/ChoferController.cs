using EYE.Entidades;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class ChoferController : Controller
    {
        private readonly EyeContext _context;
        public ChoferController (EyeContext context)
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

            var obj = await _context.Choferes
                                    .Include(x => x.LineaTransportes)
                                    .Select(x => new { x.IdChofer, x.IdLineaTransporte, Lineas = x.LineaTransportes.Nombre, x.Nombre,x.Telefono,x.EstaActivo })
                                    .OrderBy(x => x.IdChofer)
                                    .ToListAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> Buscar([FromQuery] int id)
        {

            var obj = await _context.Choferes
                                    .Include(x=>x.LineaTransportes)
                                    .Where(x => x.IdChofer == id)
                                    .Select(x => new { x.IdChofer, x.IdLineaTransporte,Lineas=x.LineaTransportes.Nombre, x.Nombre, x.Telefono, x.EstaActivo })
                                    .OrderBy(x => x.IdChofer)
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] ChoferEntity obj)
        {

            try
            {
                if (obj.IdChofer == 0) await _context.Choferes.AddAsync(obj);
                else _context.Choferes.Update(obj);

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
            var obj = await _context.Choferes.Where(x => x.IdChofer == id).FirstOrDefaultAsync();
            obj.EstaActivo = !obj.EstaActivo;
            _context.Choferes.Update(obj);
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
