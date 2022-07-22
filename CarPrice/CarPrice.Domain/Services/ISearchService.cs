using CarPrice.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarPrice.Domain.Services
{
    public interface ISearchService
    {
        Task<IEnumerable<CarPrices>> SearchPricesByFipeCode(string fipeCode, int year);
        Task<CarPhoto> SearchPhotoByFipeCode(string fipeCode, int year);
        Task AddCarPhoto(CarPhoto carPhoto);
    }
}
