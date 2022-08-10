using CasaDeApuestasMVC.Models;
using Newtonsoft.Json;
using System.Text;

namespace CasaDeApuestasMVC.Services
{
    public class ProblemasService
    {
        public static async Task<IEnumerable<ProblemasModel>> GetAll()
        {
            //Get all Users
            String urlBase = "http://localhost:5001/api/Problemas/";

            var client = new HttpClient();
            var response = await client.GetAsync(urlBase + "GetAll");
            string result = await response.Content.ReadAsStringAsync();
            var problemas = JsonConvert.DeserializeObject<IEnumerable<ProblemasModel>>(result);
            return problemas;

        }
        public static async Task<ProblemasModel> GetProblemas(int id)
        {
            //Get All using HttpClient
            string urlBase = "http://localhost:5001/api/Problemas/";

            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(urlBase + "GetById/" + id);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var problemas = JsonConvert.DeserializeObject<ProblemasModel>(apiResponse);
            return problemas;
        }

        //Create new Problemas
        public static async Task<bool> Insert(ProblemasModel problemas)
        {
            string urlBase = "http://localhost:5001/api/Problemas/";

            using var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(problemas);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            using var response = await httpClient.PostAsync(urlBase + "Create", stringContent);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<bool>(apiResponse);
            return result;
        }

        //Update Problemas
        public static async Task<bool> Update(int id, ProblemasModel problemas)
        {
            string urlBase = "http://localhost:5001/api/Problemas/";
            using var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(problemas);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            using var response = await httpClient.PutAsync(urlBase + "Update/" + id, stringContent);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<bool>(apiResponse);
            return result;
        }
        //Delete Problemas
        public static async Task<bool> Delete(int id)
        {
            string urlBase = "http://localhost:5001/api/Problemas/";
            using var httpClient = new HttpClient();
            using var response = await httpClient.DeleteAsync(urlBase + "Delete/" + id);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<bool>(apiResponse);
            return result;
        }
    }
}
