using System;

namespace EYE.Core.Reportes
{
    public class EnviosRpt
    {
        public int Manifiesto { get; set; }
        public int IdAgricultor { get; set; }
        public string Agricultor { get; set; }

        public string Destino { get; set; }

        public DateTime FechaEnvio { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Importe { get; set; }

    }
}
