using CryptoTask.Models;
using CryptoTask.Services.Helpers;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoTask.ViewModels
{
    public class SettingsViewModel:BaseVM
    {
        public ICommand ChangeTheme
        {
            get
            {
                return new DelegateCommand<string>(
                    (theme) =>
                    {
                        if (theme == "Dark")
                            ThemeSwitcher.SwitchDarkTheme();
                        if(theme=="Light")
                            ThemeSwitcher.SwitchLightTheme();
                    });
            }
        }
    }
}
