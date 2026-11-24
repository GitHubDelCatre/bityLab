using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class ClientesComunicacionPrueba : ComunicacionPrueba<Clientes>
    {
        protected override IPresentacionBase<Clientes> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new ClientesPresentacion(comunicaciones);
        }
    }
}
