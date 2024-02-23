using System.ComponentModel.DataAnnotations;

namespace EYE.Dtos
{
    public class SellosDto
    {
        [StringLength(10)]
        public string SelloPuesto { get; set; }
        [StringLength(10)]
        public string SelloRepuesto { get; set; }
    }
}
