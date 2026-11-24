using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class InventariosComunicacionPrueba : ComunicacionPrueba<Inventarios>
    {
        protected override IPresentacionBase<Inventarios> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new InventariosPresentacion(comunicaciones);
        }
    }
}
