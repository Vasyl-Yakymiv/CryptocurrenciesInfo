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
    public partial class SearchWindow : Window
    {

        private readonly SearchViewModel _searchViewModel;
        public SearchWindow(ICryptoRepository cryptoRepo)
        {
            InitializeComponent();
            _searchViewModel = new SearchViewModel(cryptoRepo);
            DataContext = _searchViewModel;
        }

        private async void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            var query = SearchTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(query))
               await _searchViewModel.GetResultOfSearch(query);
            else
                MessageBox.Show("Please enter a currency name or code.");
        }

        private void Open_Details_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is string id)
            {
                var deatil = new DetailWindow(App.CryptoRepository, id);
                deatil.Show();
            }
        }
    }
}
