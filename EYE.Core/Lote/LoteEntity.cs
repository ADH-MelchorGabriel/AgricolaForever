using EYE.Enumeradores;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EYE.Entidades
{
    [Table("Lote")]
    public class LoteEntity
    {
        [Key]
        public int IdLote { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(2)]
        public string Codigo { get; set; }// el codigo es string de 2 digitos estaba int


        [Required]
        [StringLength(40)]
        public string MunicipioProductor { get; set; }

        [Required]
        [StringLength(80)]
        public string UbicacionPredio { get; set; }

        [Required]
        public SectorEnum Sector { get; set; }


        public bool EstaActivo { get; set; }
        public virtual List<PaletDetalleEntity> PaletDetalle { get; set; }
    }
}
