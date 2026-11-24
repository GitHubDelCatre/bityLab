using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class EmpleadosModel : VentanaBase<Empleados>
    {
        private IUsuariosPresentacion IUsuariosPresentacion;
        private ISucursalesPresentacion ISucursalesPresentacion;

        public EmpleadosModel(IEmpleadosPresentacion IEmpleadosPresentacion,
            IUsuariosPresentacion IUsuariosPresentacion,
            ISucursalesPresentacion ISucursalesPresentacion,
            IReportes IReportes) : base(IEmpleadosPresentacion, IReportes)
        {
            this.IUsuariosPresentacion = IUsuariosPresentacion;
            this.ISucursalesPresentacion = ISucursalesPresentacion;
        }

        public override string Titulo => "Empleados";
        public override bool SoloLectura => false;

        public List<Usuarios> ListaUsuarios { get; set; } = new List<Usuarios>();
        public List<Sucursales> ListaSucursales { get; set; } = new List<Sucursales>();

        protected override void CargarListas()
        {
            ListaUsuarios = this.IUsuariosPresentacion.Consultar();
            ListaSucursales = this.ISucursalesPresentacion.Consultar();
        }
    }
}
