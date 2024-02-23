using Empaque_y_embarque.WEB.Models;
using EYE.Dtos;
using EYE.Entidades;
using EYE.Servicio.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Seguridad.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Empaque_y_embarque.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPasswordServices _passwordServices;
        private readonly EyeContext _context;
        public HomeController(ILogger<HomeController> logger, EyeContext context, IPasswordServices passwordServices)
        {
            _logger = logger;
            _passwordServices= passwordServices;
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin login, string returnUrl = "")
        {
            var user = GetLoginByCredentials(login);
            if (user != null)
            {
                List<Claim> TaurusClaims = new()
                        {
                            new Claim("IdUsuario", user.IdUsuario.ToString()),
                           // new Claim("IdSucursal", user.IdSucursal.ToString()),
                            new Claim(ClaimTypes.Name, user.Nombre),
                        };


                foreach (var item in user.RolUsuario)
                {
                    TaurusClaims.Add(new Claim(ClaimTypes.Role, item.Rol.Nombre));
                }


                ClaimsIdentity TaurusIdentity = new(TaurusClaims, "Taurus Identity");

                ClaimsPrincipal userPrincipal = new(new[] { TaurusIdentity });

                HttpContext.SignInAsync(userPrincipal);

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(login);
        }



        private UsuarioEntity GetLoginByCredentials(UserLogin login)
        {
           
            
            if (!string.IsNullOrEmpty( login.Usuario) && !string.IsNullOrEmpty(login.Password))
            {
                var user = _context.Usuario
                              .Include(x => x.RolUsuario)
                              .ThenInclude(x => x.Rol)
                              .Where(x => x.UserName.ToLower() == login.Usuario.ToLower() && x.EstaActivo == true)
                              .FirstOrDefault();

                if (user != null)
                {

                    if (user.UserName == login.Usuario && _passwordServices.Check(user.Password, login.Password))
                    {
                        return user;
                    }
                }
            }
            
           

            return null;
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
