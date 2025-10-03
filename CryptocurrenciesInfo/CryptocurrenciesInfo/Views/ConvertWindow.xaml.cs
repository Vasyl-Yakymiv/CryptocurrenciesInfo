using CryptocurrenciesInfo.Interfaces;
using CryptocurrenciesInfo.Models;
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
    public partial class ConvertWindow : Window
    {
        private readonly ConvertViewModel _convertViewModel;

        public ConvertWindow(ICryptoRepository cryptoRepo)
        {
            InitializeComponent();
            _convertViewModel = new ConvertViewModel(cryptoRepo);
            Loaded += async (s, e) =>
            {
                var currencies = await cryptoRepo.GetTopCurrenciesAsync(100);

                CurrencyFrom.ItemsSource = currencies.ToList();
                CurrencyTo.ItemsSource = currencies.ToList();
            };
        }

        private async void Convert_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrencyFrom.SelectedItem is CryptocurrencyGeneral from && CurrencyTo.SelectedItem is CryptocurrencyGeneral to && decimal.TryParse(Amount.Text, out decimal amount))
            {
                var result = await _convertViewModel.ConvertCurrencyAsync(from.Id, to.Id, amount);
                Result.Text = result?.ToString("0.##") ?? "Error";
            }
            else
            {
                MessageBox.Show("Select currencies and enter a valid number for Amount.");
            }

        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
