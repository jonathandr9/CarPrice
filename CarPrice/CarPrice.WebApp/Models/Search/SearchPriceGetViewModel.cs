using System.Collections.Generic;

namespace CarPrice.WebApp.Models.Search
{
    public class SearchPriceGetViewModel
    {
        public string CurrentPrice { get; set; }
        public string AveragePrice { get; set; }
        public IEnumerable<PriceVariationChartDto> PriceVariationChart { get; set; }
    }
}
