using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class AuditoriasPresentacion : PresentacionBase<Auditorias>, IAuditoriasPresentacion
    {
        public AuditoriasPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
