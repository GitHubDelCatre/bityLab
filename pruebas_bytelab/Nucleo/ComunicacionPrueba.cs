using lib_bytelab.entidades;
using lib_bytelab.nucleo;
using presentaciones_bytelab.implementaciones;
using presentaciones_bytelab.interfaces;

namespace pruebas_bytelab.Nucleo
{
    /// <summary>
    /// Pruebas de la capa de comunicaciones/presentación de una entidad.
    /// Las dos primeras no necesitan la API (usan una comunicación falsa);
    /// la de integración llama la API real (debe estar corriendo servicio_bytelab).
    /// </summary>
    public abstract class ComunicacionPrueba<T> where T : EntidadBase, new()
    {
        protected abstract IPresentacionBase<T> CrearPresentacion(IComunicaciones comunicaciones);

        [TestMethod]
        public void ArmaLaRutaDelServicio()
        {
            var falsa = new ComunicacionesFalsa();
            CrearPresentacion(falsa).Consultar();
            Assert.AreEqual(typeof(T).Name + "/Consultar", falsa.UltimaUrl);
        }

        [TestMethod]
        public void NoEnviaSiFaltaInformacion()
        {
            var falsa = new ComunicacionesFalsa();
            var lanzoError = false;
            try
            {
                CrearPresentacion(falsa).Insertar(new T());
            }
            catch (Exception)
            {
                lanzoError = true;
            }
            Assert.IsTrue(lanzoError, "Debió validar antes de llamar la API");
            Assert.AreEqual(0, falsa.Llamadas);
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void ConsultarDesdeLaApi()
        {
            try
            {
                var presentacion = CrearPresentacion(new presentaciones_bytelab.implementaciones.Comunicaciones(DatosGenerales.UrlServicio()));
                Assert.IsNotNull(presentacion.Consultar());
            }
            catch (AggregateException ex) when (ex.GetBaseException() is HttpRequestException)
            {
                Assert.Inconclusive("La API no está encendida en " + DatosGenerales.UrlServicio());
            }
        }
    }

    public class ComunicacionesFalsa : IComunicaciones
    {
        public int Llamadas { get; private set; }
        public string? UltimaUrl { get; private set; }

        public Task<T> Ejecutar<T>(string url, object? entidad)
        {
            Llamadas++;
            UltimaUrl = url;
            return Task.FromResult((T)Activator.CreateInstance(typeof(T))!);
        }
    }
}
