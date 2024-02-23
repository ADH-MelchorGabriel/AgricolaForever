using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("Temporada")]
    public class TemporadaEntity
    {
        [Key]
        public int IdTemporada { get; set; }
        [Required]
        [MaxLength(40)]
        public string Descripcion { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFinal { get; set; }

        public bool EstaActivo { get; set; }
		public virtual List<EmbarqueEntity> Embarque { get; set; }
	}
}
