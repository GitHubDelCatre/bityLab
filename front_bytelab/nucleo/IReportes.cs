namespace front_bytelab.nucleo
{
    public interface IReportes
    {
        byte[] Pdf<T>(string titulo, List<T> lista);
        byte[] Excel<T>(string titulo, List<T> lista);
        byte[] PdfTabla(string titulo, string subtitulo, List<string> columnas, List<List<object?>> filas);
        byte[] ExcelTabla(string titulo, List<string> columnas, List<List<object?>> filas);
    }
}
