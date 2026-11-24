using lib_bytelab.entidades;

namespace front_bytelab.nucleo
{
    /// <summary>Todo lo que se guarda en la sesión del usuario que inició.</summary>
    public static class Sesion
    {
        public const string Usuario = "Usuario";
        public const string Nombre = "Nombre";
        public const string Rol = "Rol";
        public const string Permisos = "Permisos";
        public const string IdUsuario = "IdUsuario";

        public static void Iniciar(HttpContext contexto, Usuarios usuario)
        {
            contexto.Session.SetInt32(IdUsuario, usuario.Id);
            contexto.Session.SetString(Usuario, usuario.Correo ?? "");
            contexto.Session.SetString(Nombre, usuario.NombreCompleto ?? "");
            contexto.Session.SetString(Rol, usuario._Rol?.NombreRol ?? "");
            contexto.Session.SetString(Permisos, string.Join(",", usuario.Permisos ?? new List<string>()));
        }

        public static bool EstaLogueado(HttpContext contexto)
        {
            return !string.IsNullOrEmpty(contexto.Session.GetString(Usuario));
        }

        public static bool TienePermiso(HttpContext contexto, string codigo)
        {
            var permisos = contexto.Session.GetString(Permisos) ?? "";
            return permisos.Split(',').Contains(codigo);
        }

        public static bool TieneAlguno(HttpContext contexto, params string[] codigos)
        {
            return codigos.Any(x => TienePermiso(contexto, x));
        }

        public static string NombreUsuario(HttpContext contexto)
        {
            return contexto.Session.GetString(Nombre) ?? "";
        }

        public static string NombreRol(HttpContext contexto)
        {
            return contexto.Session.GetString(Rol) ?? "";
        }

        public static int IdDelUsuario(HttpContext contexto)
        {
            return contexto.Session.GetInt32(IdUsuario) ?? 0;
        }

        public static bool EsCliente(HttpContext contexto)
        {
            return NombreRol(contexto) == "Cliente";
        }
    }
}
