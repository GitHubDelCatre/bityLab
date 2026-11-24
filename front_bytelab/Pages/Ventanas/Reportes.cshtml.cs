using front_bytelab.nucleo;
using lib_bytelab.entidades;
using lib_bytelab.nucleo;
using Microsoft.AspNetCore.Mvc;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    /// <summary>Punto investigativo: reportes consolidados en PDF y Excel.</summary>
    public class ReportesModel : PaginaSegura
    {
        private IReportes IReportes;
        private IInventariosPresentacion IInventariosPresentacion;
        private IVentasPresentacion IVentasPresentacion;
        private IDetallesVentasPresentacion IDetallesVentasPresentacion;

        public ReportesModel(IReportes IReportes,
            IInventariosPresentacion IInventariosPresentacion,
            IVentasPresentacion IVentasPresentacion,
            IDetallesVentasPresentacion IDetallesVentasPresentacion)
        {
            this.IReportes = IReportes;
            this.IInventariosPresentacion = IInventariosPresentacion;
            this.IVentasPresentacion = IVentasPresentacion;
            this.IDetallesVentasPresentacion = IDetallesVentasPresentacion;
        }

        public override string Permiso => "Reportes";
        public List<Inventarios> BajoStock { get; set; } = new List<Inventarios>();
        public List<(string Sucursal, int Cantidad, decimal Total)> VentasPorSucursal { get; set; } = new();
        public List<(string Producto, int Unidades, decimal Total)> MasVendidos { get; set; } = new();
        public decimal TotalVendido { get; set; }
        public int NumeroVentas { get; set; }

        public void OnGet()
        {
            Cargar();
        }

        public IActionResult OnPostBtBajoStockPdf()
        {
            Cargar();
            var filas = BajoStock.Select(x => new List<object?>
            {
                x._Producto?.ToString(), x._Sucursal?.ToString(), x.CantidadDisponible, x.StockMinimo, x.EstanteriaUbicacion
            }).ToList();
            var pdf = this.IReportes.PdfTabla("Productos por debajo del stock mínimo", BajoStock.Count + " producto(s) para reordenar",
                new List<string> { "Producto", "Sucursal", "Disponible", "Mínimo", "Ubicación" }, filas);
            return File(pdf, "application/pdf", "BajoStock.pdf");
        }

        public IActionResult OnPostBtVentasSucursalPdf()
        {
            Cargar();
            var filas = VentasPorSucursal.Select(x => new List<object?> { x.Sucursal, x.Cantidad, x.Total }).ToList();
            var pdf = this.IReportes.PdfTabla("Ventas por sucursal", "Total vendido: $ " + TotalVendido.ToString("N0"),
                new List<string> { "Sucursal", "Número de ventas", "Total vendido" }, filas);
            return File(pdf, "application/pdf", "VentasPorSucursal.pdf");
        }

        public IActionResult OnPostBtMasVendidosExcel()
        {
            Cargar();
            var filas = MasVendidos.Select(x => new List<object?> { x.Producto, x.Unidades, x.Total }).ToList();
            var excel = this.IReportes.ExcelTabla("Productos más vendidos",
                new List<string> { "Producto", "Unidades", "Total vendido" }, filas);
            return File(excel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MasVendidos.xlsx");
        }

        public IActionResult OnPostBtVentasExcel()
        {
            Cargar();
            var ventas = this.IVentasPresentacion.Consultar();
            return File(this.IReportes.Excel("Ventas", ventas),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Ventas.xlsx");
        }

        private void Cargar()
        {
            try
            {
                BajoStock = this.IInventariosPresentacion.Consultar().Where(x => x.RequiereReorden).ToList();

                var ventas = this.IVentasPresentacion.Consultar().Where(x => x.EstadoVenta != "Cancelada").ToList();
                NumeroVentas = ventas.Count;
                TotalVendido = ventas.Sum(x => x.TotalPagar ?? 0);
                VentasPorSucursal = ventas
                    .GroupBy(x => x._Sucursal?.ToString() ?? "Sin sucursal")
                    .Select(g => (g.Key, g.Count(), g.Sum(x => x.TotalPagar ?? 0)))
                    .OrderByDescending(x => x.Item3)
                    .ToList();

                MasVendidos = this.IDetallesVentasPresentacion.Consultar()
                    .GroupBy(x => x._Producto?.ToString() ?? "Producto " + x.Producto)
                    .Select(g => (g.Key, g.Sum(x => x.Cantidad ?? 0), g.Sum(x => x.Subtotal ?? 0)))
                    .OrderByDescending(x => x.Item2)
                    .Take(10)
                    .ToList();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
