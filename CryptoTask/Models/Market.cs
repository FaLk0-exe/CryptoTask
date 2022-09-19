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
    }
}
