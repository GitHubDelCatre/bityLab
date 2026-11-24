using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class ComprasProductosModel : VentanaBase<ComprasProductos>
    {
        private IProveedoresPresentacion IProveedoresPresentacion;
        private ISucursalesPresentacion ISucursalesPresentacion;

        public ComprasProductosModel(IComprasProductosPresentacion IComprasProductosPresentacion,
            IProveedoresPresentacion IProveedoresPresentacion,
            ISucursalesPresentacion ISucursalesPresentacion,
            IReportes IReportes) : base(IComprasProductosPresentacion, IReportes)
        {
            this.IProveedoresPresentacion = IProveedoresPresentacion;
            this.ISucursalesPresentacion = ISucursalesPresentacion;
        }

        public override string Titulo => "Órdenes de compra";
        public override bool SoloLectura => false;

        public List<Proveedores> ListaProveedores { get; set; } = new List<Proveedores>();
        public List<Sucursales> ListaSucursales { get; set; } = new List<Sucursales>();

        protected override void CargarListas()
        {
            ListaProveedores = this.IProveedoresPresentacion.Consultar();
            ListaSucursales = this.ISucursalesPresentacion.Consultar();
        }

        protected override void Inicializar(ComprasProductos entidad)
        {
            entidad.FechaOrden = DateTime.Now;
            entidad.EstadoOrden = "Pendiente";
        }
    }
}
