using CryptoTask.Models;
using CryptoTask.Services.Parsers;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
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
        public string WebSiteHeader { get { return asset.website == ""||asset.website==null ? "" : "Website:"; } }
        List<Market> _markets;
        public List<Market> Markets { set; get; }
        public AssetDetailsViewModel()
        {
            asset = new Asset();
            Markets = OpenApiJsonParser.ParseMarkets($"https://cryptingup.com/api/assets/{asset.assetId}/markets");
        }

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
