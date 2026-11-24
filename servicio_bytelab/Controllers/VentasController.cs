using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VentasController : ControladorBase<Ventas>
    {
        private IVentasAplicacion IVentasAplicacion;

        public VentasController(IVentasAplicacion IVentasAplicacion) : base(IVentasAplicacion)
        {
            this.IVentasAplicacion = IVentasAplicacion;
        }
    }
}
