using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("Empresa")]
    public class EmpresaEntity
    {
        [Key]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(13)]
        public string RFC { get; set; }

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


        [Required]
        [StringLength(3)]
        public string CveRegimenFiscal{ get; set; }


    }
}
