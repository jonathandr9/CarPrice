using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPrice.Domain.Models
{
    public class CarPhoto
    {
        public int IdCarPhoto { get; set; }
        public string FipeCode { get; set; }
        public int ModelYear { get; set; }
        public string PhotoBase64 { get; set; }
    }
}
