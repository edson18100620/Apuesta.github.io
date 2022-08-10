using CasaDeApuestasMVC.Models;
using Newtonsoft.Json;
using System.Text;

namespace CasaDeApuestasMVC.Services
{
    public class EquiposService
    {
        public static async Task<IEnumerable<EquiposModel>> GetAll()
        {
            //Get all Users
            String urlBase = "http://localhost:5001/api/Equipos/";

            var client = new HttpClient();
            var response = await client.GetAsync(urlBase + "GetAll");
            string result = await response.Content.ReadAsStringAsync();
            var equipos = JsonConvert.DeserializeObject<IEnumerable<EquiposModel>>(result);
            return equipos;

        }
        public static async Task<EquiposModel> GetEquipos(int id)
        {
            //Get All using HttpClient
            string urlBase = "http://localhost:5001/api/Equipos/";

            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(urlBase + "GetById/" + id);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var equipos = JsonConvert.DeserializeObject<EquiposModel>(apiResponse);
            return equipos;
        }

        //Create new Equipos
        public static async Task<int> Insert(EquiposModel equipos)
        {
            string urlBase = "http://localhost:5001/api/Equipos/";

            using var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(equipos);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            using var response = await httpClient.PostAsync(urlBase + "Create", stringContent);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<int>(apiResponse);
            return result;
        }


        //Update Equipos
        public static async Task<int> Update(int id, EquiposModel equipos)
        {
            string urlBase = "http://localhost:5001/api/Equipos/";
            using var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(equipos);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            using var response = await httpClient.PutAsync(urlBase + "Update/?id=" + id, stringContent);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<int>(apiResponse);
            return result;
        }
        //Delete Equipos
        public static async Task<bool> Delete(int id)
        {
            string urlBase = "http://localhost:5001/api/Equipos/";
            using var httpClient = new HttpClient();
            using var response = await httpClient.DeleteAsync(urlBase + "Delete/?id=" + id);
            string apiResponse = response.Content.ReadAsStringAsync().Result;

            return (int)response.StatusCode == 400 ? false : true;
        }
    }
}
