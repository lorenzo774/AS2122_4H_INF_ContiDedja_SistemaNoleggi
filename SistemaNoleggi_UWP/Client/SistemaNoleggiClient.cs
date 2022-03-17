using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Noleggio_Library;

namespace SistemaNoleggi_UWP.Client
{
    public class SistemaNoleggiClient
    {
        private HttpClient client;

        private static SistemaNoleggiClient instance;

        public static SistemaNoleggiClient Instance
        {
            get
            {
                if (instance == null)
                    instance = new SistemaNoleggiClient();

                return instance;
            }
        }

        public SistemaNoleggiClient()
        {
            client = new HttpClient();
        }

        private async Task<string> CallUrlAsync(string url)
        {
            var response = await client.GetStringAsync(url);
            return response;
        }

        private async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            var response = await client.DeleteAsync(url);
            return response;
        }

        public async Task<List<Noleggio>> GetAllNoleggiAsync()
        {
            var response = await CallUrlAsync("https://restapinoleggi.azurewebsites.net/api/noleggi");
            Console.WriteLine(response);
            var noleggi = JsonConvert.DeserializeObject<List<Noleggio>>(response);
            return noleggi;
        }

        public async Task<List<Automobile>> GetAllAutomobiliAsync()
        {
            var response = await CallUrlAsync("https://restapinoleggi.azurewebsites.net/api/automobili");
            var automobili = JsonConvert.DeserializeObject<List<Automobile>>(response);
            return automobili;
        }

        public async Task<List<Furgone>> GetAllFurgoniAsync()
        {
            var response = await CallUrlAsync("https://restapinoleggi.azurewebsites.net/api/furgoni");
            var furgoni = JsonConvert.DeserializeObject<List<Furgone>>(response);
            return furgoni;
        }

        public async Task<List<Cliente>> GetAllClientiAsync()
        {
            var response = await CallUrlAsync("https://restapinoleggi.azurewebsites.net/api/clienti");
            var clienti = JsonConvert.DeserializeObject<List<Cliente>>(response);
            return clienti;
        }

        public async Task RemoveNoleggioAsync(int id)
        {
            await DeleteAsync($"https://restapinoleggi.azurewebsites.net/api/noleggi/{id}");
        }

        public async Task RemoveAutomobileAsync(int id)
        {
            await DeleteAsync($"https://restapinoleggi.azurewebsites.net/api/automobili/{id}");
        }

        public async Task RemoveFurgoneAsync(int id)
        {
            await DeleteAsync($"https://restapinoleggi.azurewebsites.net/api/furgoni/{id}");
        }
    }
}
