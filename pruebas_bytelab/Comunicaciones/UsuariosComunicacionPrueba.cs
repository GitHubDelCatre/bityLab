using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class UsuariosComunicacionPrueba : ComunicacionPrueba<Usuarios>
    {
        protected override IPresentacionBase<Usuarios> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new UsuariosPresentacion(comunicaciones);
        }
    }
}
