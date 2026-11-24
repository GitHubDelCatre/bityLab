using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class ClientesModel : VentanaBase<Clientes>
    {
        private IUsuariosPresentacion IUsuariosPresentacion;

        public ClientesModel(IClientesPresentacion IClientesPresentacion,
            IUsuariosPresentacion IUsuariosPresentacion,
            IReportes IReportes) : base(IClientesPresentacion, IReportes)
        {
            this.IUsuariosPresentacion = IUsuariosPresentacion;
        }

        public override string Titulo => "Clientes";
        public override bool SoloLectura => false;

        public List<Usuarios> ListaUsuarios { get; set; } = new List<Usuarios>();

        protected override void CargarListas()
        {
            ListaUsuarios = this.IUsuariosPresentacion.Consultar();
        }
    }
}
