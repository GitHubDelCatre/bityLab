using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class VentasComunicacionPrueba : ComunicacionPrueba<Ventas>
    {
        protected override IPresentacionBase<Ventas> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new VentasPresentacion(comunicaciones);
        }
    }
}
