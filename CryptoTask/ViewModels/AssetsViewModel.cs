using CryptoTask.Models;
using CryptoTask.Services.Helpers;
using CryptoTask.Services.Parsers;
using CryptoTask.Views;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace CryptoTask.ViewModels
{
    public class AssetsViewModel : BaseVM
    {
        private Asset _selectedItem;
        private readonly string _assetsRequest = @"https://cryptingup.com/api/assets";
        private ObservableCollection<Asset> _assets;

        public ObservableCollection<Asset> Assets { get { return new ObservableCollection<Asset>(_assets.Take(10).OrderByDescending(a => a.price).ToList()); }
            private set { _assets = value; } }

        private DispatcherTimer _timer;

        public Asset SelectedItem { 
            set { _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
            get => _selectedItem;
        }

        public AssetsViewModel()
        {
            Assets = GetTop10Assets();
            StartTimer();
        }

        private void StartTimer()
        {
            _timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 20)
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
            if (ConnectionChecker.OK())
            {
                return new ObservableCollection<Asset>(OpenApiJsonParser.ParseAssets(_assetsRequest));
            }
            else
            {
                return new ObservableCollection<Asset>();
            }
        }

        public ICommand NavigateToDetailsWindow
        {
            get
            {
                return new DelegateCommand<Asset>((obj) =>
                {
                    Commands.OpenInfoAboutAsset(obj);
                });
            }
        }

        public ICommand NavigateToSearch
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var viewModel = new SearchViewModel { Assets = _assets };
                    var view = new SearchWindow();
                    view.DataContext = viewModel;
                    view.ShowDialog();
                });
            }
        }
    }
}
