using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class EnviosPresentacion : PresentacionBase<Envios>, IEnviosPresentacion
    {
        public EnviosPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
