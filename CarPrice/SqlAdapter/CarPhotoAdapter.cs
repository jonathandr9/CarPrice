using CarPrice.Domain.Adapters;
using CarPrice.Domain.Models;
using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;

namespace CarPrice.SqlAdapter
{
    public class CarPhotoAdapter : ICarPhotoAdapter
    {

        private readonly SqlAdapterContext _context;

        static CarPhotoAdapter() =>
            SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);

        public CarPhotoAdapter(SqlAdapterContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task AddCarPhoto(CarPhoto carPhoto)
        {
            await _context.Connection.ExecuteAsync(
                        @"INSERT INTO [dbo].[CarPhoto] 
                            (FipeCode,
                             PhotoBase64,
                             ModelYear) 
                          VALUES 
                             (@FipeCode, 
                              @PhotoBase64,
                              @ModelYear)",
                        carPhoto,
                        commandType: CommandType.Text);
        }

        public async Task<CarPhoto> GetCarPhotoByFipeCode(string fipeCode,
            int year)
        {
            return await _context.Connection.QueryFirstOrDefaultAsync<CarPhoto>(
                        @"SELECT IdCarPhoto,
                                 FipeCode, 
                                 PhotoBase64,
                                 ModelYear
                          FROM CarPhoto WITH (NOLOCK)
                          WHERE FipeCode = @FipeCode
                          AND ModelYear = @ModelYear",
                        param: new { FipeCode = fipeCode, ModelYear = year},
                        commandType: CommandType.Text);
        }

    }
}
