using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetallesOrdenesComprasController : ControladorBase<DetallesOrdenesCompras>
    {
        private IDetallesOrdenesComprasAplicacion IDetallesOrdenesComprasAplicacion;

        public DetallesOrdenesComprasController(IDetallesOrdenesComprasAplicacion IDetallesOrdenesComprasAplicacion) : base(IDetallesOrdenesComprasAplicacion)
        {
            this.IDetallesOrdenesComprasAplicacion = IDetallesOrdenesComprasAplicacion;
        }
    }
}
