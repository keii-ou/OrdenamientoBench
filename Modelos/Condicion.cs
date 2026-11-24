namespace OrdenamientoBench.Modelos;

public enum Condicion
{
    Aleatorio,
    PreviamenteOrdenado,
    OrdenInverso
}

public static class CondicionExtensiones
{
    public static string Descripcion(this Condicion condicion) => condicion switch
    {
        Condicion.Aleatorio => "Aleatorio",
        Condicion.PreviamenteOrdenado => "Previamente ordenado",
        Condicion.OrdenInverso => "Orden inverso",
        _ => condicion.ToString()
    };
}
