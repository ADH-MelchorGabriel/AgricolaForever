
using EYE.Entidades;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EmpaqueCeresWeb.Web.Controllers
{
    public class TipoCambioController : Controller
    {

        private readonly EyeContext ceresContext;

        public TipoCambioController(EyeContext context)
        {
            ceresContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> listar()
        {

            var lista = await ceresContext.TiposCambios.ToListAsync();

            return new JsonResult(lista.OrderByDescending(x => x.Fecha));
        }
        public async Task<JsonResult> Guardar([FromBody]TipoCambioEntity newObj )
        {
            try
            {
                await ceresContext.TiposCambios.AddAsync(newObj);
                await ceresContext.SaveChangesAsync();

                return new JsonResult(newObj);
            }

            catch (System.Exception)
            {
                return new JsonResult(null);
                
            }
            
        }


    }
}
