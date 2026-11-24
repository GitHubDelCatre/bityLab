using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class DetallesOrdenesComprasPresentacion : PresentacionBase<DetallesOrdenesCompras>, IDetallesOrdenesComprasPresentacion
    {
        public DetallesOrdenesComprasPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
