using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class ProveedoresComunicacionPrueba : ComunicacionPrueba<Proveedores>
    {
        protected override IPresentacionBase<Proveedores> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new ProveedoresPresentacion(comunicaciones);
        }
    }
}
