using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("Vehiculos")]
    public class VehiculoEntity
    {
        [Key]
        public int IdVehiculo { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        [Required]        
        public int Año { get; set; }

        [Required]
        [StringLength(10)]
        public string Placas { get; set; }

        [StringLength(30)]
        public string Apodo { get; set; }

        [Required]
        public int IdLineaTransporte { get; set; }
        public bool EstaActivo { get; set; }
        
        [ForeignKey("IdLineaTransporte")]
        public virtual LineaTransporteEntity LineaTransporte { get; set; }
		public virtual List<EmbarqueEntity> Embarque { get; set; }
	}
}
