using OrdenamientoBench.Modelos;

namespace OrdenamientoBench.Servicios;

public static class GeneradorDatos
{
    public static int[] CrearAleatorio(int cantidad, int valorMaximo, int semilla)
    {
        // La semilla fija hace que todos los algoritmos reciban los mismos datos
        var azar = new Random(semilla + cantidad);
        var datos = new int[cantidad];
        for (int i = 0; i < cantidad; i++)
        {
            datos[i] = azar.Next(valorMaximo);
        }
        return datos;
    }

    public static int[] Preparar(int[] aleatorio, Condicion condicion)
    {
        var copia = (int[])aleatorio.Clone();
        switch (condicion)
        {
            case Condicion.PreviamenteOrdenado:
                Array.Sort(copia);
                break;
            case Condicion.OrdenInverso:
                Array.Sort(copia);
                Array.Reverse(copia);
                break;
        }
        return copia;
    }
}
