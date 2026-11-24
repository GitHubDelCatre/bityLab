using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class DevolucionesAplicacion : AplicacionBase<Devoluciones>, IDevolucionesAplicacion
    {
        public DevolucionesAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<Devoluciones> Consulta()
        {
            return this.IConexion.Devoluciones!
                .Include(x => x._Venta)
                .Include(x => x._MetodoPago);
        }

        protected override IQueryable<Devoluciones> Filtrar(IQueryable<Devoluciones> consulta, Devoluciones filtro)
        {
            var texto = filtro.MotivoDevolucion ?? "";
            return consulta.Where(x => texto == "" || x.MotivoDevolucion!.Contains(texto));
        }
    }
}
