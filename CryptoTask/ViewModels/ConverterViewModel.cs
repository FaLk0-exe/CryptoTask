using CryptoTask.Models;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CryptoTask.ViewModels
{
    public class ConverterViewModel : BaseVM
    {
        public ObservableCollection<Asset> Assets { set; get; }
        public string FirstValue { set; get; }
        public string SecondValue { set; get; }
        public Asset FirstSelectedItem { set; get; }
        public Asset SecondSelectedItem { set; get; }
        private readonly char[] _requiredChars = new char[] {'1','2','3','4','5','6','7','8'
        ,'9','0','.'};
       
        public ICommand ValidateText
        {
            get
            {
                return new DelegateCommand<string>(
                    (str) =>
                    {
                        if (!_requiredChars.Any(c => c == str[str.Length - 1]))
                        {
                            str = str.Remove(str.Length - 1);
                        }

                    });
            }
        }

        public ICommand ConvertCurrency
        {
            get
            {
                return new DelegateCommand(
                   () =>
                   {
                        if(FirstSelectedItem!=null&&SecondSelectedItem!=null)
                        {
                           decimal crossCourse = FirstSelectedItem.price / SecondSelectedItem.price;
                           try
                           {
                               SecondValue = (Convert.ToDecimal(FirstValue) * crossCourse).ToString();
                               OnPropertyChanged("SecondValue");
                           }
                           catch
                           {
                               MessageBox.Show("Enter correct value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                           }
                        }
                        else
                       {
                           MessageBox.Show("Select all currencies for convertation!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                       }
                   });
            }
        }
    }
}
