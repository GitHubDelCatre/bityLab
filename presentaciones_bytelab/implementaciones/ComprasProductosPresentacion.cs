using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class ComprasProductosPresentacion : PresentacionBase<ComprasProductos>, IComprasProductosPresentacion
    {
        public ComprasProductosPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
