namespace lib_bytelab.nucleo
{
    public class LogConversor
    {
        public static void Log(Exception ex, IDictionary<string, object?> ViewData)
        {
            if (ViewData == null)
                return;
            ViewData["Mensaje"] = Mensaje(ex);
        }

        /// <summary>Saca el mensaje real de la excepción (las de Task.Wait vienen envueltas).</summary>
        public static string Mensaje(Exception? ex)
        {
            if (ex == null)
                return "Error desconocido";

            var mensaje = ex.GetBaseException().Message;
            if (mensaje.Length >= 300)
                mensaje = mensaje.Substring(0, 300);
            return mensaje;
        }
    }
}
