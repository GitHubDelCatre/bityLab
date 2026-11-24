using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class MetodosPagoAplicacion : AplicacionBase<MetodosPago>, IMetodosPagoAplicacion
    {
        public MetodosPagoAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<MetodosPago> Consulta()
        {
            return this.IConexion.MetodosPago!;
        }

        protected override IQueryable<MetodosPago> Filtrar(IQueryable<MetodosPago> consulta, MetodosPago filtro)
        {
            var texto = filtro.NombreMetodo ?? "";
            return consulta.Where(x => texto == "" || x.NombreMetodo!.Contains(texto));
        }
    }
}
