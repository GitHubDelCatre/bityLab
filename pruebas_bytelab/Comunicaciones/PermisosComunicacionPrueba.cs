using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class PermisosComunicacionPrueba : ComunicacionPrueba<Permisos>
    {
        protected override IPresentacionBase<Permisos> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new PermisosPresentacion(comunicaciones);
        }
    }
}
