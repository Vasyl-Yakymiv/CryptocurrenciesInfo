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
    }
}