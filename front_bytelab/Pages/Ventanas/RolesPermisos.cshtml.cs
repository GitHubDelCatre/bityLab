using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class RolesPermisosModel : VentanaBase<RolesPermisos>
    {
        private IRolesPresentacion IRolesPresentacion;
        private IPermisosPresentacion IPermisosPresentacion;

        public RolesPermisosModel(IRolesPermisosPresentacion IRolesPermisosPresentacion,
            IRolesPresentacion IRolesPresentacion,
            IPermisosPresentacion IPermisosPresentacion,
            IReportes IReportes) : base(IRolesPermisosPresentacion, IReportes)
        {
            this.IRolesPresentacion = IRolesPresentacion;
            this.IPermisosPresentacion = IPermisosPresentacion;
        }

        public override string Titulo => "Permisos por rol";
        public override bool SoloLectura => false;

        public List<Roles> ListaRoles { get; set; } = new List<Roles>();
        public List<Permisos> ListaPermisos { get; set; } = new List<Permisos>();

        protected override void CargarListas()
        {
            ListaRoles = this.IRolesPresentacion.Consultar();
            ListaPermisos = this.IPermisosPresentacion.Consultar();
        }
    }
}
