using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PagosController : ControladorBase<Pagos>
    {
        private IPagosAplicacion IPagosAplicacion;

        public PagosController(IPagosAplicacion IPagosAplicacion) : base(IPagosAplicacion)
        {
            this.IPagosAplicacion = IPagosAplicacion;
        }
    }
}
