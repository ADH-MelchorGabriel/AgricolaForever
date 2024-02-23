using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("FamiliaCultivo")]
    public class FamiliaCultivoEntity
    {
        [Key]
        public int IdFamiliaCultivo { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        public bool EstaActivo { get; set; }

        public virtual List<CultivoEntity> Cultivos { get; set;}
     
    }
}
