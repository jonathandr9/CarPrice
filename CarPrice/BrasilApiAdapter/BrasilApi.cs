using AutoMapper;
using BrasilApiAdapter.Clients;
using CarPrice.Domain.Adapters;
using CarPrice.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrasilApiAdapter
{
    public class BrasilApi : IBrasilApiAdapter
    {
        private readonly IBrasilApiClient _brasilApi;
        private readonly IMapper _mapper;
        private readonly BrasilApiAdapterConfiguration _brasilApiConfiguration;

        public BrasilApi(IBrasilApiClient brasilApi,
            IMapper mapper,
            BrasilApiAdapterConfiguration brasilApiConfiguration)
        {
            _brasilApi = brasilApi;
            _mapper = mapper;
            _brasilApiConfiguration = brasilApiConfiguration;
        }

        public async Task<IEnumerable<CarPrices>> SearchPrices(
            string fipeCode,
            int referenceTable)
        {
            var response = await _brasilApi
                .SearchPriceGetAsync(fipeCode, referenceTable);

            return _mapper.Map<IEnumerable<CarPrices>>(response);
        }
    }
}

