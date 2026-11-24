using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class EmpresasPaqueteriaModel : VentanaBase<EmpresasPaqueteria>
    {

        public EmpresasPaqueteriaModel(IEmpresasPaqueteriaPresentacion IEmpresasPaqueteriaPresentacion,
            IReportes IReportes) : base(IEmpresasPaqueteriaPresentacion, IReportes)
        {
        }

        public override string Titulo => "Empresas de paquetería";
        public override bool SoloLectura => false;

    }
}
