using OrdenamientoBench.Algoritmos;

namespace OrdenamientoBench.Servicios;

public static class CatalogoMetodos
{
    public static List<IMetodoOrdenamiento> Crear(ConfiguracionBanco configuracion)
    {
        return new List<IMetodoOrdenamiento>
        {
            new Burbuja(),
            new Quicksort(),
            new ShellSort(),
            new Radix(),
            new Intercalacion(configuracion.TamanoBloque),
            new MezclaDirecta(),
            new MezclaNatural()
        };
    }
}
