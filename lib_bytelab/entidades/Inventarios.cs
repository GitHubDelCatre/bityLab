using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class Inventarios : EntidadBase
    {
        public int Producto { get; set; }
        public int Sucursal { get; set; }
        public int? CantidadDisponible { get; set; }
        public int? StockMinimo { get; set; }
        public string? EstanteriaUbicacion { get; set; }
        public DateTime? UltimaActualizacion { get; set; }
        public int? CapacidadBodega { get; set; }

        [ForeignKey("Producto")] public Productos? _Producto { get; set; }
        [ForeignKey("Sucursal")] public Sucursales? _Sucursal { get; set; }

        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (Producto <= 0) errores.Add("Producto");
            if (Sucursal <= 0) errores.Add("Sucursal");
            if (CantidadDisponible == null) errores.Add("Cantidad disponible");
            if (StockMinimo == null) errores.Add("Stock mínimo");
            if (CapacidadBodega == null) errores.Add("Capacidad de bodega");
            if (CantidadDisponible < 0 || StockMinimo < 0) errores.Add("Las cantidades no pueden ser negativas");
            if (CantidadDisponible > CapacidadBodega) errores.Add("La cantidad supera la capacidad de la bodega");
            return errores;
        }

        public override string ToString() => $"{_Producto} @ {_Sucursal}";

        [NotMapped] public bool RequiereReorden => CantidadDisponible <= StockMinimo;
    }
}
