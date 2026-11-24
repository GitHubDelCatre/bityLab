using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class VentasModel : VentanaBase<Ventas>
    {
        private IClientesPresentacion IClientesPresentacion;
        private ISucursalesPresentacion ISucursalesPresentacion;
        private IPromocionesPresentacion IPromocionesPresentacion;

        public VentasModel(IVentasPresentacion IVentasPresentacion,
            IClientesPresentacion IClientesPresentacion,
            ISucursalesPresentacion ISucursalesPresentacion,
            IPromocionesPresentacion IPromocionesPresentacion,
            IReportes IReportes) : base(IVentasPresentacion, IReportes)
        {
            this.IClientesPresentacion = IClientesPresentacion;
            this.ISucursalesPresentacion = ISucursalesPresentacion;
            this.IPromocionesPresentacion = IPromocionesPresentacion;
        }

        public override string Titulo => "Ventas";
        public override bool SoloLectura => false;

        public List<Clientes> ListaClientes { get; set; } = new List<Clientes>();
        public List<Sucursales> ListaSucursales { get; set; } = new List<Sucursales>();
        public List<Promociones> ListaPromociones { get; set; } = new List<Promociones>();

        protected override void CargarListas()
        {
            ListaClientes = this.IClientesPresentacion.Consultar();
            ListaSucursales = this.ISucursalesPresentacion.Consultar();
            ListaPromociones = this.IPromocionesPresentacion.Consultar();
        }

        protected override void Inicializar(Ventas entidad)
        {
            entidad.FechaVenta = DateTime.Now;
            entidad.EstadoVenta = "Pendiente";
        }
    }
}
