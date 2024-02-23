using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("PaletDetalle")]
    public class PaletDetalleEntity
    {
        [Key]
        public int IdPaletDetalle { get; set; }
        [Required]
        public int IdPalet { get; set; }
        [Required]
        public int IdAgricultor { get; set; }
        [Required]
        public int IdLote { get; set; }
        [Required]
        public int IdProducto { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public bool EstaAcivo { get; set; }

        [ForeignKey("IdPalet")]
        public virtual PaletEntity Palet { get; set; }
        [ForeignKey("IdAgricultor")]

        public virtual AgricultorEntity Agricultor { get; set; }
        [ForeignKey("IdLote")]
        public virtual LoteEntity Lote { get; set; }
        [ForeignKey("IdProducto")]
        public virtual ProductoEntity Producto { get; set; }

    }
}

