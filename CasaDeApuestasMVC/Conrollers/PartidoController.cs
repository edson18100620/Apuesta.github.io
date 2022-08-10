using CasaDeApuestasMVC.Models;
using CasaDeApuestasMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CasaDeApuestasMVC.Controllers
{
    public class PartidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Listado()
        {
            var partido = await PartidoService.GetAll();
            return PartialView(partido);
        }
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int idPartido)
        {
            bool exito = await PartidoService.Delete(idPartido);
            return Json(exito);
        }
        [HttpGet]
        public async Task<IActionResult> Obtener(int idPartido)
        {
            var partido = await PartidoService.GetPartido(idPartido);
            return Json(partido);
        }


        [HttpPost]
        public async Task<IActionResult> Guardar(int idPartido, int equipoLocId, int equipoVisId,
            int categoriaId, double cuotaLoc, double cuotaVis)
        {
            var partido = new PartidoModel()
            {
                EquipoLocId = equipoLocId,
                EquipoVisId = equipoVisId,
                CategoriaId = categoriaId,
                CuotaLoc = cuotaLoc,
                CuotaVis = cuotaVis
            };

            bool exito = true;
            if (idPartido == -1)
                exito = await PartidoService.Insert(partido) > 0 ? true : false;
            else
            {
                partido.Id = idPartido;
                exito = await PartidoService.Update(idPartido, partido) > 0 ? true : false;
            }
            return Json(exito);
        }
    }
}
