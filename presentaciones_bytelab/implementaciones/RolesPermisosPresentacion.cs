using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class RolesPermisosPresentacion : PresentacionBase<RolesPermisos>, IRolesPermisosPresentacion
    {
        public RolesPermisosPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
