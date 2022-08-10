using CasaDeApuestasMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CasaDeApuestasMVC.Controllers
{
    public class ModalidadPagoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Listado()
        {
            var modalidadPago = await ModalidadPagoService.GetAll();
            return View(modalidadPago);
        }
    }
}
