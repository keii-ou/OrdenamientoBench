namespace OrdenamientoBench.Algoritmos;

public class Radix : IMetodoOrdenamiento
{
    private const int BitsPorDigito = 8;
    private const int Base = 1 << BitsPorDigito;
    private const int PasadasPorEntero = 32 / BitsPorDigito;

    public string Nombre => "Radix";
    public TipoMetodo Tipo => TipoMetodo.Interno;

    public void Ordenar(int[] datos)
    {
        int cantidad = datos.Length;
        int[] origen = datos;
        int[] destino = new int[cantidad];

        for (int pasada = 0; pasada < PasadasPorEntero; pasada++)
        {
            int desplazamiento = pasada * BitsPorDigito;

            // Conteo de cuántos elementos caen en cada dígito
            int[] posiciones = new int[Base + 1];
            foreach (int valor in origen)
            {
                posiciones[ObtenerDigito(valor, desplazamiento) + 1]++;
            }

            // Se acumulan los conteos para saber dónde empieza cada dígito en el destino
            for (int d = 0; d < Base; d++)
            {
                posiciones[d + 1] += posiciones[d];
            }

            // Recorrer de izquierda a derecha mantiene el orden relativo (estabilidad)
            foreach (int valor in origen)
            {
                destino[posiciones[ObtenerDigito(valor, desplazamiento)]++] = valor;
            }

            (origen, destino) = (destino, origen);
        }

        if (!ReferenceEquals(origen, datos))
        {
            Array.Copy(origen, datos, cantidad);
        }
    }

    private static int ObtenerDigito(int valor, int desplazamiento)
    {
        // Invertir el bit de signo hace que los negativos queden antes que los positivos
        uint clave = unchecked((uint)(valor ^ int.MinValue));
        return (int)((clave >> desplazamiento) & (Base - 1));
    }
}
