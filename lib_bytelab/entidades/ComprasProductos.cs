using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class ComprasProductos : EntidadBase
    {
        public int Proveedor { get; set; }
        public int Sucursal { get; set; }
        public DateTime? FechaOrden { get; set; }
        public string? EstadoOrden { get; set; }
        public decimal? TotalEstimado { get; set; }
        public string? NotasInternas { get; set; }

        [ForeignKey("Proveedor")] public Proveedores? _Proveedor { get; set; }
        [ForeignKey("Sucursal")] public Sucursales? _Sucursal { get; set; }

        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (Proveedor <= 0) errores.Add("Proveedor");
            if (Sucursal <= 0) errores.Add("Sucursal");
            if (FechaOrden == null) errores.Add("Fecha de la orden");
            if (string.IsNullOrWhiteSpace(EstadoOrden)) errores.Add("Estado");
            return errores;
        }

        public override string ToString() => $"Orden #{Id} - {_Proveedor}";
    }
}
