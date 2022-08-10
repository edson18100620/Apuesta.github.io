using CasaDeApuestasMVC.Models;
using Newtonsoft.Json;
using System.Text;

namespace CasaDeApuestasMVC.Services
{
    public class PartidoService
    {
        public static async Task<IEnumerable<PartidoModel>> GetAll()
        {
            //Get all Users
            String urlBase = "http://localhost:5001/api/Partido/";

            var client = new HttpClient();
            var response = await client.GetAsync(urlBase + "GetAll");
            string result = await response.Content.ReadAsStringAsync();
            var partido = JsonConvert.DeserializeObject<IEnumerable<PartidoModel>>(result);
            return partido;

        }
        public static async Task<PartidoModel> GetPartido(int id)
        {
            //Get All using HttpClient
            string urlBase = "http://localhost:5001/api/Partido/";

            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(urlBase + "GetById/" + id);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var partido = JsonConvert.DeserializeObject<PartidoModel>(apiResponse);
            return partido;
        }

        //Create new Partido
        public static async Task<int> Insert(PartidoModel partido)
        {
            string urlBase = "http://localhost:5001/api/Partido/";

            using var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(partido);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            using var response = await httpClient.PostAsync(urlBase + "Create", stringContent);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<int>(apiResponse);
            return result;
        }


        //Update Partido
        public static async Task<int> Update(int id, PartidoModel partido)
        {
            string urlBase = "http://localhost:5001/api/Partido/";
            using var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(partido);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            using var response = await httpClient.PutAsync(urlBase + "Update/?id=" + id, stringContent);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<int>(apiResponse);
            return result;
        }
        //Delete Partido
        public static async Task<bool> Delete(int id)
        {
            string urlBase = "http://localhost:5001/api/Partido/";
            using var httpClient = new HttpClient();
            using var response = await httpClient.DeleteAsync(urlBase + "Delete/?id=" + id);
            string apiResponse = response.Content.ReadAsStringAsync().Result;

            return (int)response.StatusCode == 400 ? false : true;
        }
    }
}
