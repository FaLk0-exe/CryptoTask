using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoTask.Services.Helpers
{
    public static class ThemeSwitcher
    {
        private static void SwitchTheme(string uriStr)
        {
            var uri = new Uri(uriStr, UriKind.Relative);
            ResourceDictionary rd = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(rd);
        }

        public static void SwitchLightTheme()
        {
            SwitchTheme(@"Dictionaries/LightDictionary.xaml");
        }

        public static void SwitchDarkTheme()
        {
            SwitchTheme(@"Dictionaries/DarkDictionary.xaml");
        }
    }
}
