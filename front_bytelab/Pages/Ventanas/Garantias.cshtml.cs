using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class GarantiasModel : VentanaBase<Garantias>
    {
        private IDetallesVentasPresentacion IDetallesVentasPresentacion;

        public GarantiasModel(IGarantiasPresentacion IGarantiasPresentacion,
            IDetallesVentasPresentacion IDetallesVentasPresentacion,
            IReportes IReportes) : base(IGarantiasPresentacion, IReportes)
        {
            this.IDetallesVentasPresentacion = IDetallesVentasPresentacion;
        }

        public override string Titulo => "Garantías";
        public override bool SoloLectura => false;

        public List<DetallesVentas> ListaDetallesVentas { get; set; } = new List<DetallesVentas>();

        protected override void CargarListas()
        {
            ListaDetallesVentas = this.IDetallesVentasPresentacion.Consultar();
        }
    }
}
