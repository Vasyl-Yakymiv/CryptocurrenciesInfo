using CryptocurrenciesInfo.Interfaces;
using CryptocurrenciesInfo.Repository;
using CryptocurrenciesInfo.Services;
using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Windows;

namespace CryptocurrenciesInfo
{
    public partial class App : Application
    {
        public static IApiService ApiService { get; private set; }
        public static ICryptoRepository CryptoRepository { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.coingecko.com/api/v3/")
            };
            ApiService = new ApiService(httpClient);
            CryptoRepository = new CryptoRepository(ApiService);
        }
    }

}
