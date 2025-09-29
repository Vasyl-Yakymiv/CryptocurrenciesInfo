using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrenciesInfo.Models
{
    public class CryptocurrencyDetails
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Symbol { get; set; }
        public decimal Volume24h { get; set; }
        public decimal PriceChange24h { get; set; }
    }
}
