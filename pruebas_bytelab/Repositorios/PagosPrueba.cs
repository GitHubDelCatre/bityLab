using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class PagosPrueba : RepositorioPrueba<Pagos>
    {
        protected override IAplicacionBase<Pagos> CrearAplicacion(IConexion conexion)
        {
            return new PagosAplicacion(conexion);
        }

        protected override Pagos CrearEntidad()
        {
            return new Pagos()
            {
                Venta = 1,
                MetodoPago = 1,
                MontoPagado = 10,
                FechaPago = DateTime.Now,
                EstadoTransaccion = "Pendiente",
                ReferenciaPasarela = Datos.Texto(100),
            };
        }

        protected override void Modificar(Pagos entidad)
        {
            entidad.EstadoTransaccion = "Aprobada";
        }
    }
}
