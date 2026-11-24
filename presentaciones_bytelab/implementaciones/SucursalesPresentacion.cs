using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class SucursalesPresentacion : PresentacionBase<Sucursales>, ISucursalesPresentacion
    {
        public SucursalesPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
