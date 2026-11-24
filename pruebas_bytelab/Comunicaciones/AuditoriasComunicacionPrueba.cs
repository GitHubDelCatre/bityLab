using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class AuditoriasComunicacionPrueba : ComunicacionPrueba<Auditorias>
    {
        protected override IPresentacionBase<Auditorias> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new AuditoriasPresentacion(comunicaciones);
        }
    }
}
