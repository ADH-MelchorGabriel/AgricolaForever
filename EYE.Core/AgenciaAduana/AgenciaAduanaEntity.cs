using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("AgenciaAduana")]
    public class AgenciaAduanaEntity
    {
        [Key]
        public int IdAgenciaAduana { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }  
        public bool EstaActivo { get; set; }
		public virtual List<EmbarqueEntity> Embarque { get; set; }
	}
}
