namespace OrdenamientoBench.Algoritmos;

// Clases de apoyo para los métodos externos: todo se lee y escribe en archivos binarios

internal sealed class DirectorioTemporal : IDisposable
{
    private readonly string ruta;

    public DirectorioTemporal()
    {
        ruta = Path.Combine(Path.GetTempPath(), "ordenamiento_" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(ruta);
    }

    public string NuevaRuta(string nombre) => Path.Combine(ruta, nombre + ".bin");

    public void Dispose()
    {
        try
        {
            Directory.Delete(ruta, recursive: true);
        }
        catch (IOException)
        {
            // Si el sistema aún tiene el archivo abierto, el SO lo limpiará después
        }
    }
}

internal sealed class LectorEnteros : IDisposable
{
    private const int TamanoBufer = 1 << 16;
    private readonly BinaryReader lector;
    private long restantes;

    public LectorEnteros(string ruta)
    {
        var flujo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.Read, TamanoBufer);
        lector = new BinaryReader(flujo);
        restantes = flujo.Length / sizeof(int);
        Avanzar();
    }

    public bool HayDato { get; private set; }
    public int Actual { get; private set; }

    public void Avanzar()
    {
        if (restantes > 0)
        {
            Actual = lector.ReadInt32();
            restantes--;
            HayDato = true;
        }
        else
        {
            HayDato = false;
        }
    }

    public void Dispose() => lector.Dispose();
}

internal sealed class EscritorEnteros : IDisposable
{
    private const int TamanoBufer = 1 << 16;
    private readonly BinaryWriter escritor;

    public EscritorEnteros(string ruta)
    {
        var flujo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None, TamanoBufer);
        escritor = new BinaryWriter(flujo);
    }

    public void Escribir(int valor) => escritor.Write(valor);

    public void Dispose() => escritor.Dispose();
}

internal static class AlmacenBinario
{
    public static void Guardar(string ruta, int[] datos)
    {
        using var escritor = new EscritorEnteros(ruta);
        foreach (int valor in datos)
        {
            escritor.Escribir(valor);
        }
    }

    public static void Cargar(string ruta, int[] destino)
    {
        using var lector = new LectorEnteros(ruta);
        int indice = 0;
        while (lector.HayDato && indice < destino.Length)
        {
            destino[indice++] = lector.Actual;
            lector.Avanzar();
        }
    }
}

// Distribución y fusión por longitud fija de corrida, compartidas por Mezcla Directa e Intercalación
internal static class OperacionesPorLongitud
{
    public static void Distribuir(string origen, string rutaA, string rutaB, long longitud)
    {
        using var lector = new LectorEnteros(origen);
        using var escritorA = new EscritorEnteros(rutaA);
        using var escritorB = new EscritorEnteros(rutaB);

        bool haciaA = true;
        while (lector.HayDato)
        {
            var escritor = haciaA ? escritorA : escritorB;
            for (long i = 0; i < longitud && lector.HayDato; i++)
            {
                escritor.Escribir(lector.Actual);
                lector.Avanzar();
            }
            haciaA = !haciaA;
        }
    }

    public static void Fusionar(string rutaA, string rutaB, string destino, long longitud)
    {
        using var lectorA = new LectorEnteros(rutaA);
        using var lectorB = new LectorEnteros(rutaB);
        using var escritor = new EscritorEnteros(destino);

        while (lectorA.HayDato || lectorB.HayDato)
        {
            long usadosA = 0;
            long usadosB = 0;

            // Se mezcla una corrida de cada archivo hasta agotar alguna
            while (usadosA < longitud && lectorA.HayDato && usadosB < longitud && lectorB.HayDato)
            {
                if (lectorA.Actual <= lectorB.Actual)
                {
                    escritor.Escribir(lectorA.Actual);
                    lectorA.Avanzar();
                    usadosA++;
                }
                else
                {
                    escritor.Escribir(lectorB.Actual);
                    lectorB.Avanzar();
                    usadosB++;
                }
            }

            // Lo que quede de la otra corrida se copia tal cual
            while (usadosA < longitud && lectorA.HayDato)
            {
                escritor.Escribir(lectorA.Actual);
                lectorA.Avanzar();
                usadosA++;
            }
            while (usadosB < longitud && lectorB.HayDato)
            {
                escritor.Escribir(lectorB.Actual);
                lectorB.Avanzar();
                usadosB++;
            }
        }
    }
}
