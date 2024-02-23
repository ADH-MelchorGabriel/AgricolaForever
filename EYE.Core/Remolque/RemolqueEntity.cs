using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("Remolque")]
    public class RemolqueEntity
    {

        [Key]
        public int IdRemolque { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descripcion { get; set; }
        [Required]
        public int Año { get; set; }
        [Required]
        public string Placas { get; set; }
        
        [Required]
        public int IdLineaTransporte { get; set; }
        public bool EstaActivo { get; set; }

        [ForeignKey("IdLineaTransporte")]
        public virtual LineaTransporteEntity LineaTransportes { get; set;}
		public virtual List<EmbarqueEntity> Embarque { get; set; }

	}
}
