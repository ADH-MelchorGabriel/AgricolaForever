using System;
using System.ComponentModel.DataAnnotations;

namespace EYE.Core.Embarque
{
    public class PagoDto
    {
        public int IdBanco { get; set; }
        public DateTime? FechaPago { get; set; }

        [StringLength(20)]
        public string ReferenciaPago { get; set; }

        public double Importe { get; set; }

    }
}
