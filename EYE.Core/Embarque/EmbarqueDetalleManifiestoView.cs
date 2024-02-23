using System.ComponentModel.DataAnnotations.Schema;

namespace EYE.Vistas
{
    public class EmbarqueDetalleManifiestoView
    {
        public int IdEmbarque { get; set; }
        public string Producto { get; set; }
        public string Tamaño { get; set; }
        public string Envase { get; set; }
        public int Calidad { get; set; }

        [NotMapped]
        public string CalidadDescripcion { get { return Calidad == 0 ? "Primera" : Calidad == 1 ? "Segunda" : "Tercera"; } }
        public int cantidad { get; set; }
        public double Kilos { get; set; }

        public double Libras { get; set; }

    }
}
