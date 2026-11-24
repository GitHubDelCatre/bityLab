using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class Ventas : EntidadBase
    {
        public int Cliente { get; set; }
        public int Sucursal { get; set; }
        public int? Promocion { get; set; }
        public DateTime? FechaVenta { get; set; }
        public string? EstadoVenta { get; set; }
        public decimal? TotalPagar { get; set; }
        public string? DireccionEnvio { get; set; }

        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }
        [ForeignKey("Sucursal")] public Sucursales? _Sucursal { get; set; }
        [ForeignKey("Promocion")] public Promociones? _Promocion { get; set; }

        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (Cliente <= 0) errores.Add("Cliente");
            if (Sucursal <= 0) errores.Add("Sucursal");
            if (FechaVenta == null) errores.Add("Fecha");
            if (string.IsNullOrWhiteSpace(EstadoVenta)) errores.Add("Estado");
            return errores;
        }

        public override string ToString() => $"Venta #{Id} - {_Cliente}";

        public static decimal CalcularTotal(IEnumerable<decimal> subtotales, decimal? porcentajeDescuento)
        {
            var suma = subtotales.Sum();
            var porcentaje = porcentajeDescuento ?? 0;
            return Math.Round(suma * (1 - porcentaje / 100m), 2);
        }
    }
}
