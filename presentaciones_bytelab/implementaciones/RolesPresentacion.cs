using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class RolesPresentacion : PresentacionBase<Roles>, IRolesPresentacion
    {
        public RolesPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
