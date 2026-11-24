using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EnviosController : ControladorBase<Envios>
    {
        private IEnviosAplicacion IEnviosAplicacion;

        public EnviosController(IEnviosAplicacion IEnviosAplicacion) : base(IEnviosAplicacion)
        {
            this.IEnviosAplicacion = IEnviosAplicacion;
        }
    }
}
