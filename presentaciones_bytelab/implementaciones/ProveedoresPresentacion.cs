using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class ProveedoresPresentacion : PresentacionBase<Proveedores>, IProveedoresPresentacion
    {
        public ProveedoresPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
