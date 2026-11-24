using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class SucursalesModel : VentanaBase<Sucursales>
    {

        public SucursalesModel(ISucursalesPresentacion ISucursalesPresentacion,
            IReportes IReportes) : base(ISucursalesPresentacion, IReportes)
        {
        }

        public override string Titulo => "Sucursales";
        public override bool SoloLectura => false;

    }
}
