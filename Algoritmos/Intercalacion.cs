namespace OrdenamientoBench.Algoritmos;

public class Intercalacion : IMetodoOrdenamiento
{
    private readonly int tamanoBloque;
    private readonly Quicksort ordenadorDeBloques = new();

    public Intercalacion(int tamanoBloque)
    {
        // Un bloque mínimo de 2 evita ciclos sin avance
        this.tamanoBloque = Math.Max(2, tamanoBloque);
    }

    public string Nombre => "Intercalación";
    public TipoMetodo Tipo => TipoMetodo.Externo;

    public void Ordenar(int[] datos)
    {
        if (datos.Length < 2)
        {
            return;
        }

        using var temporal = new DirectorioTemporal();
        string principal = temporal.NuevaRuta("principal");
        string auxiliarA = temporal.NuevaRuta("auxiliarA");
        string auxiliarB = temporal.NuevaRuta("auxiliarB");

        AlmacenBinario.Guardar(principal, datos);
        GenerarBloquesOrdenados(principal, auxiliarA, auxiliarB);

        // Ya hay corridas de tamaño "tamanoBloque", así que solo falta intercalarlas
        long longitud = tamanoBloque;
        while (true)
        {
            OperacionesPorLongitud.Fusionar(auxiliarA, auxiliarB, principal, longitud);
            longitud *= 2;
            if (longitud >= datos.Length)
            {
                break;
            }
            OperacionesPorLongitud.Distribuir(principal, auxiliarA, auxiliarB, longitud);
        }

        AlmacenBinario.Cargar(principal, datos);
    }

    private void GenerarBloquesOrdenados(string origen, string rutaA, string rutaB)
    {
        using var lector = new LectorEnteros(origen);
        using var escritorA = new EscritorEnteros(rutaA);
        using var escritorB = new EscritorEnteros(rutaB);

        var bloque = new int[tamanoBloque];
        bool haciaA = true;

        while (lector.HayDato)
        {
            int cargados = 0;
            while (cargados < tamanoBloque && lector.HayDato)
            {
                bloque[cargados++] = lector.Actual;
                lector.Avanzar();
            }

            // El último bloque puede venir incompleto, por eso se ordena una copia del tamaño exacto
            int[] parte = cargados == tamanoBloque ? bloque : bloque[..cargados];
            ordenadorDeBloques.Ordenar(parte);

            var escritor = haciaA ? escritorA : escritorB;
            foreach (int valor in parte)
            {
                escritor.Escribir(valor);
            }
            haciaA = !haciaA;
        }
    }
}
