using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class PagosAplicacion : AplicacionBase<Pagos>, IPagosAplicacion
    {
        public PagosAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<Pagos> Consulta()
        {
            return this.IConexion.Pagos!
                .Include(x => x._Venta)
                .Include(x => x._MetodoPago);
        }

        protected override IQueryable<Pagos> Filtrar(IQueryable<Pagos> consulta, Pagos filtro)
        {
            var texto = filtro.EstadoTransaccion ?? "";
            return consulta.Where(x => texto == "" || x.EstadoTransaccion!.Contains(texto));
        }
    }
}
