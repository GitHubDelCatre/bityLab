using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoriasController : ControladorBase<Categorias>
    {
        private ICategoriasAplicacion ICategoriasAplicacion;

        public CategoriasController(ICategoriasAplicacion ICategoriasAplicacion) : base(ICategoriasAplicacion)
        {
            this.ICategoriasAplicacion = ICategoriasAplicacion;
        }
    }
}
