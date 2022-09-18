using CryptoTask.Models;
using CryptoTask.Services.Helpers;
using CryptoTask.Services.Parsers;
using DevExpress.Mvvm;
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
        private ObservableCollection<Asset> _assets;
        public ObservableCollection<Asset> Assets { get { return _assets; }
            private set { _assets = value; } }

        private DispatcherTimer _timer;

        public AssetsViewModel()
        {
            Assets = GetTop10Assets();
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
                var assets = GetTop10Assets();
                foreach (var a in assets)
                    Assets.Add(a);
            }

        }

        private ObservableCollection<Asset> GetTop10Assets()
        {
            return new ObservableCollection<Asset>(OpenApiJsonParser.ParseAssets(_assetsRequest).Take(10).OrderByDescending(a => a.price));
        }

        ICommand NavigateToDetailsWindow
        {
            get
            {
                return new DelegateCommand()=>{

                }
            }
        }
    }
}
