using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class RolesModel : VentanaBase<Roles>
    {

        public RolesModel(IRolesPresentacion IRolesPresentacion,
            IReportes IReportes) : base(IRolesPresentacion, IReportes)
        {
        }

        public override string Titulo => "Roles";
        public override bool SoloLectura => false;

    }
}
