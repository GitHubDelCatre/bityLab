using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class CategoriasPrueba : RepositorioPrueba<Categorias>
    {
        protected override IAplicacionBase<Categorias> CrearAplicacion(IConexion conexion)
        {
            return new CategoriasAplicacion(conexion);
        }

        protected override Categorias CrearEntidad()
        {
            return new Categorias()
            {
                Nombre = Datos.Unico(50),
                Descripcion = Datos.Texto(200),
            };
        }

        protected override void Modificar(Categorias entidad)
        {
            entidad.Descripcion = "Modificado";
        }
    }
}
