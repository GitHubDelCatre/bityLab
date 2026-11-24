using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class DetallesVentasComunicacionPrueba : ComunicacionPrueba<DetallesVentas>
    {
        protected override IPresentacionBase<DetallesVentas> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new DetallesVentasPresentacion(comunicaciones);
        }
    }
}
