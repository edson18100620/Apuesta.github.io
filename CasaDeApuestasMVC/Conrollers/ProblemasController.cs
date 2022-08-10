using CasaDeApuestasMVC.Models;
using CasaDeApuestasMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CasaDeApuestasMVC.Controllers
{
    public class ProblemasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Listado()
        {
            var problemas = await ProblemasService.GetAll();
            return PartialView(problemas);
        }
        public async Task<IActionResult> Eliminar(int idProblemas)
        {
            bool exito = await ProblemasService.Delete(idProblemas);
            return Json(exito);
        }

        public async Task<IActionResult> Obtener(int idProblemas)
        {
            var problemas = await ProblemasService.GetProblemas(idProblemas);
            return Json(problemas);
        }


        [HttpPost]
        public async Task<IActionResult> Guardar(int idProblemas, int codUsuario, DateTime fecha, string detalle, bool estado, int codAudioVisual)
        {
            var problemas = new ProblemasModel()
            {
                CodUsuario = codUsuario,
                Fecha = fecha,
                Detalle = detalle,
                Estado = estado,
                CodAudioVisual = codAudioVisual
            };

            bool exito = true;
            if (idProblemas == -1)
                exito = await ProblemasService.Insert(problemas);
            else
            {
                problemas.Id = idProblemas;
                exito = await ProblemasService.Update(idProblemas, problemas);
            }
            return Json(exito);
        }
    }
}
