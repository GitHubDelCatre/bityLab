using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class VentasAplicacion : AplicacionBase<Ventas>, IVentasAplicacion
    {
        public VentasAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<Ventas> Consulta()
        {
            return this.IConexion.Ventas!
                .Include(x => x._Cliente).ThenInclude(x => x!._Usuario)
                .Include(x => x._Sucursal)
                .Include(x => x._Promocion);
        }

        protected override IQueryable<Ventas> Filtrar(IQueryable<Ventas> consulta, Ventas filtro)
        {
            var texto = filtro._Cliente?._Usuario?.NombreCompleto ?? "";
            return consulta.Where(x => texto == "" || x._Cliente!._Usuario!.NombreCompleto!.Contains(texto));
        }

        protected override void AntesDeGuardar(Ventas entidad)
        {
            CalcularTotal(entidad);
        }

        public void RecalcularTotal(int idVenta)
        {
            var venta = this.IConexion.Ventas!.AsNoTracking().FirstOrDefault(x => x.Id == idVenta);
            if (venta == null)
                return;
            CalcularTotal(venta);
            this.IConexion.Entry<Ventas>(venta).State = EntityState.Modified;
            this.IConexion.SaveChanges();
        }

        private void CalcularTotal(Ventas venta)
        {
            var subtotales = this.IConexion.DetallesVentas!
                .Where(x => x.Venta == venta.Id && venta.Id != 0)
                .Select(x => x.Subtotal ?? 0)
                .ToList();
            decimal? porcentaje = null;
            if (venta.Promocion != null)
                porcentaje = this.IConexion.Promociones!
                    .Where(x => x.Id == venta.Promocion)
                    .Select(x => x.PorcentajeDescuento)
                    .FirstOrDefault();
            venta.TotalPagar = Ventas.CalcularTotal(subtotales, porcentaje);
        }
    }
}
