using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptocurrenciesInfo.Models
{
    public class CryptocurrencyGeneral
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Title { get; set; }
        [JsonPropertyName("current_price")]
        public decimal Price { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
    }
}
