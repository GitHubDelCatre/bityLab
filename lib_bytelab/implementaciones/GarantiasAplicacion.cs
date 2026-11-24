using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class GarantiasAplicacion : AplicacionBase<Garantias>, IGarantiasAplicacion
    {
        public GarantiasAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<Garantias> Consulta()
        {
            return this.IConexion.Garantias!
                .Include(x => x._DetalleVenta).ThenInclude(x => x!._Producto);
        }

        protected override IQueryable<Garantias> Filtrar(IQueryable<Garantias> consulta, Garantias filtro)
        {
            var texto = filtro.MotivoFalla ?? "";
            return consulta.Where(x => texto == "" || x.MotivoFalla!.Contains(texto));
        }
    }
}
