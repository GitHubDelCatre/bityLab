using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class ResenasPresentacion : PresentacionBase<Resenas>, IResenasPresentacion
    {
        public ResenasPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
