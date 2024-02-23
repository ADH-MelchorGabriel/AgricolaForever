using EYE.Entidades;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class ClienteController : Controller
    {
        private readonly EyeContext _context;
        public ClienteController(EyeContext context)
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

            var obj = await _context.Clientes
                                    .Select(x => new { x.IdCliente,x.RFC,x.Codigo, x.Nombre,x.CveRecidenciaFiscal,x.CveRegimenFiscal,x.NumRegIdTrib,x.DomicilioFiscal, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .ToListAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> Buscar([FromQuery] int id)
        {

            var obj = await _context.Clientes
                                    .Where(x => x.IdCliente == id)
                                    .Select(x => new { x.IdCliente, x.RFC, x.Codigo, x.Nombre, x.CveRecidenciaFiscal, x.CveRegimenFiscal, x.NumRegIdTrib, x.DomicilioFiscal, x.EstaActivo })
                                    .OrderBy(x => x.Nombre)
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] ClienteEntity obj)
        {

            try
            {
                if (obj.IdCliente == 0) await _context.Clientes.AddAsync(obj);
                else _context.Clientes.Update(obj);

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
            var obj = await _context.Clientes.Where(x => x.IdCliente == id).FirstOrDefaultAsync();
            obj.EstaActivo = !obj.EstaActivo;
            _context.Clientes.Update(obj);
            await _context.SaveChangesAsync();
            return new JsonResult(obj);
        }
    }
}
