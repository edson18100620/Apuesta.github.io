using CasaDeApuestasMVC.Models;
using CasaDeApuestasMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CasaDeApuestasMVC.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registro()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Listado()
        {
            var usuarios = await UsuarioService.GetAll();
            return PartialView(usuarios);
        }
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int idUsuario)
        {
            bool exito = await UsuarioService.Delete(idUsuario);
            return Json(exito);
        }
        [HttpGet]
        public async Task<IActionResult> Obtener(int idUsuario)
        {
            var usuario = await UsuarioService.GetUsuario(idUsuario);
            return Json(usuario);
        }


        [HttpPost]
        public async Task<IActionResult> Guardar(int idUsuario, string nombre, string paterno,
            string materno, string telefono, string direccion, DateTime fechaNacimiento, string genero, string dni, string correo,/* int rolId,*/ string clave, int idPais)
        {
            var usuario = new UsuarioModel()
            {
                Nombre = nombre,
                Paterno = paterno,
                Materno = materno,
                Telefono = telefono,
                Direccion = direccion,
                FechaNacimiento = fechaNacimiento,
                Genero = genero,
                NumeroDocumento = dni,
                Correo = correo,
                //RolId = rolId,
                Clave = clave,
                PaisId = idPais
            };

            bool exito = true;
            if (idUsuario == -1)
                exito = await UsuarioService.Insert(usuario) > 0 ? true : false;
            else
            {
                usuario.Id = idUsuario;
                exito = await UsuarioService.Update(idUsuario, usuario) > 0 ? true : false;
            }
            return Json(exito);
        }
    }

    
}
