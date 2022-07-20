using CarPrice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPrice.Domain.Adapters
{
    public interface IBrasilApiAdapter
    {
        Task<IEnumerable<CarPrices>> SearchPrices(
            string fipeCode,
            int referenceTable);
    }
}
