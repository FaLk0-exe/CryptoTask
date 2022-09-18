using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTask.Models
{
    public class Quote
    {
        [JsonProperty("AUD")]
        public Currency AUD { get; set; }
        [JsonProperty("JPY")]
        public Currency JPY { get; set; }
        [JsonProperty("GBP")]
        public Currency GBP { get; set; }
        [JsonProperty("CAD")]
        public Currency CAD { get; set; }
        [JsonProperty("USD")]
        public Currency USD { get; set; }
        [JsonProperty("NZD")]
        public Currency NZD { get; set; }
        [JsonProperty("EUR")]
        public Currency EUR { get; set; }

    }
}
