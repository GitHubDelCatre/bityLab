using lib_bytelab.entidades;
using lib_bytelab.implementaciones;
using lib_bytelab.nucleo;

namespace pruebas_bytelab.Repositorios
{
    [TestClass]
    public class AuditoriasPrueba
    {
        [TestMethod]
        public void CadaCambioQuedaAuditado()
        {
            var conexion = new Conexion() { StringConexion = DatosGenerales.StringConexion(), UsuarioActual = "pruebas" };
            var categorias = new CategoriasAplicacion(conexion);
            var auditorias = new AuditoriasAplicacion(conexion);

            var categoria = new Categorias() { Nombre = "Aud-" + Guid.NewGuid().ToString("N").Substring(0, 10) };
            categorias.Insertar(categoria);
            categorias.Borrar(categoria);

            var registros = auditorias.Buscar(new Auditorias() { Entidad = "Categorias" })
                .Where(x => x.IdRegistro == categoria.Id)
                .ToList();

            Assert.IsTrue(registros.Any(x => x.Accion == "Insertar" && x.Usuario == "pruebas"));
            Assert.IsTrue(registros.Any(x => x.Accion == "Borrar"));
        }

        [TestMethod]
        public void NoSePuedenEditarAMano()
        {
            var auditorias = new AuditoriasAplicacion(new Conexion());
            var lanzoError = false;
            try
            {
                auditorias.Borrar(new Auditorias() { Id = 1 });
            }
            catch (Exception)
            {
                lanzoError = true;
            }
            Assert.IsTrue(lanzoError);
        }
    }
}
