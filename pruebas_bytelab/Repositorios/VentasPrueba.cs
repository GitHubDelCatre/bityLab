using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class VentasPrueba : RepositorioPrueba<Ventas>
    {
        protected override IAplicacionBase<Ventas> CrearAplicacion(IConexion conexion)
        {
            return new VentasAplicacion(conexion);
        }

        protected override Ventas CrearEntidad()
        {
            return new Ventas()
            {
                Cliente = 1,
                Sucursal = 1,
                Promocion = 1,
                FechaVenta = DateTime.Now,
                EstadoVenta = "Pendiente",
                DireccionEnvio = Datos.Texto(200),
            };
        }

        protected override void Modificar(Ventas entidad)
        {
            entidad.EstadoVenta = "Pagada";
        }
    }
}
