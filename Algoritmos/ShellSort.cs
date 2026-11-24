namespace OrdenamientoBench.Algoritmos;

public class ShellSort : IMetodoOrdenamiento
{
    public string Nombre => "ShellSort";
    public TipoMetodo Tipo => TipoMetodo.Interno;

    public void Ordenar(int[] datos)
    {
        // Secuencia de Knuth: 1, 4, 13, 40, ... (h = 3h + 1)
        int salto = 1;
        while (salto < datos.Length / 3)
        {
            salto = salto * 3 + 1;
        }

        while (salto >= 1)
        {
            // Inserción directa, pero comparando elementos separados por "salto"
            for (int i = salto; i < datos.Length; i++)
            {
                int actual = datos[i];
                int j = i;
                while (j >= salto && datos[j - salto] > actual)
                {
                    datos[j] = datos[j - salto];
                    j -= salto;
                }
                datos[j] = actual;
            }
            salto /= 3;
        }
    }
}
