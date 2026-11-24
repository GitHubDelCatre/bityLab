using lib_bytelab.entidades;
using lib_bytelab.nucleo;

namespace pruebas_bytelab.Unitarias
{
    /// <summary>Pruebas de la lógica de negocio que no necesitan base de datos ni API.</summary>
    [TestClass]
    public class ReglasPrueba
    {
        [TestMethod]
        public void SubtotalDeVenta()
        {
            Assert.AreEqual(1798000m - 50000m, DetallesVentas.CalcularSubtotal(2, 899000m, 50000m));
            Assert.AreEqual(0m, DetallesVentas.CalcularSubtotal(1, 100m, 500m), "No puede quedar negativo");
        }

        [TestMethod]
        public void TotalDeVentaConPromocion()
        {
            var total = Ventas.CalcularTotal(new List<decimal> { 899000m, 289000m }, 10m);
            Assert.AreEqual(1069200m, total);
            Assert.AreEqual(100m, Ventas.CalcularTotal(new List<decimal> { 100m }, null));
        }

        [TestMethod]
        public void SubtotalDeOrdenDeCompra()
        {
            Assert.AreEqual(3500000m, DetallesOrdenesCompras.CalcularSubtotal(5, 700000m));
        }

        [TestMethod]
        public void PromocionVigente()
        {
            var promocion = new Promociones()
            {
                EstadoActiva = true,
                FechaInicio = DateTime.Today.AddDays(-1),
                FechaFin = DateTime.Today.AddDays(1)
            };
            Assert.IsTrue(promocion.EstaVigente(DateTime.Now));
            Assert.IsFalse(promocion.EstaVigente(DateTime.Today.AddDays(5)));
        }

        [TestMethod]
        public void ValidacionesDeEntidades()
        {
            Assert.IsTrue(new Productos().FaltaInformacion());
            Assert.IsTrue(new Resenas() { Producto = 1, Cliente = 1, CalificacionEstrellas = 7, FechaPublicacion = DateTime.Now }.FaltaInformacion());
            Assert.IsTrue(new Promociones() { CodigoCupon = "X", PorcentajeDescuento = 150, FechaInicio = DateTime.Now, FechaFin = DateTime.Now }.FaltaInformacion());
            Assert.IsFalse(new Categorias() { Nombre = "Procesadores" }.FaltaInformacion());
        }

        [TestMethod]
        public void UsuarioNuevoNecesitaContrasena()
        {
            var usuario = new Usuarios() { Rol = 1, NombreCompleto = "Ana", Cedula = "1", Correo = "ana@correo.com" };
            Assert.IsTrue(usuario.Validar().Contains("Contraseña"));
            usuario.Contrasena = "Segura.123";
            Assert.IsFalse(usuario.FaltaInformacion());
        }

        [TestMethod]
        public void InventarioRequiereReorden()
        {
            Assert.IsTrue(new Inventarios() { CantidadDisponible = 3, StockMinimo = 5 }.RequiereReorden);
            Assert.IsFalse(new Inventarios() { CantidadDisponible = 30, StockMinimo = 5 }.RequiereReorden);
        }

        [TestMethod]
        public void CifradoDeContrasena()
        {
            var hash = Seguridad.Cifrar("Admin.123");
            Assert.AreEqual(64, hash.Length);
            Assert.AreEqual(hash, Seguridad.Cifrar("Admin.123"));
            Assert.AreNotEqual(hash, Seguridad.Cifrar("admin.123"));
        }
    }
}
