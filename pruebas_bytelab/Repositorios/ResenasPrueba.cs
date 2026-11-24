using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class ResenasPrueba : RepositorioPrueba<Resenas>
    {
        protected override IAplicacionBase<Resenas> CrearAplicacion(IConexion conexion)
        {
            return new ResenasAplicacion(conexion);
        }

        protected override Resenas CrearEntidad()
        {
            return new Resenas()
            {
                Producto = 1,
                Cliente = 1,
                CalificacionEstrellas = 5,
                Comentario = "Texto de prueba",
                FechaPublicacion = DateTime.Now,
            };
        }

        protected override void Modificar(Resenas entidad)
        {
            entidad.ToString();
        }
    }
}
