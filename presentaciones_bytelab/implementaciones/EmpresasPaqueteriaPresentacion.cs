using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace presentaciones_bytelab.implementaciones
{
    public class EmpresasPaqueteriaPresentacion : PresentacionBase<EmpresasPaqueteria>, IEmpresasPaqueteriaPresentacion
    {
        public EmpresasPaqueteriaPresentacion(IComunicaciones IComunicaciones) : base(IComunicaciones) { }
    }
}
