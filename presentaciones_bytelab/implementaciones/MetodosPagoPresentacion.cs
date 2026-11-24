using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class MetodosPagoPresentacion : PresentacionBase<MetodosPago>, IMetodosPagoPresentacion
    {
        public MetodosPagoPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
