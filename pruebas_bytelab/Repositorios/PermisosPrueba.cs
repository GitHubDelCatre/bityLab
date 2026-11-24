using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class PermisosPrueba : RepositorioPrueba<Permisos>
    {
        protected override IAplicacionBase<Permisos> CrearAplicacion(IConexion conexion)
        {
            return new PermisosAplicacion(conexion);
        }

        protected override Permisos CrearEntidad()
        {
            return new Permisos()
            {
                Codigo = Datos.Unico(50),
                Nombre = Datos.Texto(100),
                Descripcion = Datos.Texto(200),
            };
        }

        protected override void Modificar(Permisos entidad)
        {
            entidad.Nombre = "Modificado";
        }
    }
}
