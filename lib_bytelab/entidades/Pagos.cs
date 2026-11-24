using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class Pagos : EntidadBase
    {
        public int Venta { get; set; }
        public int MetodoPago { get; set; }
        public decimal? MontoPagado { get; set; }
        public DateTime? FechaPago { get; set; }
        public string? EstadoTransaccion { get; set; }
        public string? ReferenciaPasarela { get; set; }

        [ForeignKey("Venta")] public Ventas? _Venta { get; set; }
        [ForeignKey("MetodoPago")] public MetodosPago? _MetodoPago { get; set; }

        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (Venta <= 0) errores.Add("Venta");
            if (MetodoPago <= 0) errores.Add("Método de pago");
            if (MontoPagado == null) errores.Add("Monto");
            if (FechaPago == null) errores.Add("Fecha");
            if (string.IsNullOrWhiteSpace(EstadoTransaccion)) errores.Add("Estado");
            return errores;
        }

        public override string ToString() => $"Pago #{Id} - {MontoPagado:N0}";
    }
}
