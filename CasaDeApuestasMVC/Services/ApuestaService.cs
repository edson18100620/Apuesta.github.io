using CasaDeApuestasMVC.Models;
using Newtonsoft.Json;

namespace CasaDeApuestasMVC.Services
{
    public class ApuestaService
    {
        public static async Task<IEnumerable<ApuestaModel>> GetAll()
        {
            //Get all Apuetas
            String urlBase = "http://localhost:5001/api/Apuesta/";

            var client = new HttpClient();
            var response = await client.GetAsync(urlBase + "GetAll");
            string result = await response.Content.ReadAsStringAsync();
            var apuesta = JsonConvert.DeserializeObject<IEnumerable<ApuestaModel>>(result);
            return apuesta;

        }
    }
}
