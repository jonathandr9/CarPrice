using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPrice.Domain.Models
{
    public class CarPrices
    {
        public string price { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public int modelYear { get; set; }
        public string fuel { get; set; }
        public string codigoFipe { get; set; }
        public string referenceMonth { get; set; }
        public int vehicleType { get; set; }
        public string acronymFuel { get; set; }
        public string consultationDate { get; set; }
    }
}
