using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class EnviosPrueba : RepositorioPrueba<Envios>
    {
        protected override IAplicacionBase<Envios> CrearAplicacion(IConexion conexion)
        {
            return new EnviosAplicacion(conexion);
        }

        protected override Envios CrearEntidad()
        {
            return new Envios()
            {
                Venta = 1,
                EmpresaPaqueteria = 1,
                NumeroGuia = Datos.Unico(50),
                EstadoEnvio = "Preparando",
                FechaSalida = DateTime.Now,
                FechaEstimadaEntrega = DateTime.Now,
                FechaEntregaReal = DateTime.Now,
                CostoEnvio = 10,
            };
        }

        protected override void Modificar(Envios entidad)
        {
            entidad.EstadoEnvio = "En tránsito";
        }
    }
}
