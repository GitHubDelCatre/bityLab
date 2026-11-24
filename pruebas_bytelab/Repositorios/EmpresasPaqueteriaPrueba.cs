using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class EmpresasPaqueteriaPrueba : RepositorioPrueba<EmpresasPaqueteria>
    {
        protected override IAplicacionBase<EmpresasPaqueteria> CrearAplicacion(IConexion conexion)
        {
            return new EmpresasPaqueteriaAplicacion(conexion);
        }

        protected override EmpresasPaqueteria CrearEntidad()
        {
            return new EmpresasPaqueteria()
            {
                NombrePaqueteria = Datos.Texto(100),
                Nit = Datos.Texto(20),
                Telefono = Datos.Texto(20),
                CorreoElectronico = Datos.Texto(100),
            };
        }

        protected override void Modificar(EmpresasPaqueteria entidad)
        {
            entidad.NombrePaqueteria = "Modificado";
        }
    }
}
