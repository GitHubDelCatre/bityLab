using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class Roles : EntidadBase
    {
        public string? NombreRol { get; set; }
        public string? Descripcion { get; set; }
        public decimal? SalarioEstimado { get; set; }
        public bool EstadoActivo { get; set; }


        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(NombreRol)) errores.Add("Nombre del rol");
            return errores;
        }

        public override string ToString() => NombreRol ?? "";
    }
}
