using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class Clientes : EntidadBase
    {
        public int Usuario { get; set; }
        public string? Telefono { get; set; }
        public string? DireccionPrincipal { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }

        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (Usuario <= 0) errores.Add("Usuario");
            return errores;
        }

        public override string ToString() => _Usuario?.NombreCompleto ?? $"Cliente {Id}";
    }
}
