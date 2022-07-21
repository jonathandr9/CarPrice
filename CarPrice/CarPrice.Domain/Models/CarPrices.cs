using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPrice.Domain.Models
{
    public class CarPrices
    {
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string Fuel { get; set; }
        public string CodigoFipe { get; set; }
        public string ReferenceMonth { get; set; }
        public int VehicleType { get; set; }
        public string AcronymFuel { get; set; }
        public string ConsultationDate { get; set; }
    }
}
