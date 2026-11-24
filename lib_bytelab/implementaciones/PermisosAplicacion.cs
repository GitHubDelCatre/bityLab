using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class PermisosAplicacion : AplicacionBase<Permisos>, IPermisosAplicacion
    {
        public PermisosAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<Permisos> Consulta()
        {
            return this.IConexion.Permisos!;
        }

        protected override IQueryable<Permisos> Filtrar(IQueryable<Permisos> consulta, Permisos filtro)
        {
            var texto = filtro.Nombre ?? "";
            return consulta.Where(x => texto == "" || x.Nombre!.Contains(texto));
        }
    }
}
