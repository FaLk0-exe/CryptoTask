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
        public ObservableCollection<Asset> Assets { get; set; }
        private string _value;
        public string Value { set { _value = value; }
            get { return _value; } }
        public string AttributeType { set { _attributeType = value; }
                get{ return _attributeType; } }


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
                return new DelegateCommand(() =>
                {
                    Asset asset;
                    bool isAttributeTypeNotEmpty = false;
                    switch(_attributeType)
                    {
                        case "Id":
                            asset = Assets.FirstOrDefault(a => a.assetId == Value);
                            isAttributeTypeNotEmpty = true;
                            break;
                        case "Name":
                            asset = Assets.FirstOrDefault(a => a.name == Value);
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
