using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class DetallesVentasPresentacion : PresentacionBase<DetallesVentas>, IDetallesVentasPresentacion
    {
        public DetallesVentasPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
