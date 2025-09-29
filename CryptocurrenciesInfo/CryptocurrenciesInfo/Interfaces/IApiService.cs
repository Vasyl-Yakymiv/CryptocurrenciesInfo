using CryptocurrenciesInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrenciesInfo.Interfaces
{
    public interface IApiService
    {
        Task<IEnumerable<CryptocurrencyGeneral>> GetСryptocurrenciesAsync(int amount);
        Task<CryptocurrencyDetails> GetCurrencyByIdAsync(string id);
        Task<IEnumerable<CryptocurrencyDetails>> SearchCurrencyAsync(string query);
    }
}
