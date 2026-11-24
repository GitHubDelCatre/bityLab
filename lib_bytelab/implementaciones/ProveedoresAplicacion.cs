using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class ProveedoresAplicacion : AplicacionBase<Proveedores>, IProveedoresAplicacion
    {
        public ProveedoresAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<Proveedores> Consulta()
        {
            return this.IConexion.Proveedores!;
        }

        protected override IQueryable<Proveedores> Filtrar(IQueryable<Proveedores> consulta, Proveedores filtro)
        {
            var texto = filtro.NombreEmpresa ?? "";
            return consulta.Where(x => texto == "" || x.NombreEmpresa!.Contains(texto));
        }
    }
}
