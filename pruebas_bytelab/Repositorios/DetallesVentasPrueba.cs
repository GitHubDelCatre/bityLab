using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class DetallesVentasPrueba : RepositorioPrueba<DetallesVentas>
    {
        protected override IAplicacionBase<DetallesVentas> CrearAplicacion(IConexion conexion)
        {
            return new DetallesVentasAplicacion(conexion);
        }

        protected override DetallesVentas CrearEntidad()
        {
            return new DetallesVentas()
            {
                Venta = 1,
                Producto = 1,
                Cantidad = 1,
                PrecioUnitarioVenta = 10,
                DescuentoAplicado = 10,
            };
        }

        protected override void Modificar(DetallesVentas entidad)
        {
            entidad.PrecioUnitarioVenta = 20;
        }
    }
}
