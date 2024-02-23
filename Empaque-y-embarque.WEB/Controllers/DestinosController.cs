using EYE.Entidades;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAT.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class DestinosController : Controller
    {
        private readonly EyeContext _context;
        private readonly SatContext _satContext;
        public DestinosController(EyeContext context,SatContext satContext)
        {
            _context = context;
            _satContext = satContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Listar()
        {

            try
            {
                var obj = await _context.Destinos
                                   .Select(x => new { x.IdDestino,x.Nombre, x.CvePais, x.CveEstado, x.NumeroExterior, x.Calle, x.Localidad, x.Municipio, x.CodigoPostal, x.EstaActivo })
                                   .OrderBy(x => x.IdDestino)
                                   .ToListAsync();

                return new JsonResult(obj);
            }
            catch (System.Exception ex)
            {

                var c = ex.Message;

                return new JsonResult(null);
            }

           
        }
        [HttpGet]
        public async Task<JsonResult> Buscar([FromQuery] int id)
        {

            var obj = await _context.Destinos
                                    
                                    .Where(x => x.IdDestino == id)
                                    .Select(x => new { x.IdDestino,x.Nombre, x.CvePais, x.CveEstado, x.NumeroExterior, x.Calle, x.Localidad, x.Municipio, x.CodigoPostal, x.EstaActivo })
                                    .OrderBy(x => x.IdDestino)
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] DestinoEntity obj)
        {

            try
            {
                if (obj.IdDestino == 0) await _context.Destinos.AddAsync(obj);
                else _context.Destinos.Update(obj);

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
            var obj = await _context.Destinos.Where(x => x.IdDestino == id).FirstOrDefaultAsync();
            obj.EstaActivo = !obj.EstaActivo;
            _context.Destinos.Update(obj);
            await _context.SaveChangesAsync();
            return new JsonResult(obj);
        }
        public async Task<JsonResult> GetEstado([FromQuery] string cvePais)
        {
              var lista = await _satContext.Estado
                                           .Where(x => x.CvePais==cvePais)
                                           .Select(x => new { x.CveEstado, x.Descripcion })
                                           .OrderBy(x=> x.CveEstado)
                                           .ToListAsync();

              return new JsonResult(lista);
        }
        public async Task<JsonResult> GetPais()
        {
            var lista = await _satContext.Pais.OrderBy(x=> x.Descripcion).ToListAsync();

             return new JsonResult(lista);
        }

    }
}
