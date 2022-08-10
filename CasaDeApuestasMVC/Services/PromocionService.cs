using CasaDeApuestasMVC.Models;
using Newtonsoft.Json;
using System.Text;

namespace CasaDeApuestasMVC.Services
{
    public class PromocionService
    {
        public static async Task<IEnumerable<PromocionModel>> GetAll()
        {
            //Get all Users
            String urlBase = "http://localhost:5001/api/Promocion/";

            var client = new HttpClient();
            var response = await client.GetAsync(urlBase + "GetAll");
            string result = await response.Content.ReadAsStringAsync();
            var promocion = JsonConvert.DeserializeObject<IEnumerable<PromocionModel>>(result);
            return promocion;

        }
        public static async Task<PromocionModel> GetPromocion(int id)
        {
            //Get All using HttpClient
            string urlBase = "http://localhost:5001/api/Promocion/";

            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(urlBase + "GetById/" + id);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var promocion = JsonConvert.DeserializeObject<PromocionModel>(apiResponse);
            return promocion;
        }

        //Create new Promocion
        public static async Task<bool> Insert(PromocionModel promocion)
        {
            string urlBase = "http://localhost:5001/api/Promocion/";

            using var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(promocion);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            using var response = await httpClient.PostAsync(urlBase + "Create", stringContent);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<bool>(apiResponse);
            return result;
        }

        //Update Promocion
        public static async Task<bool> Update(int id, PromocionModel promocion)
        {
            string urlBase = "http://localhost:5001/api/Promocion/";
            using var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(promocion);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            using var response = await httpClient.PutAsync(urlBase + "Update/" + id, stringContent);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<bool>(apiResponse);
            return result;
        }
        //Delete Promocion
        public static async Task<bool> Delete(int id)
        {
            string urlBase = "http://localhost:5001/api/Promocion/";
            using var httpClient = new HttpClient();
            using var response = await httpClient.DeleteAsync(urlBase + "Delete/" + id);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<bool>(apiResponse);
            return result;
        }
    }
}
