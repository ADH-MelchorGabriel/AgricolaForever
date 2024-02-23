using EYE.Enumeradores;
using System.ComponentModel.DataAnnotations;

namespace EYE.Entidades
{
    public class ArticuloEntity
    {
        [Key]
        public int IdArticulo { get; set; }
        [Required, StringLength(200)]
        public string Nombre { get; set; }
        public TipoArticuloEnum TipoArticulo { get; set; }
        public double Existencia { get; set; }
        public double CostoPromedio { get; set; }
        public bool EstaActivo { get; set; }
    }
}
