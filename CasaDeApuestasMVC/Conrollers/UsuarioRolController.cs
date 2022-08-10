using CasaDeApuestasMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CasaDeApuestasMVC.Controllers
{
    public class UsuarioRolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Listado()
        {
            var usuarioRol = await UsuarioRolService.GetAll();
            return View(usuarioRol);
        }
    }
}
