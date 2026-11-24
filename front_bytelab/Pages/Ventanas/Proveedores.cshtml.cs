using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class ProveedoresModel : VentanaBase<Proveedores>
    {

        public ProveedoresModel(IProveedoresPresentacion IProveedoresPresentacion,
            IReportes IReportes) : base(IProveedoresPresentacion, IReportes)
        {
        }

        public override string Titulo => "Proveedores";
        public override bool SoloLectura => false;

    }
}
