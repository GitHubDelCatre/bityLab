using System.ComponentModel.DataAnnotations.Schema;

namespace lib_bytelab.entidades
{
    public class RolesPermisos : EntidadBase
    {
        public int Rol { get; set; }
        public int Permiso { get; set; }

        [ForeignKey("Rol")] public Roles? _Rol { get; set; }
        [ForeignKey("Permiso")] public Permisos? _Permiso { get; set; }

        public override List<string> Validar()
        {
            var errores = new List<string>();
            if (Rol <= 0) errores.Add("Rol");
            if (Permiso <= 0) errores.Add("Permiso");
            return errores;
        }

        public override string ToString() => $"{_Rol} - {_Permiso}";
    }
}
