using CryptocurrenciesInfo.Interfaces;
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

        public DetailViewModel(ICryptoRepository cryptoRepo)
        {
            _cryptoRepo = cryptoRepo;
        }

   
        public async void GetDetailOfCurrency()
        {

        }
    }
}
