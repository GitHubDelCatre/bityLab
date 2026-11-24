using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class Garantias : EntidadBase
    {
        public int DetalleVenta { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public string? MotivoFalla { get; set; }
        public string? EstadoGarantia { get; set; }
        public string? ResolucionTecnica { get; set; }
        public DateTime? FechaCierre { get; set; }

        [ForeignKey("DetalleVenta")] public DetallesVentas? _DetalleVenta { get; set; }

        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (DetalleVenta <= 0) errores.Add("Producto vendido");
            if (FechaSolicitud == null) errores.Add("Fecha de solicitud");
            if (string.IsNullOrWhiteSpace(MotivoFalla)) errores.Add("Falla reportada");
            if (string.IsNullOrWhiteSpace(EstadoGarantia)) errores.Add("Estado");
            return errores;
        }

        public override string ToString() => $"Garantía #{Id}";
    }
}
