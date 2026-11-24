using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class MarcasPrueba : RepositorioPrueba<Marcas>
    {
        protected override IAplicacionBase<Marcas> CrearAplicacion(IConexion conexion)
        {
            return new MarcasAplicacion(conexion);
        }

        protected override Marcas CrearEntidad()
        {
            return new Marcas()
            {
                NombreMarca = Datos.Texto(50),
                SitioWeb = Datos.Texto(200),
                CorreoSoporte = Datos.Texto(100),
                TelefonoContacto = Datos.Texto(20),
            };
        }

        protected override void Modificar(Marcas entidad)
        {
            entidad.NombreMarca = "Modificado";
        }
    }
}
