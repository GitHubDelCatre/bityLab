using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class ProductosPrueba : RepositorioPrueba<Productos>
    {
        protected override IAplicacionBase<Productos> CrearAplicacion(IConexion conexion)
        {
            return new ProductosAplicacion(conexion);
        }

        protected override Productos CrearEntidad()
        {
            return new Productos()
            {
                Categoria = 1,
                Marca = 1,
                NombreProducto = Datos.Texto(100),
                DescripcionLarga = "Texto de prueba",
                PrecioVenta = 10,
                NumeroSerie = Datos.Texto(50),
                Modelo = Datos.Texto(50),
                EspecificacionesTecnicas = "Texto de prueba",
            };
        }

        protected override void Modificar(Productos entidad)
        {
            entidad.NombreProducto = "Modificado";
        }
    }
}
