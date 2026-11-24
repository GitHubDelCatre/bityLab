using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class DetallesOrdenesComprasAplicacion : AplicacionBase<DetallesOrdenesCompras>, IDetallesOrdenesComprasAplicacion
    {
        public DetallesOrdenesComprasAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<DetallesOrdenesCompras> Consulta()
        {
            return this.IConexion.DetallesOrdenesCompras!
                .Include(x => x._ComprasProducto).ThenInclude(x => x!._Proveedor)
                .Include(x => x._Producto);
        }

        protected override IQueryable<DetallesOrdenesCompras> Filtrar(IQueryable<DetallesOrdenesCompras> consulta, DetallesOrdenesCompras filtro)
        {
            var texto = filtro._Producto?.NombreProducto ?? "";
            return consulta.Where(x => texto == "" || x._Producto!.NombreProducto!.Contains(texto));
        }

        protected override void AntesDeGuardar(DetallesOrdenesCompras entidad)
        {
            entidad.SubtotalCosto = DetallesOrdenesCompras.CalcularSubtotal(entidad.CantidadSolicitada, entidad.CostoUnitario);
        }

        protected override void DespuesDeGuardar(DetallesOrdenesCompras entidad)
        {
            new ComprasProductosAplicacion(this.IConexion).RecalcularTotal(entidad.ComprasProducto);
        }

        protected override void DespuesDeBorrar(DetallesOrdenesCompras existente)
        {
            new ComprasProductosAplicacion(this.IConexion).RecalcularTotal(existente.ComprasProducto);
        }
    }
}
