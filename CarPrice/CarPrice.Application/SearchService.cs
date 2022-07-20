using CarPrice.Domain.Adapters;
using CarPrice.Domain.Models;
using CarPrice.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPrice.Application
{
    public class SearchService : ISearchService
    {
        private readonly IBrasilApiAdapter _brasilApiAdapter;

        public SearchService(IBrasilApiAdapter brasilApiAdapter)
        {
            _brasilApiAdapter = brasilApiAdapter;
        }

        public async Task<IEnumerable<CarPrices>> SearchPricesByFipeCode(
            string fipeCode,
            int year)
        {
            var prices = new List<CarPrices>();

            foreach (var monthYear in Enum.GetValues(typeof(EnumReferenceTables)))
            {
                var priceOfAllYears = await _brasilApiAdapter.SearchPrices(
                    fipeCode, (int)monthYear);

                var priceofYear = priceOfAllYears.FirstOrDefault(
                    p => p.modelYear == year);

                prices.Add(priceofYear);
            }

            return prices;
        }
    }
}
