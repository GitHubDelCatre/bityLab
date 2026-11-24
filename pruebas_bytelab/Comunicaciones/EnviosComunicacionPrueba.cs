using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class EnviosComunicacionPrueba : ComunicacionPrueba<Envios>
    {
        protected override IPresentacionBase<Envios> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new EnviosPresentacion(comunicaciones);
        }
    }
}
