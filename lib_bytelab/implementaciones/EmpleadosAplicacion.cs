using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class EmpleadosAplicacion : AplicacionBase<Empleados>, IEmpleadosAplicacion
    {
        public EmpleadosAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<Empleados> Consulta()
        {
            return this.IConexion.Empleados!
                .Include(x => x._Usuario)
                .Include(x => x._Sucursal);
        }

        protected override IQueryable<Empleados> Filtrar(IQueryable<Empleados> consulta, Empleados filtro)
        {
            var texto = filtro._Usuario?.NombreCompleto ?? "";
            return consulta.Where(x => texto == "" || x._Usuario!.NombreCompleto!.Contains(texto));
        }
    }
}
