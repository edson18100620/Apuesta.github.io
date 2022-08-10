using CasaDeApuestasMVC.Models;
using Newtonsoft.Json;

namespace CasaDeApuestasMVC.Services
{
    public class ModalidadPagoService
    {
        public static async Task<IEnumerable<ModalidadPagoModel>> GetAll()
        {
            //Get all Users
            String urlBase = "http://localhost:5001/api/ModalidadPago/";

            var client = new HttpClient();
            var response = await client.GetAsync(urlBase + "GetAll");
            string result = await response.Content.ReadAsStringAsync();
            var modalidadPago = JsonConvert.DeserializeObject<IEnumerable<ModalidadPagoModel>>(result);
            return modalidadPago;

        }
    }
}
