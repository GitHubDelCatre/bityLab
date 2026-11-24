namespace lib_bytelab.nucleo
{
    public class DatosGenerales
    {
        // Cambie "localhost" por el nombre de su servidor, por ejemplo "localhost\\SQLEXPRESS"
        public static string StringConexion()
        {
            return "server=DESKTOP-9GLKNRV\\DEV;database=db_bytelab;Integrated Security=True;TrustServerCertificate=true;";
        }

        // Dirección donde corre servicio_bytelab (API)
        public static string UrlServicio()
        {
            return "http://localhost:5210/";
        }
    }
}
