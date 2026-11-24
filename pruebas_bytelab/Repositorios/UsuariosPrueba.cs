using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class UsuariosPrueba : RepositorioPrueba<Usuarios>
    {
        protected override IAplicacionBase<Usuarios> CrearAplicacion(IConexion conexion)
        {
            return new UsuariosAplicacion(conexion);
        }

        protected override Usuarios CrearEntidad()
        {
            return new Usuarios()
            {
                Rol = 1,
                NombreCompleto = Datos.Texto(100),
                Cedula = Datos.Unico(20),
                Correo = Datos.Unico(20) + "@prueba.com",
                Contrasena = "Prueba.123",
                CuentaActiva = true,
            };
        }

        protected override void Modificar(Usuarios entidad)
        {
            entidad.NombreCompleto = "Modificado";
        }
    }
}
