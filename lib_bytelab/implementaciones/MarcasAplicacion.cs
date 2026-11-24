using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class MarcasAplicacion : AplicacionBase<Marcas>, IMarcasAplicacion
    {
        public MarcasAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<Marcas> Consulta()
        {
            return this.IConexion.Marcas!;
        }

        protected override IQueryable<Marcas> Filtrar(IQueryable<Marcas> consulta, Marcas filtro)
        {
            var texto = filtro.NombreMarca ?? "";
            return consulta.Where(x => texto == "" || x.NombreMarca!.Contains(texto));
        }
    }
}
