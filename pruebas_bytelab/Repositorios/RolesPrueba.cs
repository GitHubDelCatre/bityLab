using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class RolesPrueba : RepositorioPrueba<Roles>
    {
        protected override IAplicacionBase<Roles> CrearAplicacion(IConexion conexion)
        {
            return new RolesAplicacion(conexion);
        }

        protected override Roles CrearEntidad()
        {
            return new Roles()
            {
                NombreRol = Datos.Unico(50),
                Descripcion = Datos.Texto(200),
                SalarioEstimado = 10,
                EstadoActivo = true,
            };
        }

        protected override void Modificar(Roles entidad)
        {
            entidad.Descripcion = "Modificado";
        }
    }
}
