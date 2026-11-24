using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class Envios : EntidadBase
    {
        public int Venta { get; set; }
        public int EmpresaPaqueteria { get; set; }
        public string? NumeroGuia { get; set; }
        public string? EstadoEnvio { get; set; }
        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaEstimadaEntrega { get; set; }
        public DateTime? FechaEntregaReal { get; set; }
        public decimal? CostoEnvio { get; set; }

        [ForeignKey("Venta")] public Ventas? _Venta { get; set; }
        [ForeignKey("EmpresaPaqueteria")] public EmpresasPaqueteria? _EmpresaPaqueteria { get; set; }

        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (Venta <= 0) errores.Add("Venta");
            if (EmpresaPaqueteria <= 0) errores.Add("Transportadora");
            if (string.IsNullOrWhiteSpace(NumeroGuia)) errores.Add("Número de guía");
            if (string.IsNullOrWhiteSpace(EstadoEnvio)) errores.Add("Estado");
            if (CostoEnvio == null) errores.Add("Costo del envío");
            return errores;
        }

        public override string ToString() => $"Guía {NumeroGuia}";
    }
}
