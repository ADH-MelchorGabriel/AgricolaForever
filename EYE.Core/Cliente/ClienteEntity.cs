using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("Cliente")]
    public class ClienteEntity
    {
        [Key]
        public int IdCliente { get; set; }
        [Required]
        [MaxLength(13)]
        public string RFC { get; set; }
        [MaxLength(5)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(3)]
        public string CveRecidenciaFiscal { get; set; }

        [Required]
        [StringLength(3)]
        public string CveRegimenFiscal { get; set; }

        [StringLength(10)]
        public string NumRegIdTrib { get; set; }
        [MaxLength(5)]
        public string DomicilioFiscal { get; set; }
        public bool EstaActivo { get; set; }
		public virtual List<EmbarqueEntity> Embarque { get; set; }
	}
}
