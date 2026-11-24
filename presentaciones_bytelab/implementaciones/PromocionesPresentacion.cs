using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class PromocionesPresentacion : PresentacionBase<Promociones>, IPromocionesPresentacion
    {
        public PromocionesPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
