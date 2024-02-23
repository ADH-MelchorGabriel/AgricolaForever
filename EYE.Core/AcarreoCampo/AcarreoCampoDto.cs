using System.ComponentModel.DataAnnotations;
using System;

namespace EYE.Dtos
{
    public class AcarreoCampoDto
    {

        public AcarreoCampoDto()
        {

        }
        public int IdAcarreoCampo { get; set; }

        [Required, StringLength(10)]
        public string Folio { get; set; }
        [Required]
        public int IdLote { get; set; }
        [Required]
        public int IdCultivo { get; set; }
        public string Mayordomo { get; set; }
        [Required]
        public string Chofer { get; set; }
        [Required, StringLength(10)]
        public string PlacasVehiculo { get; set; }
        [StringLength(10)]
        public string PlacasRemolque { get; set; }
        public double Cajas { get; set; }
        public double Kilogramos { get; set; }

    }
}
