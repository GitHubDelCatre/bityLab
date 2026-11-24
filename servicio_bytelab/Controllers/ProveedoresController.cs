using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProveedoresController : ControladorBase<Proveedores>
    {
        private IProveedoresAplicacion IProveedoresAplicacion;

        public ProveedoresController(IProveedoresAplicacion IProveedoresAplicacion) : base(IProveedoresAplicacion)
        {
            this.IProveedoresAplicacion = IProveedoresAplicacion;
        }
    }
}
