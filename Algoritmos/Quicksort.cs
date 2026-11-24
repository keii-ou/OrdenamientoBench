namespace OrdenamientoBench.Algoritmos;

public class Quicksort : IMetodoOrdenamiento
{
    public string Nombre => "Quicksort";
    public TipoMetodo Tipo => TipoMetodo.Interno;

    public void Ordenar(int[] datos)
    {
        Particionar(datos, 0, datos.Length - 1);
    }

    private static void Particionar(int[] datos, int inicio, int fin)
    {
        while (inicio < fin)
        {
            int pivote = MedianaDeTres(datos, inicio, fin);
            int i = inicio;
            int j = fin;

            while (i <= j)
            {
                while (datos[i] < pivote) i++;
                while (datos[j] > pivote) j--;
                if (i <= j)
                {
                    (datos[i], datos[j]) = (datos[j], datos[i]);
                    i++;
                    j--;
                }
            }

            // Se llama recursivamente sobre la parte más chica y se itera sobre la grande,
            // así la pila de llamadas nunca pasa de log n niveles
            if (j - inicio < fin - i)
            {
                Particionar(datos, inicio, j);
                inicio = i;
            }
            else
            {
                Particionar(datos, i, fin);
                fin = j;
            }
        }
    }

    private static int MedianaDeTres(int[] datos, int inicio, int fin)
    {
        int medio = inicio + (fin - inicio) / 2;
        int x = datos[inicio];
        int y = datos[medio];
        int z = datos[fin];

        if (x > y) (x, y) = (y, x);
        if (y > z) (y, z) = (z, y);
        if (x > y) (x, y) = (y, x);

        // Después de los tres cruces, y queda con el valor del medio
        return y;
    }
}
