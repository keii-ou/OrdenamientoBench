using System.Globalization;
using System.Text;
using OrdenamientoBench.Modelos;

namespace OrdenamientoBench.Servicios;

public static class ExportadorResultados
{
    public static void GuardarCsv(string ruta, IEnumerable<ResultadoMedicion> resultados)
    {
        var cultura = CultureInfo.InvariantCulture;
        var texto = new StringBuilder();
        texto.AppendLine(string.Join(",", Mensajes.EncabezadosCsv));

        foreach (var r in resultados)
        {
            texto.AppendLine(string.Join(",",
                r.Algoritmo,
                r.Tipo,
                r.Tamano.ToString(cultura),
                r.Condicion.Descripcion(),
                r.CpuMs.ToString("F3", cultura),
                r.RelojMs.ToString("F3", cultura),
                r.Correcto));
        }

        File.WriteAllText(ruta, texto.ToString(), Encoding.UTF8);
    }
}
