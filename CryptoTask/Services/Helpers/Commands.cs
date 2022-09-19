using CryptoTask.Models;
using CryptoTask.Services.Parsers;
using CryptoTask.ViewModels;
using CryptoTask.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTask.Services.Helpers
{
    public static class Commands
    {
        public static void OpenInfoAboutAsset(Asset obj)
        {
            if (obj != null)
            {
                var viewModel = new AssetDetailsViewModel
                {
                    asset = obj,
                    MarketInfo = new ObservableCollection<string>
                    (OpenApiJsonParser.ParseMarkets
                    ($"https://cryptingup.com/api/assets/{obj.assetId}/markets")
                    .Select(m => m.InformationLine).ToList())
                };
                AssetDetailsWindow view = new AssetDetailsWindow();
                view.DataContext = viewModel;
                view.ShowDialog();
            }
        }
    }
}
