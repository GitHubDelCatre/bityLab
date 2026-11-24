using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ResenasController : ControladorBase<Resenas>
    {
        private IResenasAplicacion IResenasAplicacion;

        public ResenasController(IResenasAplicacion IResenasAplicacion) : base(IResenasAplicacion)
        {
            this.IResenasAplicacion = IResenasAplicacion;
        }
    }
}
