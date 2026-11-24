using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InventariosController : ControladorBase<Inventarios>
    {
        private IInventariosAplicacion IInventariosAplicacion;

        public InventariosController(IInventariosAplicacion IInventariosAplicacion) : base(IInventariosAplicacion)
        {
            this.IInventariosAplicacion = IInventariosAplicacion;
        }
    }
}
