using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class ProductosModel : VentanaBase<Productos>
    {
        private ICategoriasPresentacion ICategoriasPresentacion;
        private IMarcasPresentacion IMarcasPresentacion;

        public ProductosModel(IProductosPresentacion IProductosPresentacion,
            ICategoriasPresentacion ICategoriasPresentacion,
            IMarcasPresentacion IMarcasPresentacion,
            IReportes IReportes) : base(IProductosPresentacion, IReportes)
        {
            this.ICategoriasPresentacion = ICategoriasPresentacion;
            this.IMarcasPresentacion = IMarcasPresentacion;
        }

        public override string Titulo => "Productos";
        public override bool SoloLectura => false;

        public List<Categorias> ListaCategorias { get; set; } = new List<Categorias>();
        public List<Marcas> ListaMarcas { get; set; } = new List<Marcas>();

        protected override void CargarListas()
        {
            ListaCategorias = this.ICategoriasPresentacion.Consultar();
            ListaMarcas = this.IMarcasPresentacion.Consultar();
        }
    }
}
