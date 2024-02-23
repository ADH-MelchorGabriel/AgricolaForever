using EYE.Core.AcarreoCampo;
using EYE.Dtos;
using EYE.Entidades;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class AcarreoCampoController : Controller
    {
        private readonly EyeContext _context;
        public AcarreoCampoController(EyeContext context)
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
            var obj = await _context.AcarreoCampo
                                    .Select(x => new
                                    {
                                        x.IdAcarreoCampo,
                                        x.Folio,
                                        Fecha = x.Fecha.ToString("dd/MM/yyyy"),
                                        x.IdLote,
                                        Lote = x.Lote.Nombre,
                                        x.IdCultivo,
                                        Cultivo = x.Cultivo.Nombre,
                                        x.Mayordomo,
                                        x.Chofer,
                                        x.PlacasVehiculo,
                                        x.PlacasRemolque,
                                        x.Cajas,
                                        x.Kilogramos
                                    })
                                    .OrderByDescending(x => x.IdAcarreoCampo)
                                    .ToListAsync();
            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> Buscar([FromQuery] int id)
        {

            var obj = await _context.AcarreoCampo
                                    .Where(x => x.IdAcarreoCampo == id)
                                    .Select(x => new
                                    {
                                        x.IdAcarreoCampo,
                                        x.Folio,
                                        x.Fecha,
                                        x.IdLote,
                                        x.IdCultivo,
                                        x.Mayordomo,
                                        x.Chofer,
                                        x.PlacasVehiculo,
                                        x.PlacasRemolque,
                                        x.Cajas,
                                        x.Kilogramos
                                    })
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] AcarreoCampoDto obj)
        {
            try
            {
                var newObj = new AcarreoCampoEntity(obj);
                if (obj.IdAcarreoCampo == 0) await _context.AcarreoCampo.AddAsync(newObj);
                else _context.AcarreoCampo.Update(newObj);
                await _context.SaveChangesAsync();
                return new JsonResult(newObj);
            }
            catch (System.Exception)
            {
                return new JsonResult(null);
            }
        }

        [HttpGet]
        public async Task<JsonResult> Cancelar([FromQuery] int id)
        {
            var obj = await _context.AcarreoCampo.Where(x => x.IdAcarreoCampo == id).FirstOrDefaultAsync();


            _context.AcarreoCampo.Remove(obj);
            await _context.SaveChangesAsync();


            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> GetLote()
        {
            var lista = await _context.Lotes.Where(x => x.EstaActivo == true).Select(x => new { x.IdLote, x.Nombre, }).ToListAsync();

            return new JsonResult(lista.OrderBy(x => x.Nombre).ToList());
        }
        [HttpGet]
        public async Task<JsonResult> GetCultivo()
        {
            var lista = await _context.Cultivos.Where(x => x.EstaActivo == true).Select(x => new { x.IdCultivo, x.Nombre, }).ToListAsync();

            return new JsonResult(lista.OrderBy(x => x.Nombre).ToList());
        }
    }
}
