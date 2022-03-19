using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Noleggio_Library;
using Noleggio_Library.DTOs;
using System.Text;
using System.Linq;

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

        private StringContent ConvertToHttpContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        #region Get All
        public async Task<List<Noleggio>> GetAllNoleggiAsync()
        {
            SistemaNoleggi.Instance.Noleggi.Clear();
            var response = await CallUrlAsync("https://restapinoleggi.azurewebsites.net/api/noleggi");
            Console.WriteLine(response);
            var noleggi = JsonConvert.DeserializeObject<List<Noleggio>>(response);
            noleggi.ForEach(n => SistemaNoleggi.Instance.Noleggi.Add(n));
            SistemaNoleggi.Instance.Noleggi.Clear();
            return noleggi;
        }

        public async Task<List<Automobile>> GetAllAutomobiliAsync()
        {
            SistemaNoleggi.Instance.Automobili.Clear();
            var response = await CallUrlAsync("https://restapinoleggi.azurewebsites.net/api/automobili");
            var automobili = JsonConvert.DeserializeObject<List<Automobile>>(response);
            automobili.ForEach(a => SistemaNoleggi.Instance.Veicoli.Add(a));
            return automobili;
        }

        public async Task<List<Furgone>> GetAllFurgoniAsync()
        {
            SistemaNoleggi.Instance.Furgoni.Clear();
            var response = await CallUrlAsync("https://restapinoleggi.azurewebsites.net/api/furgoni");
            var furgoni = JsonConvert.DeserializeObject<List<Furgone>>(response);
            furgoni.ForEach(a => SistemaNoleggi.Instance.Veicoli.Add(a));
            return furgoni;
        }

        public async Task<List<Cliente>> GetAllClientiAsync()
        {
            SistemaNoleggi.Instance.Clienti.Clear();
            var response = await CallUrlAsync("https://restapinoleggi.azurewebsites.net/api/clienti");
            var clienti = JsonConvert.DeserializeObject<List<Cliente>>(response);
            clienti.ForEach(c => SistemaNoleggi.Instance.Clienti.Add(c));
            return clienti;
        }
        #endregion

        #region Remove by id
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

        public async Task RemoveClienteAsync(int id)
        {
            await DeleteAsync($"https://restapinoleggi.azurewebsites.net/api/clienti/{id}");
        }

        #endregion

        #region Add

        public async Task AddAutomobileAsync(AutomobileDTO automobile)
        {
            var httpContent = ConvertToHttpContent(automobile);
            await client.PostAsync(new Uri("https://restapinoleggi.azurewebsites.net/api/automobili"), httpContent);
        }

        public async Task AddFurgoneAsync(FurgoneDTO furgone)
        {
            var httpContent = ConvertToHttpContent(furgone);
            await client.PostAsync("https://restapinoleggi.azurewebsites.net/api/furgoni", httpContent);
        }

        public async Task AddClienteAsync(ClienteDTO cliente)
        {
            var httpContent = ConvertToHttpContent(cliente);
            await client.PostAsync("https://restapinoleggi.azurewebsites.net/api/clienti", httpContent);
        }

        public async Task AddNoleggioAsync(NoleggioDTO noleggio)
        {
            var httpContent = ConvertToHttpContent(noleggio);
            await client.PostAsync("https://restapinoleggi.azurewebsites.net/api/noleggi", httpContent);
        }

        #endregion

    }
}
