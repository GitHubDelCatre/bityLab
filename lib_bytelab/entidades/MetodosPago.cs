using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class MetodosPago : EntidadBase
    {
        public string? NombreMetodo { get; set; }
        public string? Descripcion { get; set; }
        public bool RequiereAprobacion { get; set; }
        public bool Activo { get; set; }


        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(NombreMetodo)) errores.Add("Método");
            return errores;
        }

        public override string ToString() => NombreMetodo ?? "";
    }
}
