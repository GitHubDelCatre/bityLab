using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class InventariosAplicacion : AplicacionBase<Inventarios>, IInventariosAplicacion
    {
        public InventariosAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<Inventarios> Consulta()
        {
            return this.IConexion.Inventarios!
                .Include(x => x._Producto)
                .Include(x => x._Sucursal);
        }

        protected override IQueryable<Inventarios> Filtrar(IQueryable<Inventarios> consulta, Inventarios filtro)
        {
            var texto = filtro._Producto?.NombreProducto ?? "";
            return consulta.Where(x => texto == "" || x._Producto!.NombreProducto!.Contains(texto));
        }

        protected override void AntesDeGuardar(Inventarios entidad)
        {
            entidad.UltimaActualizacion = DateTime.Now;
        }
    }
}
