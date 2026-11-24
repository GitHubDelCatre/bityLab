using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class PagosPresentacion : PresentacionBase<Pagos>, IPagosPresentacion
    {
        public PagosPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
