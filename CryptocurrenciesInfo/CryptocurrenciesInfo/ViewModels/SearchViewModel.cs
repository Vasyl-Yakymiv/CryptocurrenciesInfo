using CryptocurrenciesInfo.Interfaces;
using CryptocurrenciesInfo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrenciesInfo.ViewModels
{
    public class SearchViewModel : INotifyPropertyChanged
    {

        private readonly ICryptoRepository _cryptoRepo;
        public event PropertyChangedEventHandler? PropertyChanged;

        public IEnumerable<SearchCoin> _currencies;
        public IEnumerable<SearchCoin> Currencies
        {
            get => _currencies;
            private set
            {
                _currencies = value;
                OnPropertyChanged(nameof(Currencies));
            }
        }

        public SearchViewModel(ICryptoRepository cryptoRepo)
        {
            _cryptoRepo = cryptoRepo;  
        }

        public async Task GetResultOfSearch(string query)
        {
            Currencies = await _cryptoRepo.SearchCurrenciesAsync(query);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
