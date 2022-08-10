using CasaDeApuestasMVC.Models;
using Newtonsoft.Json;

namespace CasaDeApuestasMVC.Services
{
    public class RolService
    {
        public static async Task<IEnumerable<RolModel>> GetAll()
        {
            //Get all Users
            String urlBase = "http://localhost:5001/api/Rol/";

            var client = new HttpClient();
            var response = await client.GetAsync(urlBase + "GetAll");
            string result = await response.Content.ReadAsStringAsync();
            var rol = JsonConvert.DeserializeObject<IEnumerable<RolModel>>(result);
            return rol;

        }
    }
}
