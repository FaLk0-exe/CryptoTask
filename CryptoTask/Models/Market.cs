using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTask.Models
{
    public class Market
    {
        [JsonProperty("exchange_id")]
        public string exchangeId { get; set; }
        [JsonProperty("price_unconverted")]
        public decimal priceUnconverted { get; set; }
        [JsonProperty("price")]
        public decimal price { get; set; }

        public string InformationLine { 
            get {
                return exchangeId + " - " +
                    priceUnconverted.ToString() +
                    "/" + price.ToString();
            } 
        }
    }
}
