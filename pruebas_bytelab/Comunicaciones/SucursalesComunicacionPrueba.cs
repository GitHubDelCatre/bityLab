using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class SucursalesComunicacionPrueba : ComunicacionPrueba<Sucursales>
    {
        protected override IPresentacionBase<Sucursales> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new SucursalesPresentacion(comunicaciones);
        }
    }
}
