using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class Proveedores : EntidadBase
    {
        public string? NombreEmpresa { get; set; }
        public string? NitEmpresa { get; set; }
        public string? NombreContacto { get; set; }
        public string? TelefonoPrincipal { get; set; }
        public string? CorreoVentas { get; set; }
        public string? DireccionFisica { get; set; }


        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(NombreEmpresa)) errores.Add("Empresa");
            if (string.IsNullOrWhiteSpace(NitEmpresa)) errores.Add("NIT");
            return errores;
        }

        public override string ToString() => NombreEmpresa ?? "";
    }
}
