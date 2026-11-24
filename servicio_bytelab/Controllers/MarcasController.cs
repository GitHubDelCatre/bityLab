using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MarcasController : ControladorBase<Marcas>
    {
        private IMarcasAplicacion IMarcasAplicacion;

        public MarcasController(IMarcasAplicacion IMarcasAplicacion) : base(IMarcasAplicacion)
        {
            this.IMarcasAplicacion = IMarcasAplicacion;
        }
    }
}
