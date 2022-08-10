using CasaDeApuestasMVC.Models;
using Newtonsoft.Json;

namespace CasaDeApuestasMVC.Services
{
    public class UsuarioRolService
    {
        public static async Task<IEnumerable<UsuarioRolModel>> GetAll()
        {
            //Get all Users
            String urlBase = "http://localhost:5001/api/UsuarioRol/";

            var client = new HttpClient();
            var response = await client.GetAsync(urlBase + "GetAll");
            string result = await response.Content.ReadAsStringAsync();
            var usuarioRol = JsonConvert.DeserializeObject<IEnumerable<UsuarioRolModel>>(result);
            return usuarioRol;

        }
    }
}
