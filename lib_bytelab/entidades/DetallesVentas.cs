using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class DetallesVentas : EntidadBase
    {
        public int Venta { get; set; }
        public int Producto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? PrecioUnitarioVenta { get; set; }
        public decimal? DescuentoAplicado { get; set; }
        public decimal? Subtotal { get; set; }

        [ForeignKey("Venta")] public Ventas? _Venta { get; set; }
        [ForeignKey("Producto")] public Productos? _Producto { get; set; }

        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (Venta <= 0) errores.Add("Venta");
            if (Producto <= 0) errores.Add("Producto");
            if (Cantidad == null) errores.Add("Cantidad");
            if (PrecioUnitarioVenta == null) errores.Add("Precio unitario");
            if (Cantidad != null && Cantidad <= 0) errores.Add("La cantidad debe ser mayor a cero");
            return errores;
        }

        public override string ToString() => $"Venta #{Venta} - {_Producto}";

        public static decimal CalcularSubtotal(int? cantidad, decimal? precioUnitario, decimal? descuento)
        {
            var subtotal = (cantidad ?? 0) * (precioUnitario ?? 0) - (descuento ?? 0);
            return subtotal < 0 ? 0 : Math.Round(subtotal, 2);
        }
    }
}
