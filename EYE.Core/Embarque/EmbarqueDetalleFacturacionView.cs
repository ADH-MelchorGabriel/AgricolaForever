namespace EYE.Vistas
{
    public class EmbarqueDetalleFacturacionView
    {
        public int IdEmbarque { get; set; }
        public string CodigoProducto { get; set; }
        public string Producto { get; set; }

        public string CveFraccionArancelaria { get; set; }
        public string CveUnidadMedida { get; set; }
        public string CveProductoServicio { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Importe { get; set; }
        public double Kilogramos { get; set; }


    }
}
