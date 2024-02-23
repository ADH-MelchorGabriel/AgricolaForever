using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("TipoCambio")]
    public class TipoCambioEntity
    {
        [Key]
        public int IdTipoCambio { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required] 
        public double Valor { get; set; }
    }
}
