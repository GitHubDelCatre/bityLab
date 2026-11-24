using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class DetallesOrdenesComprasModel : VentanaBase<DetallesOrdenesCompras>
    {
        private IComprasProductosPresentacion IComprasProductosPresentacion;
        private IProductosPresentacion IProductosPresentacion;

        public DetallesOrdenesComprasModel(IDetallesOrdenesComprasPresentacion IDetallesOrdenesComprasPresentacion,
            IComprasProductosPresentacion IComprasProductosPresentacion,
            IProductosPresentacion IProductosPresentacion,
            IReportes IReportes) : base(IDetallesOrdenesComprasPresentacion, IReportes)
        {
            this.IComprasProductosPresentacion = IComprasProductosPresentacion;
            this.IProductosPresentacion = IProductosPresentacion;
        }

        public override string Titulo => "Detalles de órdenes de compra";
        public override bool SoloLectura => false;

        public List<ComprasProductos> ListaComprasProductos { get; set; } = new List<ComprasProductos>();
        public List<Productos> ListaProductos { get; set; } = new List<Productos>();

        protected override void CargarListas()
        {
            ListaComprasProductos = this.IComprasProductosPresentacion.Consultar();
            ListaProductos = this.IProductosPresentacion.Consultar();
        }
    }
}
