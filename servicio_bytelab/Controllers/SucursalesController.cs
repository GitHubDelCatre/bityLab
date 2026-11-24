using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SucursalesController : ControladorBase<Sucursales>
    {
        private ISucursalesAplicacion ISucursalesAplicacion;

        public SucursalesController(ISucursalesAplicacion ISucursalesAplicacion) : base(ISucursalesAplicacion)
        {
            this.ISucursalesAplicacion = ISucursalesAplicacion;
        }
    }
}
