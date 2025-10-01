using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptocurrenciesInfo.Models
{
    public class MarketData
    {
        [JsonPropertyName("current_price")]
        public Dictionary<string, decimal> CurrentPrice { get; set; }

        [JsonPropertyName("total_volume")]
        public Dictionary<string, decimal> TotalVolume { get; set; }

        [JsonPropertyName("price_change_percentage_24h")]
        public decimal PriceChange24h { get; set; }
    }
}
