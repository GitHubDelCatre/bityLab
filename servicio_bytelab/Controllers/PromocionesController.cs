using lib_bytelab.entidades;
using lib_bytelab.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicio_bytelab.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PromocionesController : ControladorBase<Promociones>
    {
        private IPromocionesAplicacion IPromocionesAplicacion;

        public PromocionesController(IPromocionesAplicacion IPromocionesAplicacion) : base(IPromocionesAplicacion)
        {
            this.IPromocionesAplicacion = IPromocionesAplicacion;
        }
    }
}
