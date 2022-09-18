using CryptoTask.Models;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTask.ViewModels
{
    public class AssetDetailsViewModel:BaseVM
    {
        public Asset asset { set; get; }
    }
}
