using System.ComponentModel.DataAnnotations;

namespace EYE.Dtos
{
    public class PaletCompletoDto
    {
        public PaletCompletoDto()
        {

        }

        [Required]
        public int IdEmpaque { get; set; }

        [Required]
        public int IdPaletDetalle { get; set; }

        [Required]
        public int IdTemporada { get; set; }

        [Required]
        public bool EsGaseado { get; set; }
        [Required]
        public bool EsPaletChep { get; set; }
        [Required]
        public int IdAgricultor { get; set; }
        [Required]
        public int IdLote { get; set; }
        [Required]
        public int IdProducto { get; set; }
        [Required]
        public int Cantidad { get; set; }
    }
}
