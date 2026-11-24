using lib_bytelab.entidades;

namespace presentaciones_bytelab.interfaces
{
    public interface IUsuariosPresentacion : IPresentacionBase<Usuarios>
    {
        Usuarios Login(Usuarios entidad);
    }
}
