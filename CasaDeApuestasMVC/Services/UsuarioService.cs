using Newtonsoft.Json;
using CasaDeApuestasMVC.Models;
using System.Text;

namespace CasaDeApuestasMVC.Services
{
    public class UsuarioService
    {
        public static async Task<IEnumerable<UsuarioModel>> GetAll()
        {
            //Get all Users
            String urlBase = "http://localhost:5001/api/Usuario/";

            var client = new HttpClient();
            var response = await client.GetAsync(urlBase + "GetAll");
            string result = await response.Content.ReadAsStringAsync();
            var usuario = JsonConvert.DeserializeObject<IEnumerable<UsuarioModel>>(result);
            return usuario;

        }
        public static async Task<UsuarioModel> GetUsuario(int id)
        {
            //Get All using HttpClient
            string urlBase = "http://localhost:5001/api/Usuario/";

            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(urlBase + "GetById/" + id);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var usuario = JsonConvert.DeserializeObject<UsuarioModel>(apiResponse);
            return usuario;
        }

        //Create new Usuario
        public static async Task<int> Insert(UsuarioModel usuario)
        {
            string urlBase = "http://localhost:5001/api/Usuario/";

            using var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(usuario);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            using var response = await httpClient.PostAsync(urlBase + "Create", stringContent);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<int>(apiResponse);
            return result;
        }


        //Update Usuario
        public static async Task<int> Update(int id, UsuarioModel usuario)
        {
            string urlBase = "http://localhost:5001/api/Usuario/";
            using var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(usuario);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            using var response = await httpClient.PutAsync(urlBase + "Update/?id=" + id, stringContent);
            string apiResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<int>(apiResponse);
            return result;
        }
        //Delete Usuario
        public static async Task<bool> Delete(int id)
        {
            string urlBase = "http://localhost:5001/api/Usuario/";
            using var httpClient = new HttpClient();
            using var response = await httpClient.DeleteAsync(urlBase + "Delete/?id=" + id);
            string apiResponse = response.Content.ReadAsStringAsync().Result;

            return (int)response.StatusCode == 400 ? false : true;
        }

    }
}

