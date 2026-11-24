using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class MetodosPagoComunicacionPrueba : ComunicacionPrueba<MetodosPago>
    {
        protected override IPresentacionBase<MetodosPago> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new MetodosPagoPresentacion(comunicaciones);
        }
    }
}
