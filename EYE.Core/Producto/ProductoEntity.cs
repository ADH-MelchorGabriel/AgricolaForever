using EYE.Enumeradores;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Entidades
{
    [Table("Productos")]
    public class ProductoEntity
    {
        [Key]
        [Required]
        public int IdProducto { get; set; }
        [StringLength(120)]
        public string Nombre { get; set; }
        [Required]
        public int IdCultivo { get; set; }

        [Required]
        public int IdTamaño { get; set; }
        [Required]
        public int IdEnvase { get; set; }


        public double Libras { get; set; }

        public double PesoKg { get; set; }
        [MaxLength(10)]
        public string CveFraccionArancelaria { get; set; }
        [MaxLength(8)]
        public string CveProductoServicio { get; set; }
        
        [MaxLength(3)]
        public string CveUnidadMedida { get; set; }
        public int Cantidad { get; set; }
        [MaxLength(5)]
        public string Codigo { get; set; }
        public CalidadEnum Calidad { get; set; }
        [MaxLength(6)]
        public string FolioGuia { get; set; }
        public bool EstaActivo { get; set; }

        [ForeignKey("IdCultivo")]
        public virtual CultivoEntity Cultivo { get; set; }

        [ForeignKey("IdEnvase")]
        public virtual EnvaseEntity Envase { get; set; }
        [ForeignKey("IdTamaño")]
        public virtual TamañoEntity Tamaño { get; set; }
		public virtual List<PaletDetalleEntity> PaletDetalle { get; set; }
	}
}
