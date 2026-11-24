namespace lib_bytelab.entidades
{
    /// <summary>
    /// Clase padre de todas las entidades (herencia).
    /// Todas tienen Id y cada una define sus propias reglas en Validar() (polimorfismo).
    /// </summary>
    public abstract class EntidadBase
    {
        public int Id { get; set; }

        /// <summary>Devuelve la lista de campos que faltan o reglas que no se cumplen.</summary>
        public abstract List<string> Validar();

        public bool FaltaInformacion()
        {
            return Validar().Count > 0;
        }
    }
}
