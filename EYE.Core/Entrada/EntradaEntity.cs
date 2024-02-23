using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("Entrada")]
    public class EntradaEntity
    {
        [Key]
        public int IdEntrada { get; set; }

        [Required]
        public DateTime Fecha{ get; set; }

        [StringLength(10)]
        public string Folio { get; set; }

        public string Observaciones { get; set; }

        public bool EstaActivo { get; set; }

    }
}
