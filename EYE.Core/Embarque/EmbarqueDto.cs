using EYE.Enumeradores;
using System;
using System.ComponentModel.DataAnnotations;

namespace EYE.Dtos
{
    public class EmbarqueDto
    {

        public EmbarqueDto()
        {

        }

        public int IdEmbarque { get; set; }

        [Required]
        public int Manifiesto { get; set; }

        [Required]
        public TipoEmbarqueEnum TipoEmbarque { get; set; }
     
        [Required]
        public int IdCliente { get; set; }
        [StringLength(8)]
        public string CAADES { get; set; }
        [Required]
        public int IdAgenciaAduana { get; set; }
        
        [Required]
        public int IdVehiculo { get; set; }
        [Required]
        public int IdChofer { get; set; }
        [Required]
        public int IdRemolque { get; set; }
        [Required]
        public int IdDestino { get; set; }
        [Required]
        public int Temperatura { get; set; }
      
       public bool EstaTimbrado { get; set; }
    
    }
}
