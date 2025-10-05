using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptocurrenciesInfo.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public List<string> Themes { get; } = new List<string> { "Light", "Dark" };
        public List<string> Languages { get; } = new() { "English", "Ukrainian" };

        private static string _currentTheme = "Light";
        private static string _currentLanguage = "English";

        public SettingsViewModel()
        {
            _selectedTheme = _currentTheme;
            _selectedLanguage = _currentLanguage;
        }
        private string _selectedTheme;
        public string SelectedTheme
        {
            get => _selectedTheme;
            set
            {
                if (_selectedTheme != value)
                {
                    _selectedTheme = value;
                    OnPropertyChanged();
                    ApplyTheme(_selectedTheme);
                    _currentTheme = _selectedTheme;
                }
            }
        }

        private string _selectedLanguage;
        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (_selectedLanguage != value)
                {
                    _selectedLanguage = value;
                    OnPropertyChanged();
                    ApplyLanguage(_selectedLanguage);
                    _currentLanguage = _selectedLanguage;
                }
            }
        }

        private void ApplyTheme(string theme)
        {
            var dict = new ResourceDictionary();
            switch (theme)
            {
                case "Dark":
                    dict.Source = new System.Uri("Themes/Dark.xaml", System.UriKind.Relative);
                    break;
                default:
                    dict.Source = new System.Uri("Themes/Light.xaml", System.UriKind.Relative);
                    break;
            }

            var existingTheme = Application.Current.Resources.MergedDictionaries
         .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.StartsWith("Themes/"));

            if (existingTheme != null)
            {
                int index = Application.Current.Resources.MergedDictionaries.IndexOf(existingTheme);
                Application.Current.Resources.MergedDictionaries[index] = dict;
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(dict);
            }
        }

        private void ApplyLanguage(string language)
        {
            var dict = new ResourceDictionary();
            switch (language)
            {
                case "Ukrainian":
                    dict.Source = new Uri("Resource/Resource.ua.xaml", UriKind.Relative);
                    break;
                default:
                    dict.Source = new Uri("Resource/Resource.en.xaml", UriKind.Relative);
                    break;
            }
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
