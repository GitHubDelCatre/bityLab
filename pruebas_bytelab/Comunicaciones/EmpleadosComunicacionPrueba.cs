using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class EmpleadosComunicacionPrueba : ComunicacionPrueba<Empleados>
    {
        protected override IPresentacionBase<Empleados> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new EmpleadosPresentacion(comunicaciones);
        }
    }
}
