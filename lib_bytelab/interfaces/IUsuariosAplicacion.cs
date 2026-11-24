using lib_bytelab.entidades;

namespace lib_bytelab.interfaces
{
    public interface IUsuariosAplicacion : IAplicacionBase<Usuarios>
    {
        Usuarios Login(Usuarios entidad);
    }
}
