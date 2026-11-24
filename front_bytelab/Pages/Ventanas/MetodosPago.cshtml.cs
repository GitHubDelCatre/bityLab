using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class MetodosPagoModel : VentanaBase<MetodosPago>
    {

        public MetodosPagoModel(IMetodosPagoPresentacion IMetodosPagoPresentacion,
            IReportes IReportes) : base(IMetodosPagoPresentacion, IReportes)
        {
        }

        public override string Titulo => "Métodos de pago";
        public override bool SoloLectura => false;

    }
}
