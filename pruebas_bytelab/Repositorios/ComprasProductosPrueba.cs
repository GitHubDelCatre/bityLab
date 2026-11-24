using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class ComprasProductosPrueba : RepositorioPrueba<ComprasProductos>
    {
        protected override IAplicacionBase<ComprasProductos> CrearAplicacion(IConexion conexion)
        {
            return new ComprasProductosAplicacion(conexion);
        }

        protected override ComprasProductos CrearEntidad()
        {
            return new ComprasProductos()
            {
                Proveedor = 1,
                Sucursal = 1,
                FechaOrden = DateTime.Now,
                EstadoOrden = "Pendiente",
                NotasInternas = "Texto de prueba",
            };
        }

        protected override void Modificar(ComprasProductos entidad)
        {
            entidad.EstadoOrden = "Enviada";
        }
    }
}
