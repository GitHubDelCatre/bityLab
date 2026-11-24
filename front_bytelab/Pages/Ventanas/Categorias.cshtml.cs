using front_bytelab.nucleo;
using lib_bytelab.entidades;
using presentaciones_bytelab.interfaces;

namespace front_bytelab.Pages.Ventanas
{
    public class CategoriasModel : VentanaBase<Categorias>
    {

        public CategoriasModel(ICategoriasPresentacion ICategoriasPresentacion,
            IReportes IReportes) : base(ICategoriasPresentacion, IReportes)
        {
        }

        public override string Titulo => "Categorías";
        public override bool SoloLectura => false;

    }
}
