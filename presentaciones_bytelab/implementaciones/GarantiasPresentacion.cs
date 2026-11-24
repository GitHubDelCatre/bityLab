using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class GarantiasPresentacion : PresentacionBase<Garantias>, IGarantiasPresentacion
    {
        public GarantiasPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
