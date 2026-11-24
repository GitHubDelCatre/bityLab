using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class PermisosModel : VentanaBase<Permisos>
    {

        public PermisosModel(IPermisosPresentacion IPermisosPresentacion,
            IReportes IReportes) : base(IPermisosPresentacion, IReportes)
        {
        }

        public override string Titulo => "Permisos";
        public override bool SoloLectura => false;

    }
}
