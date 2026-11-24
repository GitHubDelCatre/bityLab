using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using pruebas_bytelab.Nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class PromocionesPrueba : RepositorioPrueba<Promociones>
    {
        protected override IAplicacionBase<Promociones> CrearAplicacion(IConexion conexion)
        {
            return new PromocionesAplicacion(conexion);
        }

        protected override Promociones CrearEntidad()
        {
            return new Promociones()
            {
                CodigoCupon = Datos.Unico(30),
                Descripcion = Datos.Texto(200),
                PorcentajeDescuento = 10,
                FechaInicio = DateTime.Now,
                FechaFin = DateTime.Now.AddDays(30),
                EstadoActiva = true,
            };
        }

        protected override void Modificar(Promociones entidad)
        {
            entidad.Descripcion = "Modificado";
        }
    }
}
