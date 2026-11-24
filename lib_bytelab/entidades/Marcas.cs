using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class Marcas : EntidadBase
    {
        public string? NombreMarca { get; set; }
        public string? SitioWeb { get; set; }
        public string? CorreoSoporte { get; set; }
        public string? TelefonoContacto { get; set; }


        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(NombreMarca)) errores.Add("Marca");
            return errores;
        }

        public override string ToString() => NombreMarca ?? "";
    }
}
