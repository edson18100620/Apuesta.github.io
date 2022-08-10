using CasaDeApuestasMVC.Models;
using CasaDeApuestasMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CasaDeApuestasMVC.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Listado()
        {
            var categoria = await CategoriaService.GetAll();
            return PartialView(categoria);
        }
        public async Task<IActionResult> Eliminar(int idCategoria)
        {
            bool exito = await CategoriaService.Delete(idCategoria);
            return Json(exito);
        }

        public async Task<IActionResult> Obtener(int idCategoria)
        {
            var categoria = await CategoriaService.GetCategoria(idCategoria);
            return Json(categoria);
        }


        [HttpPost]
        public async Task<IActionResult> Guardar(int idCategoria, string descripcion)
        {
            var categoria = new CategoriaModel()
            {
                Descripcion = descripcion,
            };

            bool exito = true;
            if (idCategoria == -1)
                exito = await CategoriaService.Insert(categoria) > 0 ? true : false;
            else
            {
                categoria.Id = idCategoria;
                exito = await CategoriaService.Update(idCategoria, categoria) > 0 ? true : false;
            }
            return Json(exito);
        }

        
    }
}
