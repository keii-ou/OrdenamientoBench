using System.ComponentModel;
using OrdenamientoBench.Algoritmos;

namespace OrdenamientoBench.Modelos;

public class ResultadoMedicion
{
    [DisplayName("Algoritmo")]
    public string Algoritmo { get; init; } = string.Empty;

    [DisplayName("Tipo")]
    public TipoMetodo Tipo { get; init; }

    [DisplayName("Registros")]
    public int Tamano { get; init; }

    [Browsable(false)]
    public Condicion Condicion { get; init; }

    [DisplayName("Condición")]
    public string DescripcionCondicion => Condicion.Descripcion();

    [DisplayName("Tiempo CPU (ms)")]
    public double CpuMs { get; init; }

    [DisplayName("Tiempo reloj (ms)")]
    public double RelojMs { get; init; }

    [DisplayName("Ordenó bien")]
    public bool Correcto { get; init; }
}
