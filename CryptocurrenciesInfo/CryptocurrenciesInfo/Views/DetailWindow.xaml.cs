using CryptocurrenciesInfo.Interfaces;
using CryptocurrenciesInfo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CryptocurrenciesInfo.Views
{
    public partial class DetailWindow : Window
    {
        private readonly DetailViewModel _detailViewModel;
        public DetailWindow(ICryptoRepository cryptoRepo, string id)
        {
            InitializeComponent();
            _detailViewModel = new DetailViewModel(cryptoRepo);
            DataContext = _detailViewModel;
            _detailViewModel.GetDetailOfCurrency(id);
        }
    }
}
