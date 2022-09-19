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
using System.Windows;
using System.Windows.Input;

namespace CryptoTask.ViewModels
{
    public class SearchViewModel:BaseVM
    {
        private string _attributeType= string.Empty;
        private ObservableCollection<Asset> _assets;
        public string AttributeType { set; get; }


        public ICommand SelectAttribute
        {
            get
            {
                return new DelegateCommand<string>((attributeType) =>
                {
                    _attributeType = attributeType;
                });
            }
        }

        public ICommand Search
        {
            get
            {
                return new DelegateCommand<string>((value) =>
                {
                    Asset asset;
                    bool isAttributeTypeNotEmpty = false;
                    switch(_attributeType)
                    {
                        case "Id":
                            asset = _assets.FirstOrDefault(a => a.assetId == value);
                            isAttributeTypeNotEmpty = true;
                            break;
                        case "Name":
                            asset = _assets.FirstOrDefault(a => a.name == value);
                            isAttributeTypeNotEmpty = true;
                            break;
                        default:
                            asset = null;
                            break;
                    }
                    if (isAttributeTypeNotEmpty)
                    {
                        if (asset is null)
                        {
                            MessageBox.Show("Assets with current attribute value not found!", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            Commands.OpenInfoAboutAsset(asset);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Choose the search attribute!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }

    }
}
