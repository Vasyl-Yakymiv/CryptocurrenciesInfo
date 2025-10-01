using CryptocurrenciesInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrenciesInfo.Interfaces
{
    public interface ICryptoRepository
    {
        Task<IEnumerable<CryptocurrencyGeneral>> GetTopCurrenciesAsync(int amount);
        Task<CryptocurrencyDetails> GetCurrencyByIdAsync(string id);
        Task<IEnumerable<SearchCoin>> SearchCurrenciesAsync(string query);
    }
}
