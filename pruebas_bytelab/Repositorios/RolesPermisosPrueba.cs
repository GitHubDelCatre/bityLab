using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class RolesPermisosPrueba : RepositorioPrueba<RolesPermisos>
    {
        protected override IAplicacionBase<RolesPermisos> CrearAplicacion(IConexion conexion)
        {
            return new RolesPermisosAplicacion(conexion);
        }

        protected override RolesPermisos CrearEntidad()
        {
            return new RolesPermisos()
            {
                Rol = 4,
                Permiso = 1,
            };
        }

        protected override void Modificar(RolesPermisos entidad)
        {
            entidad.ToString();
        }
    }
}
