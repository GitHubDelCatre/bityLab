using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class ClientesPrueba : RepositorioPrueba<Clientes>
    {
        protected override IAplicacionBase<Clientes> CrearAplicacion(IConexion conexion)
        {
            return new ClientesAplicacion(conexion);
        }

        protected override Clientes CrearEntidad()
        {
            return new Clientes()
            {
                Usuario = 1,
                Telefono = Datos.Texto(20),
                DireccionPrincipal = Datos.Texto(200),
                FechaNacimiento = DateTime.Now,
            };
        }

        protected override void Modificar(Clientes entidad)
        {
            entidad.Telefono = "Modificado";
        }
    }
}
