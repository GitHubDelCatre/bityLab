using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class Promociones : EntidadBase
    {
        public string? CodigoCupon { get; set; }
        public string? Descripcion { get; set; }
        public decimal? PorcentajeDescuento { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool EstadoActiva { get; set; }


        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(CodigoCupon)) errores.Add("Código del cupón");
            if (PorcentajeDescuento == null) errores.Add("% descuento");
            if (FechaInicio == null) errores.Add("Inicio");
            if (FechaFin == null) errores.Add("Fin");
            if (PorcentajeDescuento != null && (PorcentajeDescuento < 0 || PorcentajeDescuento > 100)) errores.Add("El descuento debe estar entre 0 y 100");
            if (FechaInicio != null && FechaFin != null && FechaFin < FechaInicio) errores.Add("La fecha fin debe ser posterior al inicio");
            return errores;
        }

        public override string ToString() => $"{CodigoCupon} ({PorcentajeDescuento:0.##}%)";

        public bool EstaVigente(DateTime fecha)
        {
            return EstadoActiva && FechaInicio <= fecha && FechaFin >= fecha;
        }
    }
}
