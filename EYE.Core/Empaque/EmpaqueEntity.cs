using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("Empaque")]
    public class EmpaqueEntity
    {
        [Key]
        public int IdEmpaque { get; set; }

        [Required]
        [StringLength(100)] 
        public string Nombre { get; set; }

        [Required]
        [StringLength(2)]
        public string Codigo { get; set; }

        [Required]
        public bool EstaActivo { get; set; }

        public virtual List<PaletEntity> Palets { get; set; }
    }
}
