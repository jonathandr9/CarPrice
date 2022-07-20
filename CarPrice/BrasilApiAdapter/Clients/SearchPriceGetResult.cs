using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasilApiAdapter.Clients
{
    public class SearchPriceGetResult
    {
        public string valor { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public int anoModelo { get; set; }
        public string combustivel { get; set; }
        public string codigoFipe { get; set; }
        public string mesReferencia { get; set; }
        public int tipoVeiculo { get; set; }
        public string siglaCombustivel { get; set; }
        public string dataConsulta { get; set; }
    }
}
