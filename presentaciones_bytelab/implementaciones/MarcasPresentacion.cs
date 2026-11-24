using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class MarcasPresentacion : PresentacionBase<Marcas>, IMarcasPresentacion
    {
        public MarcasPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
