using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class EmpresasPaqueteriaComunicacionPrueba : ComunicacionPrueba<EmpresasPaqueteria>
    {
        protected override IPresentacionBase<EmpresasPaqueteria> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new EmpresasPaqueteriaPresentacion(comunicaciones);
        }
    }
}
