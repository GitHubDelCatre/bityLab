using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class RolesAplicacion : AplicacionBase<Roles>, IRolesAplicacion
    {
        public RolesAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<Roles> Consulta()
        {
            return this.IConexion.Roles!;
        }

        protected override IQueryable<Roles> Filtrar(IQueryable<Roles> consulta, Roles filtro)
        {
            var texto = filtro.NombreRol ?? "";
            return consulta.Where(x => texto == "" || x.NombreRol!.Contains(texto));
        }
    }
}
