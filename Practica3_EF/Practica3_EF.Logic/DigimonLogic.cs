using Newtonsoft.Json;
using Practica3_EF.Entities.BaseApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Practica3_EF.Logic
{
    public class DigimonLogic
    {
        public async Task<List<Digimon>> GetAll()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://digimon-api.vercel.app/api/digimon");
            try
            {
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<Digimon>>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exception("Codigo de error: " + response.StatusCode);
                }

            }
            catch (HttpRequestException)
            {
                throw new Exception("La peticion no se pudo completar.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
