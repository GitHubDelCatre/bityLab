using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuditoriasController : ControladorBase<Auditorias>
    {
        private IAuditoriasAplicacion IAuditoriasAplicacion;

        public AuditoriasController(IAuditoriasAplicacion IAuditoriasAplicacion) : base(IAuditoriasAplicacion)
        {
            this.IAuditoriasAplicacion = IAuditoriasAplicacion;
        }
    }
}
