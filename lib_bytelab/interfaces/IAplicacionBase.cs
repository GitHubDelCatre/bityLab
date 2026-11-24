using lib_bytelab.entidades;

namespace lib_bytelab.interfaces
{
    /// <summary>Operaciones que tiene el repositorio de cualquier entidad.</summary>
    public interface IAplicacionBase<T> where T : EntidadBase
    {
        T Insertar(T entidad);
        T Actualizar(T entidad);
        List<T> Consultar();
        List<T> Buscar(T entidad);
        T Borrar(T entidad);
    }
}
