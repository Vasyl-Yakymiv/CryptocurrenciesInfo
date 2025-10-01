using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace CryptocurrenciesInfo.Models
{
    public class CryptocurrencyDetails
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Title { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("market_data")]
        public MarketData MarketData { get; set; }

        public decimal Price => MarketData?.CurrentPrice != null && MarketData.CurrentPrice.ContainsKey("usd") ? MarketData.CurrentPrice["usd"] : 0;
        public decimal Volume24h => MarketData?.TotalVolume != null && MarketData.TotalVolume.ContainsKey("usd") ? MarketData.TotalVolume["usd"]: 0;
        public decimal PriceChange24h => MarketData?.PriceChange24h ?? 0;
    }
}
