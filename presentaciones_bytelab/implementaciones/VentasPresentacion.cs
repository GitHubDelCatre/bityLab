using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class VentasPresentacion : PresentacionBase<Ventas>, IVentasPresentacion
    {
        public VentasPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
