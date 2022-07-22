using CarPrice.Domain.Models;
using System.Threading.Tasks;

namespace CarPrice.Domain.Adapters
{
    public interface ICarPhotoAdapter
    {
        Task AddCarPhoto(CarPhoto carPhoto);
        Task<CarPhoto> GetCarPhotoByFipeCode(string fipeCode, int year);
    }
}
