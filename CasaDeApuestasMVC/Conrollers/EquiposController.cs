using CasaDeApuestasMVC.Models;
using CasaDeApuestasMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CasaDeApuestasMVC.Controllers
{
    public class EquiposController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Listado()
        {
            var equipos = await EquiposService.GetAll();
            return PartialView(equipos);
        }
        public async Task<IActionResult> Eliminar(int idEquipos)
        {
            bool exito = await EquiposService.Delete(idEquipos);
            return Json(exito);
        }

        public async Task<IActionResult> Obtener(int idEquipos)
        {
            var equipos = await EquiposService.GetEquipos(idEquipos);
            return Json(equipos);
        }


        [HttpPost]
        public async Task<IActionResult> Guardar(int idEquipos, int idPais, string nombre)
        {
            var equipos = new EquiposModel()
            {
                Nombre = nombre,
                PaisId = idPais
            };

            bool exito = true;
            if (idEquipos == -1)
                exito = await EquiposService.Insert(equipos) > 0 ? true : false;
            else
            {
                equipos.Id = idEquipos;
                exito = await EquiposService.Update(idEquipos, equipos) > 0 ? true : false;
            }
            return Json(exito);
        }
    }
}
