using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class MarcasModel : VentanaBase<Marcas>
    {

        public MarcasModel(IMarcasPresentacion IMarcasPresentacion,
            IReportes IReportes) : base(IMarcasPresentacion, IReportes)
        {
        }

        public override string Titulo => "Marcas";
        public override bool SoloLectura => false;

    }
}
