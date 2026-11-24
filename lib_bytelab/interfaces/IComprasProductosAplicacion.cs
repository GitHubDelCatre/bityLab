using lib_bytelab.entidades;

namespace lib_bytelab.interfaces
{
    public interface IComprasProductosAplicacion : IAplicacionBase<ComprasProductos>
    {
        void RecalcularTotal(int idCompra);
    }
}
