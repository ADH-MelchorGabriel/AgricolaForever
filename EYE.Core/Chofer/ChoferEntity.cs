using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("Choferes")]
    public class ChoferEntity
    {
        [Key]

        public int IdChofer { get; set; }
        [Required]
        [StringLength(90)]
        public string Nombre { get; set; }

        [MaxLength(11)]
        public string Telefono { get; set; }
        public int IdLineaTransporte { get; set; }
        public bool EstaActivo { get; set; }
        [ForeignKey("IdLineaTransporte")]
        public virtual LineaTransporteEntity LineaTransportes { get; set; }
		public virtual List<EmbarqueEntity> Embarque { get; set; }

	}
}
