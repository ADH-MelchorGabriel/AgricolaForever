using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EYE.Entidades
{
    [Table("Banco")]
    public class BancoEntity
    {
        [Key]
        public int IdBanco { get; set; }
        [StringLength(20)]
        public string Nombre { get; set; }
        public bool EstaActivo { get; set; }
    }
}
