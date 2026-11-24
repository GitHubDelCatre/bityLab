using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DevolucionesController : ControladorBase<Devoluciones>
    {
        private IDevolucionesAplicacion IDevolucionesAplicacion;

        public DevolucionesController(IDevolucionesAplicacion IDevolucionesAplicacion) : base(IDevolucionesAplicacion)
        {
            this.IDevolucionesAplicacion = IDevolucionesAplicacion;
        }
    }
}
