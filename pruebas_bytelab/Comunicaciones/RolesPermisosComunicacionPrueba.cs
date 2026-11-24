using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class RolesPermisosComunicacionPrueba : ComunicacionPrueba<RolesPermisos>
    {
        protected override IPresentacionBase<RolesPermisos> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new RolesPermisosPresentacion(comunicaciones);
        }
    }
}
