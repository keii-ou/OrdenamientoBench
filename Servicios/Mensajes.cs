namespace OrdenamientoBench.Servicios;

// Textos que se muestran al usuario, separados de la lógica
public static class Mensajes
{
    public const string ArchivoConfiguracion = "banco.config.json";
    public const string Titulo = "Banco de pruebas de ordenamiento";
    public const string SeleccionIncompleta = "Elige al menos un algoritmo, un tamaño y una condición.";
    public const string SinResultados = "Todavía no hay resultados para guardar.";
    public const string SinDatosGrafica = "Ejecuta el banco de pruebas para ver la gráfica.";
    public const string EstadoListo = "Listo";
    public const string EstadoCancelado = "Ejecución cancelada";
    public const string EstadoTerminado = "Banco de pruebas terminado";
    public const string EstadoProgreso = "{0} de {1} - {2}";
    public const string DescripcionPrueba = "{0} con {1:N0} registros ({2})";
    public const string NumeroInvalido = "\"{0}\" no es un número entero válido.";
    public const string TiempoRapido = "Tiempo: {0:F4} ms";
    public const string TamanoDuplicado = "Ese tamaño ya está en la lista.";
    public const string ErrorGuardar = "No se pudo guardar el archivo: {0}";
    public const string EtiquetaEjeY = "Tiempo (ms)";
    public const string EtiquetaEjeX = "Cantidad de registros";
    public const string TituloGrafica = "Tiempo de ejecución - {0}";

    public static readonly string[] EncabezadosCsv =
    {
        "Algoritmo", "Tipo", "Registros", "Condicion", "CPU_ms", "Reloj_ms", "OrdenoBien"
    };
}
