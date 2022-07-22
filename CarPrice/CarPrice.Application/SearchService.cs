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
        private readonly ICarPhotoAdapter _carPhotoAdapter;

        public SearchService(IBrasilApiAdapter brasilApiAdapter,
             ICarPhotoAdapter carPhotoAdapter)
        {
            _brasilApiAdapter = brasilApiAdapter;
            _carPhotoAdapter = carPhotoAdapter;
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
                    p => p.ModelYear == year);

                prices.Add(priceofYear);
            }

            return prices;
        }

        public async Task<CarPhoto> SearchPhotoByFipeCode(string fipeCode,
            int year)
        {
            return await _carPhotoAdapter.GetCarPhotoByFipeCode(fipeCode,
                year);
        }

        public async Task AddCarPhoto(CarPhoto carPhoto)
        {
            _carPhotoAdapter.AddCarPhoto(carPhoto);
        }
    }
}
