using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class DevolucionesPrueba : RepositorioPrueba<Devoluciones>
    {
        protected override IAplicacionBase<Devoluciones> CrearAplicacion(IConexion conexion)
        {
            return new DevolucionesAplicacion(conexion);
        }

        protected override Devoluciones CrearEntidad()
        {
            return new Devoluciones()
            {
                Venta = 1,
                MetodoPago = 1,
                FechaSolicitud = DateTime.Now,
                MotivoDevolucion = Datos.Texto(200),
                EstadoProceso = "Solicitada",
                MontoReembolsado = 10,
            };
        }

        protected override void Modificar(Devoluciones entidad)
        {
            entidad.MotivoDevolucion = "Modificado";
        }
    }
}
