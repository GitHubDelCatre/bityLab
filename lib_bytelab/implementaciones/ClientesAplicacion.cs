using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class ClientesAplicacion : AplicacionBase<Clientes>, IClientesAplicacion
    {
        public ClientesAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<Clientes> Consulta()
        {
            return this.IConexion.Clientes!
                .Include(x => x._Usuario);
        }

        protected override IQueryable<Clientes> Filtrar(IQueryable<Clientes> consulta, Clientes filtro)
        {
            var texto = filtro._Usuario?.NombreCompleto ?? "";
            return consulta.Where(x => texto == "" || x._Usuario!.NombreCompleto!.Contains(texto));
        }
    }
}
