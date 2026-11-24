namespace OrdenamientoBench.Algoritmos;

public class Burbuja : IMetodoOrdenamiento
{
    public string Nombre => "Burbuja";
    public TipoMetodo Tipo => TipoMetodo.Interno;

    public void Ordenar(int[] datos)
    {
        int limite = datos.Length - 1;
        bool huboIntercambio = true;

        // Si una pasada completa no intercambia nada, el arreglo ya quedó ordenado
        while (huboIntercambio && limite > 0)
        {
            huboIntercambio = false;
            for (int i = 0; i < limite; i++)
            {
                if (datos[i] > datos[i + 1])
                {
                    (datos[i], datos[i + 1]) = (datos[i + 1], datos[i]);
                    huboIntercambio = true;
                }
            }
            // El mayor de la pasada ya está en su lugar, así que el límite baja
            limite--;
        }
    }
}
