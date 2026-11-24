using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class AuditoriasAplicacion : AplicacionBase<Auditorias>, IAuditoriasAplicacion
    {
        public AuditoriasAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<Auditorias> Consulta()
        {
            return this.IConexion.Auditorias!;
        }

        protected override IQueryable<Auditorias> Filtrar(IQueryable<Auditorias> consulta, Auditorias filtro)
        {
            var texto = filtro.Entidad ?? "";
            return consulta.Where(x => texto == "" || x.Entidad!.Contains(texto));
        }

        // Las auditorías las escribe el sistema (Conexion.SaveChanges); nadie las puede crear, editar ni borrar a mano
        public override Auditorias Insertar(Auditorias entidad)
        {
            throw new Exception("Las auditorías las genera el sistema automáticamente");
        }

        public override Auditorias Actualizar(Auditorias entidad)
        {
            throw new Exception("Las auditorías no se pueden modificar");
        }

        public override Auditorias Borrar(Auditorias entidad)
        {
            throw new Exception("Las auditorías no se pueden borrar");
        }
    }
}
