using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductosController : ControladorBase<Productos>
    {
        private IProductosAplicacion IProductosAplicacion;

        public ProductosController(IProductosAplicacion IProductosAplicacion) : base(IProductosAplicacion)
        {
            this.IProductosAplicacion = IProductosAplicacion;
        }
    }
}
