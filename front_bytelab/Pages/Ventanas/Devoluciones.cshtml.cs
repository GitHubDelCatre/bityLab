using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class DevolucionesModel : VentanaBase<Devoluciones>
    {
        private IVentasPresentacion IVentasPresentacion;
        private IMetodosPagoPresentacion IMetodosPagoPresentacion;

        public DevolucionesModel(IDevolucionesPresentacion IDevolucionesPresentacion,
            IVentasPresentacion IVentasPresentacion,
            IMetodosPagoPresentacion IMetodosPagoPresentacion,
            IReportes IReportes) : base(IDevolucionesPresentacion, IReportes)
        {
            this.IVentasPresentacion = IVentasPresentacion;
            this.IMetodosPagoPresentacion = IMetodosPagoPresentacion;
        }

        public override string Titulo => "Devoluciones";
        public override bool SoloLectura => false;

        public List<Ventas> ListaVentas { get; set; } = new List<Ventas>();
        public List<MetodosPago> ListaMetodosPago { get; set; } = new List<MetodosPago>();

        protected override void CargarListas()
        {
            ListaVentas = this.IVentasPresentacion.Consultar();
            ListaMetodosPago = this.IMetodosPagoPresentacion.Consultar();
        }
    }
}
