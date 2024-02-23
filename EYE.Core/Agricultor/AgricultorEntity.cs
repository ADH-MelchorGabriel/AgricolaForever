using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("Agricultor")]
    public class AgricultorEntity
    {
        [Key]
        public int IdAgricultor { get; set; }
        [Required]
        [StringLength(90)]
        public string Nombre { get; set; }

        [MaxLength(2)]
        public string Codigo { get; set; }// el codigo es string de dos digitos y estaba int
        public bool EstaActivo { get; set; }
		public virtual List<PaletDetalleEntity> PaletDetalle { get; set; }
	}
}
