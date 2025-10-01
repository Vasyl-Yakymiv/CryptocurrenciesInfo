using CryptocurrenciesInfo.Interfaces;
using CryptocurrenciesInfo.Models;
using CryptocurrenciesInfo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrenciesInfo.Repository
{
    internal class CryptoRepository : ICryptoRepository
    {
        private readonly IApiService _apiService;

        public CryptoRepository(IApiService apiService)
        {
          _apiService = apiService;
        }

        async Task<CryptocurrencyDetails> ICryptoRepository.GetCurrencyByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Currency id cannot be null or empty.", nameof(id));

            return await _apiService.GetCurrencyByIdAsync(id);
        }

        public async Task<IEnumerable<CryptocurrencyGeneral>> GetTopCurrenciesAsync(int amount)
        {
            var data = await _apiService.GetСryptocurrenciesAsync(amount);
            return data.ToList();
        }

        public async Task<IEnumerable<SearchCoin>> SearchCurrenciesAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("Currency query cannot be null or empty.", nameof(query));

            var data = await _apiService.SearchCurrencyAsync(query);
            return data.ToList();
        }     
    }
}
