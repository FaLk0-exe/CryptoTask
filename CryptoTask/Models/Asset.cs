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
        [JsonProperty("quote")]
        public Quote quote { get; set; }
        [JsonProperty("asset_id")]
        public string assetId { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("website")]
        public string website { get; set; }
        [JsonProperty("ethereum_contract_address")]
        public string ethereumContractAddress { get; set; }
        [JsonProperty("pegged")]
        public string pegged { get; set; }
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
        [JsonProperty("total_supply")]
        public decimal totalSupply { get; set; }
        [JsonProperty("circulating_supply")]
        public decimal circulatingSupply { get; set; }
        [JsonProperty("max_supply")]
        public decimal maxSupply { get; set; }
        [JsonProperty("market_cap")]
        public decimal marketCap { get; set; }
        [JsonProperty("fully_diluted_market_cap")]
        public decimal fullyDilutedMarketCap { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("created_at")]
        public DateTime createdAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime updatedAt { get; set; }

    }
}
