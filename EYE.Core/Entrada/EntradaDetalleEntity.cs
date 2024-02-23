using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("EntradaDetalle")]
    public class EntradaDetalleEntity
    {

        [Key]
        public int IdEntradaDetalle { get; set; }
        [Required]      
        public int IdEntrada { get; set; }
        [Required]
        public int IdArticulo { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double Cantidad { get; set; }
        [Required]
        [Range(0,double.MaxValue)]
        public double Costo { get; set; }

        public bool EstaActivo { get; set; }

        [ForeignKey("IdEntrada")]
        public virtual EntradaEntity  Entrada{ get; set; }

        [ForeignKey("IdArticulo")]
        public virtual ArticuloEntity Articulo { get; set; }

    }
}
