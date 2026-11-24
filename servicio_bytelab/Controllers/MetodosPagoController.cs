using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MetodosPagoController : ControladorBase<MetodosPago>
    {
        private IMetodosPagoAplicacion IMetodosPagoAplicacion;

        public MetodosPagoController(IMetodosPagoAplicacion IMetodosPagoAplicacion) : base(IMetodosPagoAplicacion)
        {
            this.IMetodosPagoAplicacion = IMetodosPagoAplicacion;
        }
    }
}
