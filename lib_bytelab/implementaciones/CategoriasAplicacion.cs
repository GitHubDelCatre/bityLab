using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class CategoriasAplicacion : AplicacionBase<Categorias>, ICategoriasAplicacion
    {
        public CategoriasAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<Categorias> Consulta()
        {
            return this.IConexion.Categorias!;
        }

        protected override IQueryable<Categorias> Filtrar(IQueryable<Categorias> consulta, Categorias filtro)
        {
            var texto = filtro.Nombre ?? "";
            return consulta.Where(x => texto == "" || x.Nombre!.Contains(texto));
        }
    }
}
