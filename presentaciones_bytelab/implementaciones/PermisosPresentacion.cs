using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class PermisosPresentacion : PresentacionBase<Permisos>, IPermisosPresentacion
    {
        public PermisosPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
