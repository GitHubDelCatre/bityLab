using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class ResenasAplicacion : AplicacionBase<Resenas>, IResenasAplicacion
    {
        public ResenasAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<Resenas> Consulta()
        {
            return this.IConexion.Resenas!
                .Include(x => x._Producto)
                .Include(x => x._Cliente).ThenInclude(x => x!._Usuario);
        }

        protected override IQueryable<Resenas> Filtrar(IQueryable<Resenas> consulta, Resenas filtro)
        {
            var texto = filtro._Producto?.NombreProducto ?? "";
            return consulta.Where(x => texto == "" || x._Producto!.NombreProducto!.Contains(texto));
        }
    }
}
