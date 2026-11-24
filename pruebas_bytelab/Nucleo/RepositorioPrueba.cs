using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;

namespace pruebas_bytelab.Nucleo
{
    /// <summary>
    /// Prueba de repositorio genérica (necesita SQL Server con db_bytelab):
    /// inserta, consulta, modifica y borra un registro de la entidad.
    /// </summary>
    public abstract class RepositorioPrueba<T> where T : EntidadBase
    {
        protected readonly IConexion conexion;
        protected readonly IAplicacionBase<T> aplicacion;

        protected RepositorioPrueba()
        {
            this.conexion = new Conexion()
            {
                StringConexion = DatosGenerales.StringConexion(),
                UsuarioActual = "pruebas"
            };
            this.aplicacion = CrearAplicacion(this.conexion);
        }

        protected abstract IAplicacionBase<T> CrearAplicacion(IConexion conexion);
        protected abstract T CrearEntidad();
        protected abstract void Modificar(T entidad);

        [TestMethod]
        public void Ejecutar()
        {
            var entidad = CrearEntidad();

            this.aplicacion.Insertar(entidad);
            Assert.AreNotEqual(0, entidad.Id, "No se generó el Id");

            Assert.IsTrue(this.aplicacion.Consultar().Any(x => x.Id == entidad.Id), "No aparece en la consulta");

            Modificar(entidad);
            this.aplicacion.Actualizar(entidad);

            this.aplicacion.Borrar(entidad);
            Assert.IsFalse(this.aplicacion.Consultar().Any(x => x.Id == entidad.Id), "No se borró");
        }
    }
}
