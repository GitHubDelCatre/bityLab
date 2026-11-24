using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class InventariosPresentacion : PresentacionBase<Inventarios>, IInventariosPresentacion
    {
        public InventariosPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
