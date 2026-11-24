using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class SucursalesAplicacion : AplicacionBase<Sucursales>, ISucursalesAplicacion
    {
        public SucursalesAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<Sucursales> Consulta()
        {
            return this.IConexion.Sucursales!;
        }

        protected override IQueryable<Sucursales> Filtrar(IQueryable<Sucursales> consulta, Sucursales filtro)
        {
            var texto = filtro.NombreSucursal ?? "";
            return consulta.Where(x => texto == "" || x.NombreSucursal!.Contains(texto));
        }
    }
}
