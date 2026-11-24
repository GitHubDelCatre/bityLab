using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class Auditorias : EntidadBase
    {
        public string? Entidad { get; set; }
        public string? Accion { get; set; }
        public int? IdRegistro { get; set; }
        public string? Usuario { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Datos { get; set; }


        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(Entidad)) errores.Add("Entidad");
            if (string.IsNullOrWhiteSpace(Accion)) errores.Add("Acción");
            if (IdRegistro == null) errores.Add("Id registro");
            if (string.IsNullOrWhiteSpace(Usuario)) errores.Add("Usuario");
            if (Fecha == null) errores.Add("Fecha");
            return errores;
        }

        public override string ToString() => $"{Accion} {Entidad} #{IdRegistro}";
    }
}
