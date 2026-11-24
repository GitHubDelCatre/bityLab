using System.Text.Json;
using front_bytelab.nucleo;
using lib_bytelab.entidades;
using lib_bytelab.nucleo;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    /// <summary>
    /// Aplicación específica: mapa de sucursales.
    /// 1. Pide las sucursales a la API.
    /// 2. Arma una lista con nombre, dirección, latitud y longitud.
    /// 3. La convierte a JSON para que el JavaScript de la página pinte los marcadores.
    /// </summary>
    public class MapaModel : PaginaSegura
    {
        private ISucursalesPresentacion ISucursalesPresentacion;

        public MapaModel(ISucursalesPresentacion ISucursalesPresentacion)
        {
            this.ISucursalesPresentacion = ISucursalesPresentacion;
        }

        public override string Permiso => "Mapa";
        public List<Sucursales> Sucursales { get; set; } = new List<Sucursales>();
        public string PuntosJson { get; set; } = "[]";

        public void OnGet()
        {
            try
            {
                Sucursales = this.ISucursalesPresentacion.Consultar();

                var puntos = Sucursales
                    .Where(x => x.Latitud != null && x.Longitud != null)
                    .Select(x => new
                    {
                        nombre = x.NombreSucursal,
                        direccion = x.Direccion + ", " + x.Ciudad,
                        lat = x.Latitud,
                        lng = x.Longitud
                    });
                PuntosJson = JsonSerializer.Serialize(puntos);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
