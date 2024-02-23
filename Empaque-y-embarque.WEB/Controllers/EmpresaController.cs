using EYE.Entidades;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAT.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly EyeContext _context;
        private readonly SatContext _satContext;
        public EmpresaController(EyeContext context, SatContext satContext)
        {
            _context = context;
           _satContext=satContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task <JsonResult> Buscar()
        {
            var empresa = await _context.Empresa.FirstOrDefaultAsync();

            if (empresa == null)
                empresa = new EmpresaEntity();

            return new JsonResult(empresa);
        }
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] EmpresaEntity obj)
        {

            try
            {
                if (obj.IdEmpresa == 0) await _context.Empresa.AddAsync(obj);
                else _context.Empresa.Update(obj);

                await _context.SaveChangesAsync();
                return new JsonResult(obj);
            }
            catch (System.Exception)
            {
                return new JsonResult(null);

            }
        }
        public async Task<JsonResult> GetEstado([FromQuery] string cvePais)
        {
            var lista = await _satContext.Estado
                                         .Where(x => x.CvePais == cvePais)
                                         .Select(x => new { x.CveEstado, x.Descripcion })
                                         .OrderBy(x => x.CveEstado)
                                         .ToListAsync();
            return new JsonResult(lista);
        }
        public async Task<JsonResult> GetPais()
        {
            var lista = await _satContext.Pais.OrderBy(x => x.Descripcion).ToListAsync();
            return new JsonResult(lista);
        }
    }
}
