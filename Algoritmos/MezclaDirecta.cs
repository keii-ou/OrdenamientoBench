namespace OrdenamientoBench.Algoritmos;

public class MezclaDirecta : IMetodoOrdenamiento
{
    public string Nombre => "Mezcla Directa";
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

        // Las corridas empiezan de tamaño 1 y se duplican en cada vuelta
        for (long longitud = 1; longitud < datos.Length; longitud *= 2)
        {
            OperacionesPorLongitud.Distribuir(principal, auxiliarA, auxiliarB, longitud);
            OperacionesPorLongitud.Fusionar(auxiliarA, auxiliarB, principal, longitud);
        }

        AlmacenBinario.Cargar(principal, datos);
    }
}
