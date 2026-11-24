using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class PagosComunicacionPrueba : ComunicacionPrueba<Pagos>
    {
        protected override IPresentacionBase<Pagos> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new PagosPresentacion(comunicaciones);
        }
    }
}
