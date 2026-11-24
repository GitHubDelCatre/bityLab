using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class EmpresasPaqueteriaAplicacion : AplicacionBase<EmpresasPaqueteria>, IEmpresasPaqueteriaAplicacion
    {
        public EmpresasPaqueteriaAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<EmpresasPaqueteria> Consulta()
        {
            return this.IConexion.EmpresasPaqueteria!;
        }

        protected override IQueryable<EmpresasPaqueteria> Filtrar(IQueryable<EmpresasPaqueteria> consulta, EmpresasPaqueteria filtro)
        {
            var texto = filtro.NombrePaqueteria ?? "";
            return consulta.Where(x => texto == "" || x.NombrePaqueteria!.Contains(texto));
        }
    }
}
