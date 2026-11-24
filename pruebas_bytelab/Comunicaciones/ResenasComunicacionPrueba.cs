using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class ResenasComunicacionPrueba : ComunicacionPrueba<Resenas>
    {
        protected override IPresentacionBase<Resenas> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new ResenasPresentacion(comunicaciones);
        }
    }
}
