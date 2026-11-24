using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class Usuarios : EntidadBase
    {
        public int Rol { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Cedula { get; set; }
        public string? Correo { get; set; }
        [Column("Contrasena")]
        [System.Text.Json.Serialization.JsonIgnore]
        public string? ContrasenaHash { get; set; }
        [NotMapped] public string? Contrasena { get; set; }
        [NotMapped] public List<string>? Permisos { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool CuentaActiva { get; set; }

        [ForeignKey("Rol")] public Roles? _Rol { get; set; }

        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (Rol <= 0) errores.Add("Rol");
            if (string.IsNullOrWhiteSpace(NombreCompleto)) errores.Add("Nombre completo");
            if (string.IsNullOrWhiteSpace(Cedula)) errores.Add("Cédula");
            if (string.IsNullOrWhiteSpace(Correo)) errores.Add("Correo");
            if (Id == 0 && string.IsNullOrWhiteSpace(Contrasena)) errores.Add("Contraseña");
            if (!string.IsNullOrWhiteSpace(Correo) && !Correo.Contains('@')) errores.Add("El correo no es válido");
            if (!string.IsNullOrWhiteSpace(Contrasena) && Contrasena.Length < 6) errores.Add("La contraseña debe tener mínimo 6 caracteres");
            return errores;
        }

        public override string ToString() => NombreCompleto ?? "";
    }
}
