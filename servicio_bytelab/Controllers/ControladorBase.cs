using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    /// <summary>
    /// Controlador genérico: todas las entidades exponen los mismos 5 servicios REST
    /// (Entidad/Consultar, Entidad/Buscar, Entidad/Insertar, Entidad/Actualizar, Entidad/Borrar).
    /// </summary>
    public abstract class ControladorBase<T> : ControllerBase where T : EntidadBase
    {
        private IAplicacionBase<T> IAplicacion;

        protected ControladorBase(IAplicacionBase<T> IAplicacion)
        {
            this.IAplicacion = IAplicacion;
        }

        [HttpPost]
        public List<T> Consultar()
        {
            return this.IAplicacion.Consultar();
        }

        [HttpPost]
        public List<T> Buscar(T entidad)
        {
            return this.IAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public T Insertar(T entidad)
        {
            return this.IAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public T Actualizar(T entidad)
        {
            return this.IAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public T Borrar(T entidad)
        {
            return this.IAplicacion.Borrar(entidad);
        }
    }
}
