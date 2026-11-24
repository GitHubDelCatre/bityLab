using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class Empleados : EntidadBase
    {
        public int Usuario { get; set; }
        public int Sucursal { get; set; }
        public string? CargoPuesto { get; set; }
        public decimal? Salario { get; set; }
        public DateTime? FechaContratacion { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }
        [ForeignKey("Sucursal")] public Sucursales? _Sucursal { get; set; }

        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (Usuario <= 0) errores.Add("Usuario");
            if (Sucursal <= 0) errores.Add("Sucursal");
            if (string.IsNullOrWhiteSpace(CargoPuesto)) errores.Add("Cargo");
            if (Salario == null) errores.Add("Salario");
            if (FechaContratacion == null) errores.Add("Fecha de contratación");
            return errores;
        }

        public override string ToString() => _Usuario?.NombreCompleto ?? $"Empleado {Id}";
    }
}
