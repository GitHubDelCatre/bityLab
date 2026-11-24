using lib_bytelab.entidades;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Comunicaciones
{
    [TestClass]
    public class ProductosComunicacionPrueba : ComunicacionPrueba<Productos>
    {
        protected override IPresentacionBase<Productos> CrearPresentacion(IComunicaciones comunicaciones)
        {
            return new ProductosPresentacion(comunicaciones);
        }
    }
}
