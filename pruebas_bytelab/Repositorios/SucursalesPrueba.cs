using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class SucursalesPrueba : RepositorioPrueba<Sucursales>
    {
        protected override IAplicacionBase<Sucursales> CrearAplicacion(IConexion conexion)
        {
            return new SucursalesAplicacion(conexion);
        }

        protected override Sucursales CrearEntidad()
        {
            return new Sucursales()
            {
                NombreSucursal = Datos.Texto(100),
                Direccion = Datos.Texto(200),
                Ciudad = Datos.Texto(50),
                TelefonoContacto = Datos.Texto(20),
                HorarioAtencion = Datos.Texto(100),
                Latitud = 6.25,
                Longitud = 6.25,
            };
        }

        protected override void Modificar(Sucursales entidad)
        {
            entidad.NombreSucursal = "Modificado";
        }
    }
}
