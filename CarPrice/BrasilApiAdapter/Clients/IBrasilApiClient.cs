using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrasilApiAdapter.Clients
{
    public interface IBrasilApiClient
    {
        /// <summary>
        ///     Consult vehicle price by fipe
        /// </summary>
        /// <param name="codigoFipe">
        ///     Fipe Code
        /// </param>
        /// <param name="tabela_referencia">
        ///     Integer representing the lookup table (month/year).
        /// </param>
        /// <returns>
        ///     Returns vehicle prices by year of manufacture.
        /// </returns>        
        [Get("/fipe/preco/v1/{codigoFipe}")]
        Task<IEnumerable<SearchPriceGetResult>> SearchPriceGetAsync(
            string codigoFipe,
            int tabela_referencia);

    }
}
