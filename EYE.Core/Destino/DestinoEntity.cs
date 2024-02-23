using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("Destino")]

    public class DestinoEntity
    {
        [Key]
        public int IdDestino { get; set; }

        [StringLength(30)]
        public string Nombre { get; set; }


        [MaxLength(100)]
        [Required]
        public string Calle { get; set; }
        [MaxLength(5)]
        public string NumeroExterior { get; set; }
        public string Localidad { get; set; }
        public string Municipio { get; set; }

        [Required]
        [StringLength(3)]
        public string CvePais { get; set; }
        [Required]
        [StringLength(3)]
        public string CveEstado { get; set; }


        [Required]
        [MaxLength(5)]
        public string CodigoPostal { get; set; }
        public bool EstaActivo { get; set; }

        [NotMapped]
        public string Direccion { get { return Calle + ", No." + NumeroExterior + ", " + Localidad + ", " + Municipio + ", " + CveEstado + ", " + CvePais + ", CP:" + CodigoPostal; } }

        public virtual List<EmbarqueEntity> Embarque { get; set; }

    }
}
