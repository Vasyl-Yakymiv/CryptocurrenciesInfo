using CryptocurrenciesInfo.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrenciesInfo.ViewModels
{
    public class ConvertViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly ICryptoRepository _cryptoRepo;
        public ConvertViewModel(ICryptoRepository cryptoRepo)
        {
            _cryptoRepo = cryptoRepo;
        }

        private decimal? _result;
        public decimal? Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public async Task<decimal?> ConvertCurrencyAsync(string currencyFromId, string currencyToId, decimal amount)
        {
            Result = await _cryptoRepo.CureencyConvertorAsync(currencyFromId, currencyToId, amount);
            return Result;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
