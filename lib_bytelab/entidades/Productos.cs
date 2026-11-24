using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class Productos : EntidadBase, IConImagen
    {
        public int Categoria { get; set; }
        public int Marca { get; set; }
        public string? NombreProducto { get; set; }
        public string? DescripcionLarga { get; set; }
        public decimal? PrecioVenta { get; set; }
        public string? NumeroSerie { get; set; }
        public string? Modelo { get; set; }
        public string? EspecificacionesTecnicas { get; set; }
        public string? Imagen { get; set; }

        [ForeignKey("Categoria")] public Categorias? _Categoria { get; set; }
        [ForeignKey("Marca")] public Marcas? _Marca { get; set; }

        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (Categoria <= 0) errores.Add("Categoría");
            if (Marca <= 0) errores.Add("Marca");
            if (string.IsNullOrWhiteSpace(NombreProducto)) errores.Add("Producto");
            if (PrecioVenta == null) errores.Add("Precio de venta");
            if (PrecioVenta != null && PrecioVenta < 0) errores.Add("Precio de venta no puede ser negativo");
            return errores;
        }

        public override string ToString() => NombreProducto ?? "";
    }
}
