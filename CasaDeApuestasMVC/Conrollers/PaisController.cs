using CasaDeApuestasMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CasaDeApuestasMVC.Controllers
{
    public class PaisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Listado()
        {
            var pais = await PaisService.GetAll();
            return View(pais);
        }
    }
}
