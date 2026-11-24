using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class UsuariosPresentacion : PresentacionBase<Usuarios>, IUsuariosPresentacion
    {
        public UsuariosPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }

        public Usuarios Login(Usuarios entidad)
        {
            if (string.IsNullOrWhiteSpace(entidad.Correo) || string.IsNullOrWhiteSpace(entidad.Contrasena))
                throw new Exception("Ingrese el correo y la contraseña");
            return Ejecutar<Usuarios>("Login", entidad);
        }
    }
}
