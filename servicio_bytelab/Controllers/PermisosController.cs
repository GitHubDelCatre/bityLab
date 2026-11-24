using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PermisosController : ControladorBase<Permisos>
    {
        private IPermisosAplicacion IPermisosAplicacion;

        public PermisosController(IPermisosAplicacion IPermisosAplicacion) : base(IPermisosAplicacion)
        {
            this.IPermisosAplicacion = IPermisosAplicacion;
        }
    }
}
