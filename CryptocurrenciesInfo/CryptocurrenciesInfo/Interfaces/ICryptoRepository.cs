using CryptocurrenciesInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CryptocurrenciesInfo.Interfaces
{
    public interface ICryptoRepository
    {
        Task<IEnumerable<CryptocurrencyGeneral>> GetTopCurrenciesAsync(int amount);
        Task<CryptocurrencyDetails> GetCurrencyByIdAsync(string id);
        Task<IEnumerable<SearchCoin>> SearchCurrenciesAsync(string query);
        Task<decimal?> CureencyConvertorAsync(string currencyFromId, string currencyToId, decimal amount);
    }
}
