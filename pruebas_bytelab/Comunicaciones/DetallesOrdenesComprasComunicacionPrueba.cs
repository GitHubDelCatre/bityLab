using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class DetallesOrdenesComprasComunicacionPrueba : ComunicacionPrueba<DetallesOrdenesCompras>
    {
        protected override IPresentacionBase<DetallesOrdenesCompras> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new DetallesOrdenesComprasPresentacion(comunicaciones);
        }
    }
}
