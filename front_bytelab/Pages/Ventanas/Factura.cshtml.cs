using front_bytelab.nucleo;
using lib_bytelab.entidades;
using lib_bytelab.nucleo;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    /// <summary>Aplicación específica: factura de una venta lista para imprimir.</summary>
    public class FacturaModel : PaginaSegura
    {
        private IVentasPresentacion IVentasPresentacion;
        private IDetallesVentasPresentacion IDetallesVentasPresentacion;
        private IPagosPresentacion IPagosPresentacion;

        public FacturaModel(IVentasPresentacion IVentasPresentacion,
            IDetallesVentasPresentacion IDetallesVentasPresentacion,
            IPagosPresentacion IPagosPresentacion)
        {
            this.IVentasPresentacion = IVentasPresentacion;
            this.IDetallesVentasPresentacion = IDetallesVentasPresentacion;
            this.IPagosPresentacion = IPagosPresentacion;
        }

        public override string Permiso => "Ventas";
        public Ventas? Venta { get; set; }
        public List<DetallesVentas> Detalles { get; set; } = new List<DetallesVentas>();
        public List<Pagos> Pagos { get; set; } = new List<Pagos>();
        public decimal SumaDetalles => Detalles.Sum(x => x.Subtotal ?? 0);

        public void OnGet(int id)
        {
            try
            {
                Venta = this.IVentasPresentacion.Consultar().FirstOrDefault(x => x.Id == id);
                Detalles = this.IDetallesVentasPresentacion.Consultar().Where(x => x.Venta == id).ToList();
                Pagos = this.IPagosPresentacion.Consultar().Where(x => x.Venta == id).ToList();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
