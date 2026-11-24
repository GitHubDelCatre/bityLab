using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class Resenas : EntidadBase
    {
        public int Producto { get; set; }
        public int Cliente { get; set; }
        public int? CalificacionEstrellas { get; set; }
        public string? Comentario { get; set; }
        public DateTime? FechaPublicacion { get; set; }

        [ForeignKey("Producto")] public Productos? _Producto { get; set; }
        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }

        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (Producto <= 0) errores.Add("Producto");
            if (Cliente <= 0) errores.Add("Cliente");
            if (CalificacionEstrellas == null) errores.Add("Calificación (1-5)");
            if (FechaPublicacion == null) errores.Add("Fecha de publicación");
            if (CalificacionEstrellas != null && (CalificacionEstrellas < 1 || CalificacionEstrellas > 5)) errores.Add("La calificación debe estar entre 1 y 5");
            return errores;
        }

        public override string ToString() => $"{_Producto} ({CalificacionEstrellas}★)";
    }
}
