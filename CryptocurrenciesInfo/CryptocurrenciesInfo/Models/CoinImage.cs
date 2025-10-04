using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptocurrenciesInfo.Models
{
    public class CoinImage
    {
        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }

        [JsonPropertyName("small")]
        public string Small { get; set; }

        [JsonPropertyName("large")]
        public string Large { get; set; }
    }
}
