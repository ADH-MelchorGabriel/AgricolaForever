namespace Sistema.Core.Helppers
{
    public class Respuesta
    {
        public bool ExisteError { get; set; }
        public string Mensaje { get; set; }
        public object Datos { get; set; }


        public Respuesta(object datos)
        {
            ExisteError = false;
            Mensaje = "";
            Datos= datos;
        }

        public Respuesta(string mensaje, object datos)
        {
            ExisteError = false;
            Mensaje = mensaje;
            Datos = datos;
        }
        public Respuesta(string mensaje)
        {
            ExisteError = true;
            Mensaje = mensaje;
            Datos = null;
        }
    }
}
