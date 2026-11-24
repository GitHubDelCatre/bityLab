using lib_bytelab.entidades;

namespace lib_bytelab.interfaces
{
    public interface IVentasAplicacion : IAplicacionBase<Ventas>
    {
        void RecalcularTotal(int idVenta);
    }
}
