using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class PromocionesComunicacionPrueba : ComunicacionPrueba<Promociones>
    {
        protected override IPresentacionBase<Promociones> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new PromocionesPresentacion(comunicaciones);
        }
    }
}
