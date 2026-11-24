using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class PromocionesModel : VentanaBase<Promociones>
    {

        public PromocionesModel(IPromocionesPresentacion IPromocionesPresentacion,
            IReportes IReportes) : base(IPromocionesPresentacion, IReportes)
        {
        }

        public override string Titulo => "Promociones";
        public override bool SoloLectura => false;


        protected override void Inicializar(Promociones entidad)
        {
            entidad.FechaInicio = DateTime.Now;
            entidad.FechaFin = DateTime.Now.AddMonths(1);
            entidad.EstadoActiva = true;
        }
    }
}
