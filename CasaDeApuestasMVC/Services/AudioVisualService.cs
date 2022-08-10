using CasaDeApuestasMVC.Models;
using Newtonsoft.Json;

namespace CasaDeApuestasMVC.Services
{
    public class AudioVisualService
    {
        public static async Task<IEnumerable<AudioVisualModel>> GetAll()
        {
            //Get all Users
            String urlBase = "http://localhost:5001/api/Audiovisual/";

            var client = new HttpClient();
            var response = await client.GetAsync(urlBase + "GetAll");
            string result = await response.Content.ReadAsStringAsync();
            var audioVisual = JsonConvert.DeserializeObject<IEnumerable<AudioVisualModel>>(result);
            return audioVisual;

        }
    }
}
