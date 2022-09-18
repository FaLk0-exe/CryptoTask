﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTask.Models
{
    [Serializable]
    public class Asset
    {

        [JsonProperty("asset_id")]
        public string assetId { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }

        private string _website;

        [JsonProperty("website")]
        public string website { 
            get
            {
                return _website == "" ? "no" : _website;
            }
            set
            {
                _website = value;
            }
        }

        [JsonProperty("price")]
        public decimal price { get; set; }
        [JsonProperty("volume_24h")]
        public decimal volume24h { get; set; }
        [JsonProperty("change_1h")]
        public decimal change1h { get; set; }
        [JsonProperty("change_24h")]
        public decimal change24h { get; set; }
        [JsonProperty("change_7d")]
        public decimal change7d { get; set; }


    }
}
