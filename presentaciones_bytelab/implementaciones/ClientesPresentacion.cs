using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class ClientesPresentacion : PresentacionBase<Clientes>, IClientesPresentacion
    {
        public ClientesPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
