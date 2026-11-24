using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class DetallesVentasModel : VentanaBase<DetallesVentas>
    {
        private IVentasPresentacion IVentasPresentacion;
        private IProductosPresentacion IProductosPresentacion;

        public DetallesVentasModel(IDetallesVentasPresentacion IDetallesVentasPresentacion,
            IVentasPresentacion IVentasPresentacion,
            IProductosPresentacion IProductosPresentacion,
            IReportes IReportes) : base(IDetallesVentasPresentacion, IReportes)
        {
            this.IVentasPresentacion = IVentasPresentacion;
            this.IProductosPresentacion = IProductosPresentacion;
        }

        public override string Titulo => "Detalles de ventas";
        public override bool SoloLectura => false;

        public List<Ventas> ListaVentas { get; set; } = new List<Ventas>();
        public List<Productos> ListaProductos { get; set; } = new List<Productos>();

        protected override void CargarListas()
        {
            ListaVentas = this.IVentasPresentacion.Consultar();
            ListaProductos = this.IProductosPresentacion.Consultar();
        }
    }
}
