using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmpresasPaqueteriaController : ControladorBase<EmpresasPaqueteria>
    {
        private IEmpresasPaqueteriaAplicacion IEmpresasPaqueteriaAplicacion;

        public EmpresasPaqueteriaController(IEmpresasPaqueteriaAplicacion IEmpresasPaqueteriaAplicacion) : base(IEmpresasPaqueteriaAplicacion)
        {
            this.IEmpresasPaqueteriaAplicacion = IEmpresasPaqueteriaAplicacion;
        }
    }
}
