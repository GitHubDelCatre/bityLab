using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class Devoluciones : EntidadBase
    {
        public int Venta { get; set; }
        public int MetodoPago { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public string? MotivoDevolucion { get; set; }
        public string? EstadoProceso { get; set; }
        public decimal? MontoReembolsado { get; set; }

        [ForeignKey("Venta")] public Ventas? _Venta { get; set; }
        [ForeignKey("MetodoPago")] public MetodosPago? _MetodoPago { get; set; }

        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (Venta <= 0) errores.Add("Venta");
            if (MetodoPago <= 0) errores.Add("Método de reembolso");
            if (FechaSolicitud == null) errores.Add("Fecha de solicitud");
            if (string.IsNullOrWhiteSpace(MotivoDevolucion)) errores.Add("Motivo");
            if (string.IsNullOrWhiteSpace(EstadoProceso)) errores.Add("Estado");
            if (MontoReembolsado == null) errores.Add("Monto reembolsado");
            return errores;
        }

        public override string ToString() => $"Devolución #{Id}";
    }
}
