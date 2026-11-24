using System.Reflection;
using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace front_bytelab.nucleo
{
    /// <summary>
    /// Punto investigativo: reportes en PDF (QuestPDF) y Excel (ClosedXML).
    /// Funciona con cualquier entidad leyendo sus propiedades por reflexión.
    /// </summary>
    public class Reportes : IReportes
    {
        private static readonly string[] Ocultos = { "Imagen", "ContrasenaHash", "Contrasena", "Permisos", "EspecificacionesTecnicas", "DescripcionLarga" };

        static Reportes()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public byte[] Pdf<T>(string titulo, List<T> lista)
        {
            var (columnas, filas) = Tabla(lista);
            return PdfTabla(titulo, lista.Count + " registro(s)", columnas, filas);
        }

        public byte[] Excel<T>(string titulo, List<T> lista)
        {
            var (columnas, filas) = Tabla(lista);
            return ExcelTabla(titulo, columnas, filas);
        }

        public byte[] PdfTabla(string titulo, string subtitulo, List<string> columnas, List<List<object?>> filas)
        {
            var documento = Document.Create(contenedor =>
            {
                contenedor.Page(pagina =>
                {
                    pagina.Size(columnas.Count > 6 ? PageSizes.A4.Landscape() : PageSizes.A4);
                    pagina.Margin(25);
                    pagina.DefaultTextStyle(x => x.FontSize(8));

                    pagina.Header().PaddingBottom(10).Row(fila =>
                    {
                        fila.RelativeItem().Column(columna =>
                        {
                            columna.Item().Text("ByteLab · Tienda de Hardware").FontSize(16).Bold().FontColor("#0891b2");
                            columna.Item().Text(titulo).FontSize(12).SemiBold();
                            columna.Item().Text(subtitulo + " · Generado " + DateTime.Now.ToString("yyyy-MM-dd HH:mm")).FontSize(8).FontColor("#64748b");
                        });
                    });

                    pagina.Content().Table(tabla =>
                    {
                        tabla.ColumnsDefinition(definicion =>
                        {
                            foreach (var _ in columnas)
                                definicion.RelativeColumn();
                        });

                        tabla.Header(encabezado =>
                        {
                            foreach (var columna in columnas)
                                encabezado.Cell().Background("#0f172a").Padding(4).Text(columna).FontColor("#ffffff").Bold();
                        });

                        var i = 0;
                        foreach (var fila in filas)
                        {
                            var fondo = i++ % 2 == 0 ? "#ffffff" : "#f1f5f9";
                            foreach (var valor in fila)
                                tabla.Cell().Background(fondo).BorderBottom(0.5f).BorderColor("#e2e8f0").Padding(3).Text(Formatear(valor));
                        }
                    });

                    pagina.Footer().AlignCenter().Text(texto =>
                    {
                        texto.Span("Página ");
                        texto.CurrentPageNumber();
                        texto.Span(" de ");
                        texto.TotalPages();
                    });
                });
            });
            return documento.GeneratePdf();
        }

        public byte[] ExcelTabla(string titulo, List<string> columnas, List<List<object?>> filas)
        {
            using var libro = new XLWorkbook();
            var nombreHoja = new string(titulo.Where(c => !"[]:*?/\\".Contains(c)).ToArray());
            var hoja = libro.Worksheets.Add(nombreHoja.Length > 31 ? nombreHoja.Substring(0, 31) : nombreHoja);

            hoja.Cell(1, 1).Value = "ByteLab - " + titulo;
            hoja.Cell(1, 1).Style.Font.Bold = true;
            hoja.Cell(1, 1).Style.Font.FontSize = 14;
            hoja.Cell(2, 1).Value = "Generado: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            for (var c = 0; c < columnas.Count; c++)
            {
                var celda = hoja.Cell(4, c + 1);
                celda.Value = columnas[c];
                celda.Style.Font.Bold = true;
                celda.Style.Font.FontColor = XLColor.White;
                celda.Style.Fill.BackgroundColor = XLColor.FromHtml("#0f172a");
            }

            for (var f = 0; f < filas.Count; f++)
                for (var c = 0; c < filas[f].Count; c++)
                {
                    var celda = hoja.Cell(f + 5, c + 1);
                    switch (filas[f][c])
                    {
                        case null: celda.Value = ""; break;
                        case decimal d: celda.Value = (double)d; celda.Style.NumberFormat.Format = "#,##0.00"; break;
                        case double db: celda.Value = db; break;
                        case int n: celda.Value = n; break;
                        case bool b: celda.Value = b ? "Sí" : "No"; break;
                        case DateTime dt: celda.Value = dt; celda.Style.DateFormat.Format = "yyyy-mm-dd hh:mm"; break;
                        default: celda.Value = filas[f][c]!.ToString(); break;
                    }
                }

            hoja.Columns().AdjustToContents();
            using var memoria = new MemoryStream();
            libro.SaveAs(memoria);
            return memoria.ToArray();
        }

        /// <summary>
        /// Arma columnas y filas leyendo las propiedades de la clase.
        /// Las llaves foráneas (Rol, Producto...) se muestran con el ToString() de su objeto (_Rol, _Producto...).
        /// </summary>
        private static (List<string>, List<List<object?>>) Tabla<T>(List<T> lista)
        {
            var propiedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => !Ocultos.Contains(p.Name) && !p.Name.StartsWith("_") && p.Name != "RequiereReorden")
                .OrderBy(p => p.Name == "Id" ? 0 : 1)
                .ToList();

            var columnas = propiedades.Select(p => p.Name).ToList();
            var filas = new List<List<object?>>();
            foreach (var elemento in lista)
            {
                var fila = new List<object?>();
                foreach (var propiedad in propiedades)
                {
                    var navegacion = typeof(T).GetProperty("_" + propiedad.Name);
                    var valor = navegacion != null
                        ? navegacion.GetValue(elemento)?.ToString() ?? propiedad.GetValue(elemento)?.ToString()
                        : propiedad.GetValue(elemento);
                    fila.Add(valor);
                }
                filas.Add(fila);
            }
            return (columnas, filas);
        }

        private static string Formatear(object? valor)
        {
            return valor switch
            {
                null => "",
                decimal d => d.ToString("N2"),
                bool b => b ? "Sí" : "No",
                DateTime dt => dt.ToString("yyyy-MM-dd HH:mm"),
                _ => valor.ToString() ?? ""
            };
        }
    }
}
