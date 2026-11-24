using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class DetallesVentasAplicacion : AplicacionBase<DetallesVentas>, IDetallesVentasAplicacion
    {
        public DetallesVentasAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<DetallesVentas> Consulta()
        {
            return this.IConexion.DetallesVentas!
                .Include(x => x._Venta)
                .Include(x => x._Producto);
        }

        protected override IQueryable<DetallesVentas> Filtrar(IQueryable<DetallesVentas> consulta, DetallesVentas filtro)
        {
            var texto = filtro._Producto?.NombreProducto ?? "";
            return consulta.Where(x => texto == "" || x._Producto!.NombreProducto!.Contains(texto));
        }

        protected override void AntesDeGuardar(DetallesVentas entidad)
        {
            entidad.Subtotal = DetallesVentas.CalcularSubtotal(entidad.Cantidad, entidad.PrecioUnitarioVenta, entidad.DescuentoAplicado);

            // Movimiento de inventario: se devuelve lo anterior y se descuenta lo nuevo
            var movimientos = new Dictionary<(int Venta, int Producto), int>();
            if (entidad.Id != 0)
            {
                var anterior = this.IConexion.DetallesVentas!.AsNoTracking().FirstOrDefault(x => x.Id == entidad.Id);
                if (anterior != null)
                    Sumar(movimientos, anterior.Venta, anterior.Producto, anterior.Cantidad ?? 0);
            }
            Sumar(movimientos, entidad.Venta, entidad.Producto, -(entidad.Cantidad ?? 0));
            foreach (var movimiento in movimientos.Where(x => x.Value != 0))
                MoverInventario(movimiento.Key.Venta, movimiento.Key.Producto, movimiento.Value);
        }

        protected override void AntesDeBorrar(DetallesVentas existente)
        {
            MoverInventario(existente.Venta, existente.Producto, existente.Cantidad ?? 0);
        }

        protected override void DespuesDeGuardar(DetallesVentas entidad)
        {
            new VentasAplicacion(this.IConexion).RecalcularTotal(entidad.Venta);
        }

        protected override void DespuesDeBorrar(DetallesVentas existente)
        {
            new VentasAplicacion(this.IConexion).RecalcularTotal(existente.Venta);
        }

        private static void Sumar(Dictionary<(int Venta, int Producto), int> movimientos, int venta, int producto, int cantidad)
        {
            var llave = (venta, producto);
            movimientos[llave] = movimientos.GetValueOrDefault(llave) + cantidad;
        }

        private void MoverInventario(int idVenta, int idProducto, int cantidad)
        {
            var sucursal = this.IConexion.Ventas!.Where(x => x.Id == idVenta).Select(x => x.Sucursal).FirstOrDefault();
            var inventario = this.IConexion.Inventarios!.AsNoTracking()
                .FirstOrDefault(x => x.Producto == idProducto && x.Sucursal == sucursal)
                ?? throw new Exception("El producto no tiene inventario en la sucursal de la venta");

            var nuevaCantidad = (inventario.CantidadDisponible ?? 0) + cantidad;
            if (nuevaCantidad < 0)
                throw new Exception($"Stock insuficiente. Disponible: {inventario.CantidadDisponible}");

            inventario.CantidadDisponible = nuevaCantidad;
            inventario.UltimaActualizacion = DateTime.Now;
            this.IConexion.Entry<Inventarios>(inventario).State = EntityState.Modified;
        }
    }
}
