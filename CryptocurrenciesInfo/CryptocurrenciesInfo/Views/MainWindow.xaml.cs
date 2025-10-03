using CryptocurrenciesInfo.Interfaces;
using CryptocurrenciesInfo.Repository;
using CryptocurrenciesInfo.Services;
using CryptocurrenciesInfo.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptocurrenciesInfo.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel(App.CryptoRepository);
        }

        private void Open_Details_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is string id)
            {
                var deatil = new DetailWindow(App.CryptoRepository, id);
                deatil.Show();
            }
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            var search = new SearchWindow(App.CryptoRepository);
            search.Show();
        }

        private void Convert_Button_Click(object sender, RoutedEventArgs e)
        {
            var convert = new ConvertWindow(App.CryptoRepository);
            convert.Show();
            this.Hide();
        }

        private void Settings_Button_Click(object sender, RoutedEventArgs e)
        {
            var settings = new SettingsWindow();
            settings.Show();
        }
    }
}