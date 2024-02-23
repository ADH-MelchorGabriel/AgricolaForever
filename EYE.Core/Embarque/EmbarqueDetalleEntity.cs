using EYE.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("EmbarqueDetalle")]
    public class EmbarqueDetalleEntity
    {

        public EmbarqueDetalleEntity()
        {

        }
        public EmbarqueDetalleEntity(EmbarqueDetalleDto obj)
        {
            IdEmbarqueDetalle = obj.IdEmbarqueDetalle;
            IdPalet=obj.IdPalet;    
            Posicion = obj.Posicion;
        }
        [Key]
        public int IdEmbarqueDetalle { get; set; }

        [Required]
        public int IdEmbarque { get; set; }
        [Required]        
        
        public int IdPalet { get; set; }

       

        [Required]
        public double Precio { get; set; }
        [Required]
        public bool EsSobrePeso { get; set; }
        [Required]
        public int Posicion { get; set; }
        [ForeignKey("IdEmbarque")]
        public virtual EmbarqueEntity Embarque { get; set; }
        [ForeignKey("IdPalet")]
        public virtual PaletEntity Palet { get; set; }
    }
}
