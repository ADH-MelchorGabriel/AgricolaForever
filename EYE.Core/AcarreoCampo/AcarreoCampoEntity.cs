using EYE.Dtos;
using EYE.Entidades;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Core.AcarreoCampo
{
    public class AcarreoCampoEntity
    {
        public AcarreoCampoEntity()
        {

        }

        public AcarreoCampoEntity(AcarreoCampoDto newObj)
        {
            IdAcarreoCampo = newObj.IdAcarreoCampo;
            Folio = newObj.Folio;
            Fecha=DateTime.Now;
            IdLote = newObj.IdLote;
            IdCultivo = newObj.IdCultivo;
            Mayordomo = newObj.Mayordomo;
            Chofer = newObj.Chofer;
            PlacasVehiculo = newObj.PlacasVehiculo;
            PlacasRemolque = newObj.PlacasRemolque;
            Cajas = newObj.Cajas;
            Kilogramos = newObj.Kilogramos;
        }

        [Key]
        public int IdAcarreoCampo { get; set; }

        [Required, StringLength(10)]
        public string Folio { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public int IdLote { get; set; }
        [Required]
        public int IdCultivo { get; set; }
        public string Mayordomo { get; set; }
        [Required]
        public string Chofer { get; set; }
        [Required,StringLength(10)]
        public string PlacasVehiculo { get; set; }
        [ StringLength(10)]
        public string PlacasRemolque { get; set; }
        public double Cajas { get; set; }
        public double Kilogramos { get; set; }

        [ForeignKey("IdLote")]
        public virtual LoteEntity Lote{ get; set; }

        [ForeignKey("IdCultivo")]
        public virtual CultivoEntity Cultivo { get; set; }

    }
}
