using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("LineaTransporte")]
    public class LineaTransporteEntity
    {
        [Key]
        public int IdLineaTransporte { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(11)]
        public string Telefono { get; set; }// los telefonos son string de 10 digitos
        public bool EstaActivo { get; set; }    

        public virtual List<RemolqueEntity> Remolques { get; set;}
        public virtual List <ChoferEntity> Choferes { get; set; }
        public virtual List<VehiculoEntity> Vehiculos { get; set; }
    }
}

