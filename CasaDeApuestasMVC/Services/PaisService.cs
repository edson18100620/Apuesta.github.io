using CasaDeApuestasMVC.Models;
using Newtonsoft.Json;

namespace CasaDeApuestasMVC.Services
{
    public class PaisService
    {
        public static async Task<IEnumerable<PaisModel>> GetAll()
        {
            //Get all Users
            String urlBase = "http://localhost:5001/api/Pais/";

            var client = new HttpClient();
            var response = await client.GetAsync(urlBase + "GetAll");
            string result = await response.Content.ReadAsStringAsync();
            var pais = JsonConvert.DeserializeObject<IEnumerable<PaisModel>>(result);
            return pais;

        }
    }
}
