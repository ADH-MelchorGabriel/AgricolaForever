using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Reportes
{

    public class GuiasRpt
    {
        public DateTime Fecha { get; set; }
        public string Guia { get; set; }
        public string Producto { get; set; }
        public int Cajas { get; set; }
        public double PesoCaja { get; set; }
        public double PesoTotal { get; set; }

    }
}
