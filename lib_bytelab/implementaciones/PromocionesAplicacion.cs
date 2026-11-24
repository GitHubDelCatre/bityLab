using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class PromocionesAplicacion : AplicacionBase<Promociones>, IPromocionesAplicacion
    {
        public PromocionesAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<Promociones> Consulta()
        {
            return this.IConexion.Promociones!;
        }

        protected override IQueryable<Promociones> Filtrar(IQueryable<Promociones> consulta, Promociones filtro)
        {
            var texto = filtro.CodigoCupon ?? "";
            return consulta.Where(x => texto == "" || x.CodigoCupon!.Contains(texto));
        }
    }
}
