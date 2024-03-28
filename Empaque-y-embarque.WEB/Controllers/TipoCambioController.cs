
using EYE.Entidades;
using EYE.Servicio.Data;
using Facturacion.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Core.Helppers;

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

        public async Task<JsonResult> Borrar([FromQuery]int id)
        {
            try
            {
                var obj = await ceresContext.TiposCambios
                                   .Where(x => x.IdTipoCambio == id )
                                   .FirstOrDefaultAsync();

                if (obj == null)
                    return new JsonResult(new Sistema.Core.Helppers.Respuesta("No exiten datos"));

     

                ceresContext.TiposCambios.Remove(obj);
                await ceresContext.SaveChangesAsync();


                return new JsonResult(new Sistema.Core.Helppers.Respuesta("Se borro correctamente la información...", obj));
            }
            catch (Exception ex)
            {
                return new JsonResult(new Sistema.Core.Helppers.Respuesta(ex.Message));
            }
        }
    }
}
