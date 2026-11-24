using lib_bytelab.entidades;

namespace presentaciones_bytelab.interfaces
{
    public interface IPresentacionBase<T> where T : EntidadBase
    {
        T Insertar(T entidad);
        T Actualizar(T entidad);
        List<T> Consultar();
        List<T> Buscar(T entidad);
        T Borrar(T entidad);
    }
}
