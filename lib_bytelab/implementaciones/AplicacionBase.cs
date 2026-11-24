using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    /// <summary>
    /// Repositorio genérico con el CRUD que comparten todas las entidades (POO: herencia + plantilla).
    /// Cada entidad hereda de aquí y solo define su consulta, su filtro y sus reglas propias.
    /// </summary>
    public abstract class AplicacionBase<T> : IAplicacionBase<T> where T : EntidadBase
    {
        protected IConexion IConexion;

        protected AplicacionBase(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        // ----- Lo que cada entidad debe/puede definir -----
        protected abstract IQueryable<T> Consulta();
        protected abstract IQueryable<T> Filtrar(IQueryable<T> consulta, T filtro);
        protected virtual void AntesDeGuardar(T entidad) { }
        protected virtual void DespuesDeGuardar(T entidad) { }
        protected virtual void AntesDeBorrar(T existente) { }
        protected virtual void DespuesDeBorrar(T existente) { }

        // ----- CRUD -----
        public virtual List<T> Consultar()
        {
            return Consulta()
                .OrderByDescending(x => x.Id)
                .ToList();
        }

        public virtual List<T> Buscar(T entidad)
        {
            return Filtrar(Consulta(), entidad)
                .OrderByDescending(x => x.Id)
                .ToList();
        }

        public virtual T Insertar(T entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            Validar(entidad);
            AntesDeGuardar(entidad);
            LimpiarNavegaciones(entidad);

            this.IConexion.Entry<T>(entidad).State = EntityState.Added;
            Guardar();
            DespuesDeGuardar(entidad);
            return entidad;
        }

        public virtual T Actualizar(T entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            Validar(entidad);
            AntesDeGuardar(entidad);
            LimpiarNavegaciones(entidad);

            this.IConexion.Entry<T>(entidad).State = EntityState.Modified;
            Guardar();
            DespuesDeGuardar(entidad);
            return entidad;
        }

        public virtual T Borrar(T entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            // Se trae el registro completo para que la auditoría guarde todos sus datos
            var existente = this.IConexion.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == entidad.Id)
                ?? throw new Exception("El registro no existe");

            AntesDeBorrar(existente);
            this.IConexion.Entry<T>(existente).State = EntityState.Deleted;
            Guardar();
            DespuesDeBorrar(existente);
            return existente;
        }

        // ----- Ayudas -----
        private void Validar(T entidad)
        {
            var errores = entidad.Validar();
            if (errores.Count > 0)
                throw new Exception("Falta informacion: " + string.Join(", ", errores));
        }

        private void Guardar()
        {
            try
            {
                this.IConexion.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var detalle = ex.GetBaseException().Message;
                if (detalle.Contains("UNIQUE") || detalle.Contains("duplicate"))
                    throw new Exception("Ya existe un registro con esos datos (valor repetido)");
                if (detalle.Contains("REFERENCE") || detalle.Contains("FOREIGN KEY"))
                    throw new Exception("No se puede: el registro está relacionado con otros datos");
                throw new Exception("No se pudo guardar: " + detalle);
            }
        }

        /// <summary>Quita los objetos relacionados (_Rol, _Producto...) para que EF solo guarde la tabla actual.</summary>
        private static void LimpiarNavegaciones(T entidad)
        {
            foreach (var propiedad in typeof(T).GetProperties())
                if (propiedad.Name.StartsWith("_") && propiedad.CanWrite)
                    propiedad.SetValue(entidad, null);
        }
    }
}
