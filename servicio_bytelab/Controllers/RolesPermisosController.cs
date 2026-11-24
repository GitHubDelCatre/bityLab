using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RolesPermisosController : ControladorBase<RolesPermisos>
    {
        private IRolesPermisosAplicacion IRolesPermisosAplicacion;

        public RolesPermisosController(IRolesPermisosAplicacion IRolesPermisosAplicacion) : base(IRolesPermisosAplicacion)
        {
            this.IRolesPermisosAplicacion = IRolesPermisosAplicacion;
        }
    }
}
