using System.ComponentModel.DataAnnotations;

namespace BrasilApiAdapter
{
    public class BrasilApiAdapterConfiguration
    {
        [Required]
        public string ApiUrlBase { get; set; }
    }
}
