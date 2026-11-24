using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class DevolucionesPresentacion : PresentacionBase<Devoluciones>, IDevolucionesPresentacion
    {
        public DevolucionesPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
