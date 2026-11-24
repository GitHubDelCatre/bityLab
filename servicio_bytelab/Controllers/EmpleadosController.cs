using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmpleadosController : ControladorBase<Empleados>
    {
        private IEmpleadosAplicacion IEmpleadosAplicacion;

        public EmpleadosController(IEmpleadosAplicacion IEmpleadosAplicacion) : base(IEmpleadosAplicacion)
        {
            this.IEmpleadosAplicacion = IEmpleadosAplicacion;
        }
    }
}
