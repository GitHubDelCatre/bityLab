using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    /// <summary>
    /// Presentación genérica: valida en el front y llama al servicio REST de la entidad.
    /// La ruta se arma con el nombre de la clase: "Productos/Insertar", "Ventas/Buscar"...
    /// </summary>
    public abstract class PresentacionBase<T> : IPresentacionBase<T> where T : EntidadBase
    {
        protected IComunicaciones IComunicaciones;

        protected PresentacionBase(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        protected virtual string Ruta => typeof(T).Name;

        public List<T> Consultar()
        {
            return Ejecutar<List<T>>("Consultar", null);
        }

        public List<T> Buscar(T entidad)
        {
            return Ejecutar<List<T>>("Buscar", entidad);
        }

        public T Insertar(T entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            Validar(entidad);
            return Ejecutar<T>("Insertar", entidad);
        }

        public T Actualizar(T entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");
            Validar(entidad);
            return Ejecutar<T>("Actualizar", entidad);
        }

        public T Borrar(T entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");
            return Ejecutar<T>("Borrar", entidad);
        }

        protected R Ejecutar<R>(string accion, object? entidad)
        {
            var task = this.IComunicaciones.Ejecutar<R>(Ruta + "/" + accion, entidad);
            task.Wait();
            return task.Result;
        }

        private static void Validar(T entidad)
        {
            var errores = entidad.Validar();
            if (errores.Count > 0)
                throw new Exception("Falta informacion: " + string.Join(", ", errores));
        }
    }
}
