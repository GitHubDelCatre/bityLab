using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class EmpresasPaqueteria : EntidadBase
    {
        public string? NombrePaqueteria { get; set; }
        public string? Nit { get; set; }
        public string? Telefono { get; set; }
        public string? CorreoElectronico { get; set; }


        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(NombrePaqueteria)) errores.Add("Empresa");
            return errores;
        }

        public override string ToString() => NombrePaqueteria ?? "";
    }
}
