using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class DevolucionesComunicacionPrueba : ComunicacionPrueba<Devoluciones>
    {
        protected override IPresentacionBase<Devoluciones> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new DevolucionesPresentacion(comunicaciones);
        }
    }
}
