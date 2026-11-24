using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class EmpleadosPrueba : RepositorioPrueba<Empleados>
    {
        protected override IAplicacionBase<Empleados> CrearAplicacion(IConexion conexion)
        {
            return new EmpleadosAplicacion(conexion);
        }

        protected override Empleados CrearEntidad()
        {
            return new Empleados()
            {
                Usuario = 1,
                Sucursal = 1,
                CargoPuesto = Datos.Texto(100),
                Salario = 10,
                FechaContratacion = DateTime.Now,
            };
        }

        protected override void Modificar(Empleados entidad)
        {
            entidad.CargoPuesto = "Modificado";
        }
    }
}
