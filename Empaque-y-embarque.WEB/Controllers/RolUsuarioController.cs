using EYE.Entidades;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class RolUsuarioController : Controller
    {
        private readonly EyeContext _context;

        public RolUsuarioController (EyeContext context)
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

            var obj = await _context.RolUsuario
                                    .Include(x => x.Usuario)
                                    .Include(x=> x.Rol)
                                    .Select(x => new { x.IdRolUsuario, x.IdUsuario,x.IdRol, Roles = x.Rol.Nombre, Usuarios= x.Usuario.Nombre, x.EstaActivo })
                                    .OrderBy(x => x.IdRolUsuario)
                                    .ToListAsync();

            return new JsonResult(obj);
        }
        [HttpGet]
        public async Task<JsonResult> Buscar([FromQuery] int id)
        {

            var obj = await _context.RolUsuario
                                    .Include(x => x.Usuario)
                                    .Include(x => x.Rol)
                                    .Where(x => x.IdRolUsuario == id)
                                    .Select(x => new { x.IdRolUsuario, x.IdUsuario, x.IdRol, Roles = x.Rol.Nombre, Usuarios = x.Usuario.Nombre, x.EstaActivo })
                                    .OrderBy(x => x.IdRolUsuario)
                                    .FirstOrDefaultAsync();

            return new JsonResult(obj);
        }
        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] RolUsuarioEntity obj)
        {

            try
            {
                if (obj.IdRolUsuario == 0) await _context.RolUsuario.AddAsync(obj);
                else _context.RolUsuario.Update(obj);

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
            var obj = await _context.RolUsuario.Where(x => x.IdRolUsuario == id).FirstOrDefaultAsync();
            obj.EstaActivo = !obj.EstaActivo;
            _context.RolUsuario.Update(obj);
            await _context.SaveChangesAsync();
            return new JsonResult(obj);
        }
        public async Task<JsonResult> GetUsuario()
        {
            var articulo = await _context.Usuario.Where(x => x.EstaActivo == true).Select(x => new { x.IdUsuario, x.Nombre }).ToListAsync();

            return new JsonResult(articulo);
        }
        public async Task<JsonResult> GetRol()
        {
            var articulo = await _context.Rol.Where(x => x.EstaActivo == true).Select(x => new { x.IdRol, x.Nombre }).ToListAsync();

            return new JsonResult(articulo);
        }
    }
}
