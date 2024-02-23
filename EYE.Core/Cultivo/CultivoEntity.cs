using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("Cultivo")]
    public class CultivoEntity
    {
        [Key]
        public int IdCultivo { get; set; }
        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required]
        public int IdFamiliaCultivo { get; set; }
        public bool EstaActivo { get; set; }

        [ForeignKey("IdFamiliaCultivo")]
        public virtual FamiliaCultivoEntity FamiliaCultivos { get; set; }

        public virtual List<ProductoEntity> Productos { get; set; }

    }
}
