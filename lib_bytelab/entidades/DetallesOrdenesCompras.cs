using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class DetallesOrdenesCompras : EntidadBase
    {
        public int ComprasProducto { get; set; }
        public int Producto { get; set; }
        public int? CantidadSolicitada { get; set; }
        public decimal? CostoUnitario { get; set; }
        public decimal? SubtotalCosto { get; set; }

        [ForeignKey("ComprasProducto")] public ComprasProductos? _ComprasProducto { get; set; }
        [ForeignKey("Producto")] public Productos? _Producto { get; set; }

        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (ComprasProducto <= 0) errores.Add("Orden de compra");
            if (Producto <= 0) errores.Add("Producto");
            if (CantidadSolicitada == null) errores.Add("Cantidad");
            if (CostoUnitario == null) errores.Add("Costo unitario");
            if (CantidadSolicitada != null && CantidadSolicitada <= 0) errores.Add("La cantidad debe ser mayor a cero");
            return errores;
        }

        public override string ToString() => $"Orden #{ComprasProducto} - {_Producto}";

        public static decimal CalcularSubtotal(int? cantidad, decimal? costoUnitario)
        {
            return Math.Round((cantidad ?? 0) * (costoUnitario ?? 0), 2);
        }
    }
}
