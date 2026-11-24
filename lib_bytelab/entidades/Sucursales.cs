using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class Sucursales : EntidadBase
    {
        public string? NombreSucursal { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? TelefonoContacto { get; set; }
        public string? HorarioAtencion { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }


        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(NombreSucursal)) errores.Add("Nombre");
            if (string.IsNullOrWhiteSpace(Direccion)) errores.Add("Dirección");
            if (string.IsNullOrWhiteSpace(Ciudad)) errores.Add("Ciudad");
            if (string.IsNullOrWhiteSpace(HorarioAtencion)) errores.Add("Horario de atención");
            return errores;
        }

        public override string ToString() => NombreSucursal ?? "";
    }
}
