using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using lib_bytelab.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_bytelab.implementaciones
{
    public class ProductosAplicacion : AplicacionBase<Productos>, IProductosAplicacion
    {
        public ProductosAplicacion(IConexion IConexion) : base(IConexion) { }

        protected override IQueryable<Productos> Consulta()
        {
            return this.IConexion.Productos!
                .Include(x => x._Categoria)
                .Include(x => x._Marca);
        }

        protected override IQueryable<Productos> Filtrar(IQueryable<Productos> consulta, Productos filtro)
        {
            var texto = filtro.NombreProducto ?? "";
            return consulta.Where(x => texto == "" || x.NombreProducto!.Contains(texto));
        }

        protected override void AntesDeGuardar(Productos entidad)
        {
            // Si al editar no se sube una imagen nueva, se conserva la que ya tenía
            if (entidad.Id != 0 && string.IsNullOrEmpty(entidad.Imagen))
                entidad.Imagen = this.IConexion.Productos!.AsNoTracking()
                    .Where(x => x.Id == entidad.Id)
                    .Select(x => x.Imagen)
                    .FirstOrDefault();
        }
    }
}
