using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class GarantiasPrueba : RepositorioPrueba<Garantias>
    {
        protected override IAplicacionBase<Garantias> CrearAplicacion(IConexion conexion)
        {
            return new GarantiasAplicacion(conexion);
        }

        protected override Garantias CrearEntidad()
        {
            return new Garantias()
            {
                DetalleVenta = 1,
                FechaSolicitud = DateTime.Now,
                MotivoFalla = Datos.Texto(200),
                EstadoGarantia = "Recibida",
                ResolucionTecnica = Datos.Texto(200),
                FechaCierre = DateTime.Now,
            };
        }

        protected override void Modificar(Garantias entidad)
        {
            entidad.MotivoFalla = "Modificado";
        }
    }
}
