using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class RolesComunicacionPrueba : ComunicacionPrueba<Roles>
    {
        protected override IPresentacionBase<Roles> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new RolesPresentacion(comunicaciones);
        }
    }
}
