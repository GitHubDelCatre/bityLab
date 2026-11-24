using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class ProveedoresPrueba : RepositorioPrueba<Proveedores>
    {
        protected override IAplicacionBase<Proveedores> CrearAplicacion(IConexion conexion)
        {
            return new ProveedoresAplicacion(conexion);
        }

        protected override Proveedores CrearEntidad()
        {
            return new Proveedores()
            {
                NombreEmpresa = Datos.Texto(100),
                NitEmpresa = Datos.Unico(20),
                NombreContacto = Datos.Texto(100),
                TelefonoPrincipal = Datos.Texto(20),
                CorreoVentas = Datos.Texto(100),
                DireccionFisica = Datos.Texto(200),
            };
        }

        protected override void Modificar(Proveedores entidad)
        {
            entidad.NombreEmpresa = "Modificado";
        }
    }
}
