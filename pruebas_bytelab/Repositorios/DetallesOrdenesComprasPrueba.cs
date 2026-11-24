using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class DetallesOrdenesComprasPrueba : RepositorioPrueba<DetallesOrdenesCompras>
    {
        protected override IAplicacionBase<DetallesOrdenesCompras> CrearAplicacion(IConexion conexion)
        {
            return new DetallesOrdenesComprasAplicacion(conexion);
        }

        protected override DetallesOrdenesCompras CrearEntidad()
        {
            return new DetallesOrdenesCompras()
            {
                ComprasProducto = 1,
                Producto = 1,
                CantidadSolicitada = 1,
                CostoUnitario = 10,
            };
        }

        protected override void Modificar(DetallesOrdenesCompras entidad)
        {
            entidad.CostoUnitario = 20;
        }
    }
}
