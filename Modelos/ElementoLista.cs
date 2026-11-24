namespace OrdenamientoBench.Modelos;

// Envuelve un valor con el texto que se muestra en listas y combos
public sealed record ElementoLista<T>(T Valor, string Texto)
{
    public override string ToString() => Texto;
}
