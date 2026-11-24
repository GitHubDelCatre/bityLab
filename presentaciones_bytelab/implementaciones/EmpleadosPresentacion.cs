using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class EmpleadosPresentacion : PresentacionBase<Empleados>, IEmpleadosPresentacion
    {
        public EmpleadosPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
