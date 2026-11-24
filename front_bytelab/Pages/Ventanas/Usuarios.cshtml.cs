using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class UsuariosModel : VentanaBase<Usuarios>
    {
        private IRolesPresentacion IRolesPresentacion;

        public UsuariosModel(IUsuariosPresentacion IUsuariosPresentacion,
            IRolesPresentacion IRolesPresentacion,
            IReportes IReportes) : base(IUsuariosPresentacion, IReportes)
        {
            this.IRolesPresentacion = IRolesPresentacion;
        }

        public override string Titulo => "Usuarios";
        public override bool SoloLectura => false;

        public List<Roles> ListaRoles { get; set; } = new List<Roles>();

        protected override void CargarListas()
        {
            ListaRoles = this.IRolesPresentacion.Consultar();
        }

        protected override void Inicializar(Usuarios entidad)
        {
            entidad.CuentaActiva = true;
        }
    }
}
