using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class EnviosAplicacion : AplicacionBase<Envios>, IEnviosAplicacion
    {
        public EnviosAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<Envios> Consulta()
        {
            return this.IConexion.Envios!
                .Include(x => x._Venta)
                .Include(x => x._EmpresaPaqueteria);
        }

        protected override IQueryable<Envios> Filtrar(IQueryable<Envios> consulta, Envios filtro)
        {
            var texto = filtro.NumeroGuia ?? "";
            return consulta.Where(x => texto == "" || x.NumeroGuia!.Contains(texto));
        }
    }
}
