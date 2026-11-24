using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class InventariosModel : VentanaBase<Inventarios>
    {
        private IProductosPresentacion IProductosPresentacion;
        private ISucursalesPresentacion ISucursalesPresentacion;

        public InventariosModel(IInventariosPresentacion IInventariosPresentacion,
            IProductosPresentacion IProductosPresentacion,
            ISucursalesPresentacion ISucursalesPresentacion,
            IReportes IReportes) : base(IInventariosPresentacion, IReportes)
        {
            this.IProductosPresentacion = IProductosPresentacion;
            this.ISucursalesPresentacion = ISucursalesPresentacion;
        }

        public override string Titulo => "Inventarios";
        public override bool SoloLectura => false;

        public List<Productos> ListaProductos { get; set; } = new List<Productos>();
        public List<Sucursales> ListaSucursales { get; set; } = new List<Sucursales>();

        protected override void CargarListas()
        {
            ListaProductos = this.IProductosPresentacion.Consultar();
            ListaSucursales = this.ISucursalesPresentacion.Consultar();
        }
    }
}
