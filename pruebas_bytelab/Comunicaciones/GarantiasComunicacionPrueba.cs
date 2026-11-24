using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class GarantiasComunicacionPrueba : ComunicacionPrueba<Garantias>
    {
        protected override IPresentacionBase<Garantias> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new GarantiasPresentacion(comunicaciones);
        }
    }
}
