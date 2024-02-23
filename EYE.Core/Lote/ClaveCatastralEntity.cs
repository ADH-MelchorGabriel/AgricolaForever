using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("ClaveCatastral")]
    public class ClaveCatastralEntity
    {
        [Key]
        public int IdClaveCatastral { get; set; }

        [Required]
        public int IdLote { get; set; }

        [Required]
        [StringLength(16)]
        public string Clave { get; set; }

    }
}
