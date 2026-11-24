using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClientesController : ControladorBase<Clientes>
    {
        private IClientesAplicacion IClientesAplicacion;

        public ClientesController(IClientesAplicacion IClientesAplicacion) : base(IClientesAplicacion)
        {
            this.IClientesAplicacion = IClientesAplicacion;
        }
    }
}
