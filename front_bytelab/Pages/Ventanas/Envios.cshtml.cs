using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class EnviosModel : VentanaBase<Envios>
    {
        private IVentasPresentacion IVentasPresentacion;
        private IEmpresasPaqueteriaPresentacion IEmpresasPaqueteriaPresentacion;

        public EnviosModel(IEnviosPresentacion IEnviosPresentacion,
            IVentasPresentacion IVentasPresentacion,
            IEmpresasPaqueteriaPresentacion IEmpresasPaqueteriaPresentacion,
            IReportes IReportes) : base(IEnviosPresentacion, IReportes)
        {
            this.IVentasPresentacion = IVentasPresentacion;
            this.IEmpresasPaqueteriaPresentacion = IEmpresasPaqueteriaPresentacion;
        }

        public override string Titulo => "Envíos";
        public override bool SoloLectura => false;

        public List<Ventas> ListaVentas { get; set; } = new List<Ventas>();
        public List<EmpresasPaqueteria> ListaEmpresasPaqueteria { get; set; } = new List<EmpresasPaqueteria>();

        protected override void CargarListas()
        {
            ListaVentas = this.IVentasPresentacion.Consultar();
            ListaEmpresasPaqueteria = this.IEmpresasPaqueteriaPresentacion.Consultar();
        }
    }
}
