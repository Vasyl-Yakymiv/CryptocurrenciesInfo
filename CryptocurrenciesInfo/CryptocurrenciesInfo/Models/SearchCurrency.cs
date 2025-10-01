using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptocurrenciesInfo.Models
{
    public class SearchCurrency
    {
        [JsonPropertyName("coins")]
        public List<SearchCoin> Coins { get; set; }
    }

   
}
