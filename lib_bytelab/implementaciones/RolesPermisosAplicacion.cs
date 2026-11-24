using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class RolesPermisosAplicacion : AplicacionBase<RolesPermisos>, IRolesPermisosAplicacion
    {
        public RolesPermisosAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<RolesPermisos> Consulta()
        {
            return this.IConexion.RolesPermisos!
                .Include(x => x._Rol)
                .Include(x => x._Permiso);
        }

        protected override IQueryable<RolesPermisos> Filtrar(IQueryable<RolesPermisos> consulta, RolesPermisos filtro)
        {
            var texto = filtro._Rol?.NombreRol ?? "";
            return consulta.Where(x => texto == "" || x._Rol!.NombreRol!.Contains(texto));
        }
    }
}
