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
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            DataContext = new SettingsViewModel();

            this.Resources.MergedDictionaries.Clear();
            foreach (var dict in Application.Current.Resources.MergedDictionaries)
                this.Resources.MergedDictionaries.Add(dict);
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
