using ClienteBasico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ClienteBasico
{

    public class CurrencyApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://api.freecurrencyapi.com/v1/latest?apikey=fca_live_a9uasdP6yjM3v5UY4hLLHtXmW2CsvhCO4OSTfOpz&base_currency=EUR"; // Replace with your API's base URL

        public CurrencyApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CurrencyData>> GetCurrenciesAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<CurrencyData>(json);
            return new List<CurrencyData> { apiResponse };
        }

    }
}
