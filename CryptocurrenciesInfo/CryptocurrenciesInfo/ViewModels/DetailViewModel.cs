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
    public class DetailViewModel : INotifyPropertyChanged
    {
        private readonly ICryptoRepository _cryptoRepo;

        public event PropertyChangedEventHandler? PropertyChanged;

        public CryptocurrencyDetails _currency;
        public CryptocurrencyDetails Currency
        {
            get => _currency;
            private set
            {
                _currency= value;
                OnPropertyChanged(nameof(Currency));
            }
        }

        public DetailViewModel(ICryptoRepository cryptoRepo)
        {
            _cryptoRepo = cryptoRepo;
        }

   
        public async void GetDetailOfCurrency(string id)
        {
            Currency = await _cryptoRepo.GetCurrencyByIdAsync(id);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
