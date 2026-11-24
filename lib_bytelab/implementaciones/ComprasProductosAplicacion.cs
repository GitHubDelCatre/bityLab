using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class ComprasProductosAplicacion : AplicacionBase<ComprasProductos>, IComprasProductosAplicacion
    {
        public ComprasProductosAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<ComprasProductos> Consulta()
        {
            return this.IConexion.ComprasProductos!
                .Include(x => x._Proveedor)
                .Include(x => x._Sucursal);
        }

        protected override IQueryable<ComprasProductos> Filtrar(IQueryable<ComprasProductos> consulta, ComprasProductos filtro)
        {
            var texto = filtro._Proveedor?.NombreEmpresa ?? "";
            return consulta.Where(x => texto == "" || x._Proveedor!.NombreEmpresa!.Contains(texto));
        }

        protected override void AntesDeGuardar(ComprasProductos entidad)
        {
            CalcularTotal(entidad);
        }

        public void RecalcularTotal(int idCompra)
        {
            var compra = this.IConexion.ComprasProductos!.AsNoTracking().FirstOrDefault(x => x.Id == idCompra);
            if (compra == null)
                return;
            CalcularTotal(compra);
            this.IConexion.Entry<ComprasProductos>(compra).State = EntityState.Modified;
            this.IConexion.SaveChanges();
        }

        private void CalcularTotal(ComprasProductos compra)
        {
            compra.TotalEstimado = this.IConexion.DetallesOrdenesCompras!
                .Where(x => x.ComprasProducto == compra.Id && compra.Id != 0)
                .Sum(x => x.SubtotalCosto ?? 0);
        }
    }
}
