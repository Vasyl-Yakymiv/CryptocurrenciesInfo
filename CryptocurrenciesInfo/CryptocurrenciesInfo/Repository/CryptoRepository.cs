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
        private List<CryptocurrencyGeneral>? _cryptosCache;

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

        private async Task EnsureInitializedAsync()
        {
            if (_cryptosCache == null)
            {
                var list = await _apiService.GetСryptocurrenciesAsync(100);
                _cryptosCache = list.ToList();
            }
        }

        public async Task<decimal?> CureencyConvertorAsync(string currencyFromName, string currencyToName, decimal amount)
        {
            await EnsureInitializedAsync();

            var currencyFrom = _cryptosCache!
                .FirstOrDefault(c => string.Equals(c.Id, currencyFromName, StringComparison.OrdinalIgnoreCase) || string.Equals(c.Symbol, currencyFromName, StringComparison.OrdinalIgnoreCase));

            var currencyTo = _cryptosCache!
                .FirstOrDefault(c => string.Equals(c.Id, currencyToName, StringComparison.OrdinalIgnoreCase) || string.Equals(c.Symbol, currencyToName, StringComparison.OrdinalIgnoreCase));

            var total = amount * currencyFrom.Price;
            return total / currencyTo.Price;
        }
    }
}
