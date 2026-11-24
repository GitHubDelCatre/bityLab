using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class MetodosPagoPrueba : RepositorioPrueba<MetodosPago>
    {
        protected override IAplicacionBase<MetodosPago> CrearAplicacion(IConexion conexion)
        {
            return new MetodosPagoAplicacion(conexion);
        }

        protected override MetodosPago CrearEntidad()
        {
            return new MetodosPago()
            {
                NombreMetodo = Datos.Texto(50),
                Descripcion = Datos.Texto(200),
                RequiereAprobacion = true,
                Activo = true,
            };
        }

        protected override void Modificar(MetodosPago entidad)
        {
            entidad.NombreMetodo = "Modificado";
        }
    }
}
