using CasaDeApuestasMVC.Models;
using CasaDeApuestasMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CasaDeApuestasMVC.Controllers
{
    public class PromocionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Listado()
        {
            var promocion = await PromocionService.GetAll();
            return View(promocion);
        }
        public async Task<IActionResult> Eliminar(int idPromocion)
        {
            bool exito = await PromocionService.Delete(idPromocion);
            return Json(exito);
        }

        public async Task<IActionResult> Obtener(int idPromocion)
        {
            var promocion = await PromocionService.GetPromocion(idPromocion);
            return Json(promocion);
        }


        [HttpPost]
        public async Task<IActionResult> Guardar(int idPromocion, int codUsuario, DateTime fecha, string detalle,
            bool estado, int codAudioVisual)
        {
            var promocion = new PromocionModel()
            {
                CodUsuario = codUsuario,
                Fecha = fecha,
                Detalle = detalle,
                Estado = estado,
                CodAudioVisual = codAudioVisual
            };

            bool exito = true;
            if (idPromocion == -1)
                exito = await PromocionService.Insert(promocion);
            else
            {
                promocion.Id = idPromocion;
                exito = await PromocionService.Update(idPromocion, promocion);
            }
            return Json(exito);
        }
    }
}
