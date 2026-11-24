using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class InventariosPrueba : RepositorioPrueba<Inventarios>
    {
        protected override IAplicacionBase<Inventarios> CrearAplicacion(IConexion conexion)
        {
            return new InventariosAplicacion(conexion);
        }

        protected override Inventarios CrearEntidad()
        {
            return new Inventarios()
            {
                Producto = 1,
                Sucursal = 4,
                CantidadDisponible = 1,
                StockMinimo = 1,
                EstanteriaUbicacion = Datos.Texto(50),
                CapacidadBodega = 100,
            };
        }

        protected override void Modificar(Inventarios entidad)
        {
            entidad.EstanteriaUbicacion = "Modificado";
        }
    }
}
