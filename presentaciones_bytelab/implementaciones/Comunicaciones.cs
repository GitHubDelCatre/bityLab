using System.Text;
using lib_bytelab.nucleo;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    /// <summary>Se encarga de hablar con la API (servicio_bytelab) por HTTP + JSON.</summary>
    public class Comunicaciones : IComunicaciones
    {
        private static readonly HttpClient ClienteHttp = new HttpClient() { Timeout = TimeSpan.FromMinutes(4) };
        private readonly string urlBase;
        private readonly IHttpContextAccessor? IHttpContextAccessor;

        // La usa el front (inyección de dependencias)
        public Comunicaciones(IConfiguration configuracion, IHttpContextAccessor IHttpContextAccessor)
        {
            this.urlBase = configuracion["UrlServicio"] ?? DatosGenerales.UrlServicio();
            this.IHttpContextAccessor = IHttpContextAccessor;
        }

        // La usan las pruebas
        public Comunicaciones(string urlBase)
        {
            this.urlBase = urlBase;
        }

        public async Task<T> Ejecutar<T>(string url, object? entidad)
        {
            var direccion = this.urlBase.TrimEnd('/') + "/" + url;

            using var mensaje = new HttpRequestMessage(HttpMethod.Post, direccion);
            mensaje.Content = new StringContent(JsonConvert.SerializeObject(entidad), Encoding.UTF8, "application/json");

            // Se envía el usuario de la sesión para la auditoría
            var usuario = this.IHttpContextAccessor?.HttpContext?.Session.GetString("Usuario");
            if (!string.IsNullOrEmpty(usuario))
                mensaje.Headers.Add("Usuario", usuario);

            using var respuesta = await ClienteHttp.SendAsync(mensaje);
            var contenido = await respuesta.Content.ReadAsStringAsync();

            if (!respuesta.IsSuccessStatusCode)
                throw new Exception(string.IsNullOrWhiteSpace(contenido)
                    ? "Error Comunicacion (" + (int)respuesta.StatusCode + ")"
                    : contenido);

            return JsonConvert.DeserializeObject<T>(contenido)!;
        }
    }
}
