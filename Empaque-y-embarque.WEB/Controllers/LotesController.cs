using EYE.Entidades;
using EYE.Enumeradores;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class LotesController : Controller
    {
        private readonly EyeContext _context;
        public LotesController(EyeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Listar()
        {

            var obj = await _context.Lotes
                                    .Select(x => new { x.IdLote, x.Nombre,x.Codigo, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .ToListAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> Buscar([FromQuery] int id)
        {

            var obj = await _context.Lotes
                                    .Where(x => x.IdLote == id)
                                    .Select(x => new { 
                                        x.IdLote,
                                        x.Nombre,
                                        x.Codigo,
                                        x.MunicipioProductor,
                                        x.UbicacionPredio,
                                        x.Sector,
                                        x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] LoteEntity obj)
        {

            try
            {
                if (obj.IdLote == 0) await _context.Lotes.AddAsync(obj);
                else _context.Lotes.Update(obj);

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
            var obj = await _context.Lotes.Where(x => x.IdLote == id).FirstOrDefaultAsync();
            obj.EstaActivo = !obj.EstaActivo;
            _context.Lotes.Update(obj);
            await _context.SaveChangesAsync();
            return new JsonResult(obj);
        }

        [HttpGet]
        public JsonResult GetTipoEmbarque()
        {
            var lista = Enum.GetValues(typeof(SectorEnum))
                   .Cast<SectorEnum>()
                   .Select(d => new { display = d.ToString(), value = (int)d })
                   .ToList();
            return new JsonResult(lista);
        }




    }
}
