using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class AuditoriasModel : VentanaBase<Auditorias>
    {

        public AuditoriasModel(IAuditoriasPresentacion IAuditoriasPresentacion,
            IReportes IReportes) : base(IAuditoriasPresentacion, IReportes)
        {
        }

        public override string Titulo => "Auditorías";
        public override bool SoloLectura => true;

    }
}
