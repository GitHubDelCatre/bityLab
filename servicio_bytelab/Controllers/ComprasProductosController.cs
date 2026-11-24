using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ComprasProductosController : ControladorBase<ComprasProductos>
    {
        private IComprasProductosAplicacion IComprasProductosAplicacion;

        public ComprasProductosController(IComprasProductosAplicacion IComprasProductosAplicacion) : base(IComprasProductosAplicacion)
        {
            this.IComprasProductosAplicacion = IComprasProductosAplicacion;
        }
    }
}
