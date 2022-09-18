using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTask.Models
{
    public class Currency
    {
        [JsonProperty("price")]
        public decimal price { get; set; }
        [JsonProperty("volume_24h")]
        public decimal volume24h { get; set; }
        [JsonProperty("market_cap")]
        public decimal marketCap { get; set; }
        [JsonProperty("fully_diluted_market_cap")]
        public decimal fullyDilutedMarketCap { get; set; }

    }
}
