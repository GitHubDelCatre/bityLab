using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class UsuariosAplicacion : AplicacionBase<Usuarios>, IUsuariosAplicacion
    {
        public UsuariosAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<Usuarios> Consulta()
        {
            return this.IConexion.Usuarios!
                .Include(x => x._Rol);
        }

        protected override IQueryable<Usuarios> Filtrar(IQueryable<Usuarios> consulta, Usuarios filtro)
        {
            var texto = filtro.NombreCompleto ?? "";
            return consulta.Where(x => texto == "" || x.NombreCompleto!.Contains(texto));
        }

        protected override void AntesDeGuardar(Usuarios entidad)
        {
            if (entidad.Id == 0)
            {
                entidad.FechaRegistro = DateTime.Now;
                entidad.ContrasenaHash = Seguridad.Cifrar(entidad.Contrasena!);
            }
            else
            {
                var actual = this.IConexion.Usuarios!.AsNoTracking()
                    .FirstOrDefault(x => x.Id == entidad.Id)
                    ?? throw new Exception("El usuario no existe");
                entidad.FechaRegistro = actual.FechaRegistro;
                entidad.ContrasenaHash = string.IsNullOrWhiteSpace(entidad.Contrasena)
                    ? actual.ContrasenaHash
                    : Seguridad.Cifrar(entidad.Contrasena);
            }
            entidad.Contrasena = null;
        }

        public Usuarios Login(Usuarios entidad)
        {
            if (string.IsNullOrWhiteSpace(entidad.Correo) || string.IsNullOrWhiteSpace(entidad.Contrasena))
                throw new Exception("Ingrese el correo y la contraseña");

            var hash = Seguridad.Cifrar(entidad.Contrasena);
            var usuario = this.IConexion.Usuarios!
                .Include(x => x._Rol)
                .FirstOrDefault(x => x.Correo == entidad.Correo && x.ContrasenaHash == hash);

            if (usuario == null)
                throw new Exception("Correo o contraseña incorrectos");
            if (!usuario.CuentaActiva)
                throw new Exception("La cuenta está inactiva");

            usuario.Permisos = this.IConexion.RolesPermisos!
                .Where(x => x.Rol == usuario.Rol)
                .Select(x => x._Permiso!.Codigo!)
                .ToList();

            // El inicio de sesión también queda auditado
            this.IConexion.Auditorias!.Add(new Auditorias()
            {
                Entidad = "Usuarios",
                Accion = "Login",
                IdRegistro = usuario.Id,
                Usuario = usuario.Correo,
                Fecha = DateTime.Now,
                Datos = "{}"
            });
            this.IConexion.SaveChanges();
            return usuario;
        }
    }
}
