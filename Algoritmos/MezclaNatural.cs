namespace OrdenamientoBench.Algoritmos;

public class MezclaNatural : IMetodoOrdenamiento
{
    public string Nombre => "Mezcla Natural";
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

        // Mientras haya más de una corrida natural, se reparte y se vuelve a fusionar
        while (Distribuir(principal, auxiliarA, auxiliarB) > 1)
        {
            Fusionar(auxiliarA, auxiliarB, principal);
        }

        AlmacenBinario.Cargar(principal, datos);
    }

    private static int Distribuir(string origen, string rutaA, string rutaB)
    {
        using var lector = new LectorEnteros(origen);
        using var escritorA = new EscritorEnteros(rutaA);
        using var escritorB = new EscritorEnteros(rutaB);

        bool haciaA = true;
        int corridas = 0;
        int anterior = 0;

        while (lector.HayDato)
        {
            int valor = lector.Actual;

            // Una corrida termina cuando el valor baja respecto al anterior
            if (corridas == 0)
            {
                corridas = 1;
            }
            else if (valor < anterior)
            {
                haciaA = !haciaA;
                corridas++;
            }

            (haciaA ? escritorA : escritorB).Escribir(valor);
            anterior = valor;
            lector.Avanzar();
        }

        return corridas;
    }

    private static void Fusionar(string rutaA, string rutaB, string destino)
    {
        using var lectorA = new LectorEnteros(rutaA);
        using var lectorB = new LectorEnteros(rutaB);
        using var escritor = new EscritorEnteros(destino);

        while (lectorA.HayDato || lectorB.HayDato)
        {
            bool sigueCorridaA = lectorA.HayDato;
            bool sigueCorridaB = lectorB.HayDato;

            while (sigueCorridaA && sigueCorridaB)
            {
                if (lectorA.Actual <= lectorB.Actual)
                {
                    sigueCorridaA = CopiarDato(lectorA, escritor);
                }
                else
                {
                    sigueCorridaB = CopiarDato(lectorB, escritor);
                }
            }

            while (sigueCorridaA)
            {
                sigueCorridaA = CopiarDato(lectorA, escritor);
            }
            while (sigueCorridaB)
            {
                sigueCorridaB = CopiarDato(lectorB, escritor);
            }
        }
    }

    // Copia el dato actual y responde si la corrida natural continúa con el siguiente
    private static bool CopiarDato(LectorEnteros lector, EscritorEnteros escritor)
    {
        int valor = lector.Actual;
        escritor.Escribir(valor);
        lector.Avanzar();
        return lector.HayDato && lector.Actual >= valor;
    }
}
