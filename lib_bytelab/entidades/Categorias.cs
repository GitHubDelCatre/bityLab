using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class Categorias : EntidadBase
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }


        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(Nombre)) errores.Add("Nombre");
            return errores;
        }

        public override string ToString() => Nombre ?? "";
    }
}
