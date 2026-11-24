using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class CategoriasPresentacion : PresentacionBase<Categorias>, ICategoriasPresentacion
    {
        public CategoriasPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
