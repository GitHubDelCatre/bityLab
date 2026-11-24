using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GarantiasController : ControladorBase<Garantias>
    {
        private IGarantiasAplicacion IGarantiasAplicacion;

        public GarantiasController(IGarantiasAplicacion IGarantiasAplicacion) : base(IGarantiasAplicacion)
        {
            this.IGarantiasAplicacion = IGarantiasAplicacion;
        }
    }
}
