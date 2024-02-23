using System.ComponentModel.DataAnnotations;

namespace EYE.Dtos
{
    public class EmbarqueDetalleDto
    {

        public EmbarqueDetalleDto()
        {

        }
        public int IdEmbarqueDetalle { get; set; }
        [Required]
        public int IdPalet { get; set; }
        [Required]
        public int Posicion { get; set; }
    }
}
