using CryptoTask.Models;
using CryptoTask.Services.Parsers;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CryptoTask.ViewModels
{
    public class AssetDetailsViewModel:BaseVM
    {
        public Asset asset { set; get; }
        private ObservableCollection<string> marketsInfo;
        public ObservableCollection<string> MarketInfo { set { marketsInfo = value; }
            get { return marketsInfo; } }
        public AssetDetailsViewModel() { }

        public ICommand NavigateToWebSite
        {
            get
            {
                return new DelegateCommand(() => {
                    if(asset.website!="")
                        Process.Start(asset.website);
                    else
                        MessageBox.Show("This asset doesn't have website!","Information",MessageBoxButton.OK,MessageBoxImage.Information);
                });
            }
        }
    }
}
