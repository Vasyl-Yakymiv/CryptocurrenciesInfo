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
    public  class MainViewModel : INotifyPropertyChanged
    {
        private readonly ICryptoRepository _cryptoRepo;

        public event PropertyChangedEventHandler? PropertyChanged;

        public IEnumerable<CryptocurrencyGeneral> _currencies;
        public IEnumerable<CryptocurrencyGeneral> Currencies 
        {
            get => _currencies;
            private set
            {
                _currencies = value;
                OnPropertyChanged(nameof(Currencies));
            }
        }

        public MainViewModel(ICryptoRepository cryptoRepo)
        {
            _cryptoRepo = cryptoRepo;
            _ = GetTopCurrencyAsync();
        }

        private async Task  GetTopCurrencyAsync()
        {
            Currencies = await _cryptoRepo.GetTopCurrenciesAsync(10);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

