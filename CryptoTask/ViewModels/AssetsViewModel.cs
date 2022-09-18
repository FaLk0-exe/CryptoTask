using CryptoTask.Models;
using CryptoTask.Services.Helpers;
using CryptoTask.Services.Parsers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CryptoTask.ViewModels
{
    public class AssetsViewModel : BaseVM
    {
        private readonly string _assetsRequest = @"https://cryptingup.com/api/assets";
        public ObservableCollection<Asset> Assets { get; private set; }

        private DispatcherTimer _timer;

        public AssetsViewModel()
        {
            Assets = new ObservableCollection<Asset>(OpenApiJsonParser.ParseAssets(_assetsRequest).Result);
            StartTimer();
        }

        private void StartTimer()
        {
            _timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 3)
            };
            _timer.Tick += new EventHandler(Tick);
            _timer.Start();
        }

        private void Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        public void Refresh()
        {
            if (ConnectionChecker.OK())
            {
                Assets.Clear();
                var assets = new ObservableCollection<Asset>(OpenApiJsonParser.ParseAssets(_assetsRequest).Result.OrderByDescending(a => a.price));
                foreach (var a in assets)
                    Assets.Add(a);
            }

        }
    }
}
