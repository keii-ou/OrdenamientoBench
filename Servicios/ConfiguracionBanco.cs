using System.Text.Json;

namespace OrdenamientoBench.Servicios;

public class ConfiguracionBanco
{
    private static readonly JsonSerializerOptions OpcionesJson = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public List<int> Tamanos { get; set; } = new() { 10000, 50000, 100000 };
    public int Semilla { get; set; } = 2026;
    public int Repeticiones { get; set; } = 1;
    public int TamanoBloque { get; set; } = 1000;
    public int TamanoCalentamiento { get; set; } = 1000;
    public int ValorMaximo { get; set; } = 1_000_000;
    public int AnchoImagen { get; set; } = 1200;
    public int AltoImagen { get; set; } = 700;

    public static ConfiguracionBanco Cargar(string ruta)
    {
        if (!File.Exists(ruta))
        {
            return new ConfiguracionBanco();
        }

        try
        {
            string json = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<ConfiguracionBanco>(json, OpcionesJson) ?? new ConfiguracionBanco();
        }
        catch (JsonException)
        {
            // Si el archivo está mal escrito se usan los valores por omisión
            return new ConfiguracionBanco();
        }
    }
}
