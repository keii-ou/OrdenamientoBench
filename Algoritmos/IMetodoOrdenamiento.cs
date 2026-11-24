namespace OrdenamientoBench.Algoritmos;

public enum TipoMetodo
{
    Interno,
    Externo
}

public interface IMetodoOrdenamiento
{
    string Nombre { get; }
    TipoMetodo Tipo { get; }
    void Ordenar(int[] datos);
}
