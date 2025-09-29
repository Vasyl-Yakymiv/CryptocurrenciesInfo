using CryptocurrenciesInfo.Interfaces;
using CryptocurrenciesInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptocurrenciesInfo.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CryptocurrencyDetails> GetCurrencyByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"coins/{id}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();  

            return JsonSerializer.Deserialize<CryptocurrencyDetails>(json);
        }

        public async Task<IEnumerable<CryptocurrencyGeneral>> GetСryptocurrenciesAsync(int amount)
        {
            var response = await _httpClient.GetAsync($"coins/markets?vs_currency=usd&order=market_cap_desc&per_page={amount}&page=1");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<CryptocurrencyGeneral>>(json);
        }

        public async Task<IEnumerable<CryptocurrencyDetails>> SearchCurrencyAsync(string query)
        {
            var response = await _httpClient.GetAsync($"search?query={query}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<CryptocurrencyDetails>>(json);
        }
    }
}
