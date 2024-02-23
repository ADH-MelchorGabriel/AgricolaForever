using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("Envase")]
    public class EnvaseEntity
    {
        [Key]
        public int IdEnvase { get; set; }
        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }
        public bool EstaActivo { get; set; }
        public virtual List<ProductoEntity> Productos { get; set; }
    }
}
